using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingICT_Project.Flight_classes
{
    public class FlightsGridView
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int ChangesOutgoing { get; set; }
        public int ChangesIngoing { get; set; }
        public int NumberOfPassengers { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }


    }
}
