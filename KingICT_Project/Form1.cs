﻿using KingICT_Project.Flight_classes;
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


        public UiMainForm()
        {
            InitializeComponent();
            string accessToken = GetAuthorizationData().Result;
            TaskFactory tf = new TaskFactory();
            tf.StartNew(() => GetDataFromAmadeusWebService(accessToken));
        }

        /// <summary>
        /// Access Token has an expiring deadline so, every time before fetching data from Amadeus web service, the app needs to fetch newest access token.
        /// </summary>
        private static async Task<string> GetAuthorizationData()
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
        private async void GetDataFromAmadeusWebService(string accessToken)
        {
            string pageUrl = @"https://test.api.amadeus.com/v1/shopping/flight-dates?origin=MAD&destination=MUC";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            using (HttpResponseMessage response = await client.GetAsync(pageUrl))
            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                if (json != null)
                {
                    Flight flightsObject = JsonConvert.DeserializeObject<Flight>(json);
                }
            }
        }
    }
}