using KingICT_Project.Flight_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingICT_Project
{
    public partial class UiMainForm : Form
    {

        /*

Potrebno je napraviti aplikaciju za pretraživanje cijena low-cost avionskih letova. Cijene letova se moraju moći pretraživati po:
    •	        polaznom aerodromu (prema IATA šifri aerodroma)
    •	        odredišnom aerodromu (prema IATA šifri aerodroma)
    •	        datumu polaska/povratka
    •	        broju putnika
    •	        valuti (USD, EUR, HRK)

Rezultate je potrebno tablično prikazati na ekranu, vrijednosti koje je potrebno prikazati:
    •	polazni aerodrom
    •	odredišni aerodrom
    •	datum polaska/povratka
    •	broj presjedanja u odlaznom/povratnom putovanju
    •	broj putnika
    •	valuta
    •	ukupna cijena
 
             
             
             */

        public string selectedOrigin;
        public string selectedDestination;
        private string accessToken;
        private FlightRoute fr = new FlightRoute();
        public UiMainForm()
        {
            accessToken = GetAuthorizationData().Result;

            InitializeComponent();
            CurrencyFilling();
            IataTableFilling();
            ControLInitialSettings();



        }

        private void ControLInitialSettings()
        {
            UiDepartureDateTimePicker.MinDate = DateTime.Now;
            UiReturnDateTimePicker.MinDate = DateTime.Now;
        }
        private void CurrencyFilling()
        {
            List<string> CurrencyList = new List<string>();
            CurrencyList.Add("USD");
            CurrencyList.Add("EUR");
            CurrencyList.Add("HRK");
            UiCurrencyComboBox.DataSource = null;
            UiCurrencyComboBox.DataSource = CurrencyList;
        }
        private void IataTableFilling()
        {
            UiOriginIataCodeGridView.DataSource = null;
            UiOriginIataCodeGridView.DataSource = DataBaseOp.FetchSpecificIataCodes(String.Empty);
        }
        private void TableFilling(Flight flightsObject)
        {
            UiSearchResultDataGridView.DataSource = null;

            if (flightsObject.Data != null)
            {
                List<FlightsGridView> listOfFlights = new List<FlightsGridView>();
                foreach (var flight in flightsObject.Data)
                {
                    listOfFlights.Add(new FlightsGridView
                    {
                        Origin = fr.Origin.ToString(),
                        Destination = fr.Destination.ToString(),
                        ChangesIngoing = flight.OfferItems[0].Services[1].Segments.Count() - 1,
                        ChangesOutgoing = flight.OfferItems[0].Services[0].Segments.Count() - 1,
                        DepartureDate = UiDepartureDateTimePicker.Value.ToString("dd. MM. yyyy."),
                        ReturnDate = UiReturnDateTimePicker.Value.ToString("dd. MM. yyyy."),
                        AdultAvailabilityOut = flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerAdult == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerAdult.Availability.ToString(),
                        ChildrenAvailabilityOut = flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerChild == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerChild.Availability.ToString(),
                        InfantsAvailabilityOut = flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerInfant == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerInfant.Availability.ToString(),
                        SeniorsAvailabilityOut = flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerSenior == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerSenior.Availability.ToString(),
                        AdultAvailabilityIn = flight.OfferItems[0].Services[1].Segments[0].PricingDetailPerAdult == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerAdult.Availability.ToString(),
                        ChildrenAvailabilityIn = flight.OfferItems[0].Services[1].Segments[0].PricingDetailPerChild == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerChild.Availability.ToString(),
                        InfantsAvailabilityIn = flight.OfferItems[0].Services[1].Segments[0].PricingDetailPerInfant == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerInfant.Availability.ToString(),
                        SeniorsAvailabilityIn = flight.OfferItems[0].Services[1].Segments[0].PricingDetailPerSenior == null ? "empty" : flight.OfferItems[0].Services[0].Segments[0].PricingDetailPerSenior.Availability.ToString(),
                        Price = double.Parse(flight.OfferItems[0].Price.Total, CultureInfo.InvariantCulture),
                        Currency = UiCurrencyComboBox.SelectedItem.ToString()
                    }
                    );
                }
                UiSearchResultDataGridView.DataSource = listOfFlights;
            }
        }


        /// <summary>
        /// Access Token has an expiring deadline so, every time before fetching data from Amadeus web service, the app needs to fetch newest access token.
        /// </summary>
        private async Task<string> GetAuthorizationData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, @"https://test.api.amadeus.com/v1/security/oauth2/token");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("client_id", "NmcNIXuL3qvZ8QdruHbAAnKMyAdtRrKP"));
            keyValues.Add(new KeyValuePair<string, string>("client_secret", "7oGpMoWMCug04nUi"));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
            Authorization userAuthorization = JsonConvert.DeserializeObject<Authorization>(response);
            return userAuthorization.access_token;
        }

        /// <summary>
        /// The function that fetches the JSON string from Amadeus web service and stores that JSON to an object of the class.
        /// </summary>
        private async Task<Flight> GetDataFromAmadeusWebService(string accessToken, string currency)
        {
            Flight flightsObject = new Flight();
            List<string> listOfParameters = new List<string>();
            if (fr.Origin != null)
            {
                listOfParameters.Add("origin=" + fr.Origin + "");
            }
            if (fr.Destination != null)
            {
                listOfParameters.Add("destination=" + fr.Destination + "");
            }
            if (UiDepartureDateTimePicker.Value != null)
            {
                listOfParameters.Add("departureDate=" + UiDepartureDateTimePicker.Value.ToString("yyyy-MM-dd") + "");
            }
            if (UiReturnDateTimePicker.Value != null)
            {
                listOfParameters.Add("returnDate=" + UiReturnDateTimePicker.Value.ToString("yyyy-MM-dd") + "");
            }
            if (UiAdultsTextBox.Text != "" && int.Parse(UiAdultsTextBox.Text) > 0)
            {
                listOfParameters.Add("adults=" + UiAdultsTextBox.Text + "");
            }
            if (UiChildrenTextBox.Text != "" && int.Parse(UiChildrenTextBox.Text) > 0)
            {
                listOfParameters.Add("children=" + UiChildrenTextBox.Text + "");
            }
            if (UiInfantsTextBox.Text != "" && int.Parse(UiInfantsTextBox.Text) > 0)
            {
                listOfParameters.Add("infants=" + UiInfantsTextBox.Text + "");
            }
            if (UiSeniorsTextBox.Text != "" && int.Parse(UiSeniorsTextBox.Text) > 0)
            {
                listOfParameters.Add("seniors=" + UiSeniorsTextBox.Text + "");
            }
            if (currency != "")
            {
                listOfParameters.Add("currency=" + currency + "");
            }
            string urlParameters = String.Join("&", listOfParameters);
            string pageUrl = @"https://test.api.amadeus.com/v1/shopping/flight-offers?" + urlParameters + "";


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            using (HttpResponseMessage response = await client.GetAsync(pageUrl))
            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                if (json != null)
                {
                    flightsObject = JsonConvert.DeserializeObject<Flight>(json);
                    if (flightsObject.Errors != null)
                    {
                        MessageBox.Show(flightsObject.Errors[0].Detail, flightsObject.Errors[0].Title);
                    }
                }
            }
            return flightsObject;
        }
        private void RefreshRouteListBox()
        {
            UiCurrentSelectionListBox.Items.Clear();
            UiCurrentSelectionListBox.Items.Add(fr.Origin + " >> " + fr.Destination);
        }
        private void UiOriginButton_Click(object sender, EventArgs e)
        {
            Iata_airport_codes selectedGridItem = (Iata_airport_codes)UiOriginIataCodeGridView.CurrentRow.DataBoundItem;
            selectedOrigin = selectedGridItem.Code;
            fr.Origin = selectedOrigin;
            RefreshRouteListBox();
        }

        private void UiDestinationButton_Click(object sender, EventArgs e)
        {
            Iata_airport_codes selectedGridItem = (Iata_airport_codes)UiOriginIataCodeGridView.CurrentRow.DataBoundItem;
            selectedDestination = selectedGridItem.Code;
            fr.Destination = selectedDestination;
            RefreshRouteListBox();
        }

        private void UiSearchButton_Click(object sender, EventArgs e)
        {
            string selectedCurrency = UiCurrencyComboBox.SelectedValue.ToString();
            TaskFactory tf = new TaskFactory();
            TableFilling(tf.StartNew(() => GetDataFromAmadeusWebService(accessToken, selectedCurrency)).Result.Result);
        }

        private void UiOriginSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            UiOriginIataCodeGridView.DataSource = null;
            UiOriginIataCodeGridView.DataSource = DataBaseOp.FetchSpecificIataCodes(UiOriginSearchTextBox.Text);
        }
    }
}
