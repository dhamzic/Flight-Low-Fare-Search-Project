using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingICT_Project
{
    public class DataBaseOp : FlightsDBEntities
    {
        /// <summary>
        /// This function fetches Iata airport codes from a database
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public BindingList<Iata_airport_codes> FetchSpecificIataCodes(string keyWord)
        {
            BindingList<Iata_airport_codes> listOfIataCodes = null;
            using (var db = new FlightsDBEntities())
            {

                if (string.IsNullOrEmpty(keyWord))
                {
                    listOfIataCodes = new BindingList<Iata_airport_codes>(db.Iata_airport_codes.ToList());

                }
                else
                {
                    var findSpecificCode = db.Iata_airport_codes.Where(a => a.Airport.Contains(keyWord)).ToList();
                    listOfIataCodes = new BindingList<Iata_airport_codes>(findSpecificCode);

                }
            }
            return listOfIataCodes;

        }
        /// <summary>
        /// This functions inserts returned flights data from Amadeus Web Service
        /// </summary>
        /// <param name="listOfFlights"></param>
        public void InsertFlights(List<Flights> listOfFlights)
        {
            using (var db = new FlightsDBEntities())
            {
                foreach (var flight in listOfFlights)
                {
                    db.Flights.Add(flight);
                }
                db.SaveChanges();
            }


        }

        /// <summary>
        /// This function fetches familiar flights from database. In the case of repeated search, the app fetches from local database.
        /// </summary>
        /// <param name="insertedArguments"></param>
        /// <returns></returns>
        public List<Flights> FetchFlights(Flights insertedArguments)
        {
            List<Flights> listOfFetchedFlights = new List<Flights>();
            using (var db = new FlightsDBEntities())
            {
                var condition = db.Flights.Where(f => f.Origin == insertedArguments.Origin && f.Destination == insertedArguments.Destination && f.Currency == insertedArguments.Currency && f.DepartureDate == insertedArguments.DepartureDate && f.ReturnDate == insertedArguments.ReturnDate);
                listOfFetchedFlights = new List<Flights>(condition);
            }

            return listOfFetchedFlights;
        }
    }

}
