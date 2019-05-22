using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingICT_Project
{
    public static class DataBaseOp
    {
        public static BindingList<Iata_airport_codes> FetchSpecificIataCodes(string keyWord)
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
    }
}
