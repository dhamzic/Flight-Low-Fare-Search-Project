using KingICT_Project.Flight_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public string SelectedOrigin;
        public string SelectedDestination;
        private string accessToken;
        public UiMainForm()
        {
            accessToken = GetAuthorizationData().Result;
            InitializeComponent();
            ControLInitialSettings();

            

        }

        private void ControLInitialSettings()
        {
            UiDepartureDateTimePicker.MinDate = DateTime.Now;
            UiReturnDateTimePicker.MinDate = DateTime.Now;
        }

        private void TableFilling(Flight flightsObject)
        {
            UiSearchResultDataGridView.DataSource = null;

            if (flightsObject.Data!=null)
            {
                List<FlightsGridView> listOfFlights = new List<FlightsGridView>();
                foreach (var flight in flightsObject.Data)
                {
                    listOfFlights.Add(new FlightsGridView
                    {
                        ChangesIngoing = flight.OfferItems[0].Services[0].Segments.Count() - 1,
                        ChangesOutgoing = flight.OfferItems[0].Services[1].Segments.Count() - 1,
                        Availability = int.Parse(UiAdultsTextBox.Text) + int.Parse(UiInfantsTextBox.Text) + int.Parse(UiSeniorsTextBox.Text) + int.Parse(UiChildrenTextBox.Text),
                        Price = double.Parse(flight.OfferItems[0].Price.Total)
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
        private async Task<Flight> GetDataFromAmadeusWebService(string accessToken)
        {
            Flight flightsObject = new Flight();

            string pageUrl = @"https://test.api.amadeus.com/v1/shopping/flight-offers?destination=PAR&departureDate=2019-08-01&origin=ZAG&returnDate=2019-08-28";
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
                        MessageBox.Show(flightsObject.Errors[0].detail, flightsObject.Errors[0].title);
                    }
                }
            }
            return flightsObject;
        }

        private void UiOriginButton_Click(object sender, EventArgs e)
        {

        }

        private void UiDestinationButton_Click(object sender, EventArgs e)
        {

        }

        private void UiSearchButton_Click(object sender, EventArgs e)
        {
            
            TaskFactory tf = new TaskFactory();
            TableFilling(tf.StartNew(() => GetDataFromAmadeusWebService(accessToken)).Result.Result);
        }
       
    }
}
