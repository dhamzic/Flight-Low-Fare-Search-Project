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
    }

}
