using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingICT_Project
{

    public class Flight
    {
        public Datum[] data { get; set; }
        public Dictionaries dictionaries { get; set; }
        public Meta meta { get; set; }
        public Warning[] warnings { get; set; }
    }

    public class Dictionaries
    {
        public Currencies currencies { get; set; }
        public Locations locations { get; set; }
    }

    public class Currencies
    {
        public string EUR { get; set; }
    }

    public class Locations
    {
        public MAD MAD { get; set; }
        public MUC MUC { get; set; }
    }

    public class MAD
    {
        public string subType { get; set; }
        public string detailedName { get; set; }
    }

    public class MUC
    {
        public string subType { get; set; }
        public string detailedName { get; set; }
    }

    public class Meta
    {
        public string currency { get; set; }
        public Links links { get; set; }
        public Defaults defaults { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
    }

    public class Defaults
    {
        public string departureDate { get; set; }
        public bool oneWay { get; set; }
        public string duration { get; set; }
        public bool nonStop { get; set; }
        public string viewBy { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string departureDate { get; set; }
        public string returnDate { get; set; }
        public Price price { get; set; }
        public Links1 links { get; set; }
    }

    public class Price
    {
        public string total { get; set; }
    }

    public class Links1
    {
        public string flightDestinations { get; set; }
        public string flightOffers { get; set; }
    }

    public class Warning
    {
        public string title { get; set; }
    }

}
