
using System;

public class Flight
{
    public Datum[] data { get; set; }
    public Dictionaries dictionaries { get; set; }
    public Meta meta { get; set; }
}

public class Dictionaries
{
    public Carriers carriers { get; set; }
    public Currencies currencies { get; set; }
    public Aircraft aircraft { get; set; }
    public Locations locations { get; set; }
}

public class Carriers
{
    public string _6X { get; set; }
    public string UX { get; set; }
    public string VY { get; set; }
    public string JN { get; set; }
    public string AF { get; set; }
    public string LX { get; set; }
    public string CT { get; set; }
    public string AZ { get; set; }
    public string IB { get; set; }
    public string _2L { get; set; }
    public string NI { get; set; }
    public string LH { get; set; }
    public string TP { get; set; }
}

public class Currencies
{
    public string EUR { get; set; }
}

public class Aircraft
{
    public string _319 { get; set; }
    public string _320 { get; set; }
    public string _321 { get; set; }
    public string _777 { get; set; }
    public string CS1 { get; set; }
    public string _32A { get; set; }
    public string CS3 { get; set; }
    public string E75 { get; set; }
    public string _32S { get; set; }
    public string _73H { get; set; }
    public string E90 { get; set; }
}

public class Locations
{
    public MAD MAD { get; set; }
    public ZRH ZRH { get; set; }
    public FRA FRA { get; set; }
    public MXP MXP { get; set; }
    public CDG CDG { get; set; }
    public ORY ORY { get; set; }
    public MUC MUC { get; set; }
    public OPO OPO { get; set; }
}

public class MAD
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class ZRH
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class FRA
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class MXP
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class CDG
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class ORY
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class MUC
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class OPO
{
    public string subType { get; set; }
    public string detailedName { get; set; }
}

public class Meta
{
    public Links links { get; set; }
    public string currency { get; set; }
    public Defaults defaults { get; set; }
}

public class Links
{
    public string self { get; set; }
}

public class Defaults
{
    public bool nonStop { get; set; }
    public int adults { get; set; }
}

public class Datum
{
    public string type { get; set; }
    public string id { get; set; }
    public Offeritem[] offerItems { get; set; }
}

public class Offeritem
{
    public Service[] services { get; set; }
    public Price price { get; set; }
    public Priceperadult pricePerAdult { get; set; }
}

public class Price
{
    public string total { get; set; }
    public string totalTaxes { get; set; }
}

public class Priceperadult
{
    public string total { get; set; }
    public string totalTaxes { get; set; }
}

public class Service
{
    public Segment[] segments { get; set; }
}

public class Segment
{
    public Flightsegment flightSegment { get; set; }
    public Pricingdetailperadult pricingDetailPerAdult { get; set; }
}

public class Flightsegment
{
    public Departure departure { get; set; }
    public Arrival arrival { get; set; }
    public string carrierCode { get; set; }
    public string number { get; set; }
    public Aircraft1 aircraft { get; set; }
    public Operating operating { get; set; }
    public string duration { get; set; }
}

public class Departure
{
    public string iataCode { get; set; }
    public string terminal { get; set; }
    public DateTime at { get; set; }
}

public class Arrival
{
    public string iataCode { get; set; }
    public string terminal { get; set; }
    public DateTime at { get; set; }
}

public class Aircraft1
{
    public string code { get; set; }
}

public class Operating
{
    public string carrierCode { get; set; }
    public string number { get; set; }
}

public class Pricingdetailperadult
{
    public string travelClass { get; set; }
    public string fareClass { get; set; }
    public int availability { get; set; }
    public string fareBasis { get; set; }
}
