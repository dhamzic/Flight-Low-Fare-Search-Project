
using System;

public class Flight
{
    public FlightInfo[] Data { get; set; }
}

public class FlightInfo
{
    public string Type { get; set; }
    public string Id { get; set; }
    public Offeritem[] OfferItems { get; set; }
}

public class Offeritem
{
    public Service[] Services { get; set; }
    public Price Price { get; set; }
}

public class Price
{
    public string Total { get; set; }
    public string TotalTaxes { get; set; }
}

public class Service
{
    public Segment[] Segments { get; set; }
}

public class Segment
{
    public Flightsegment FlightSegment { get; set; }
}

public class Flightsegment
{
    public Departure Departure { get; set; }
    public Arrival Arrival { get; set; }
    public string CarrierCode { get; set; }
    public string Number { get; set; }
    public Aircraft1 Aircraft { get; set; }
    public Operating Operating { get; set; }
    public string Duration { get; set; }
}

public class Departure
{
    public string IataCode { get; set; }
    public string Terminal { get; set; }
    public DateTime At { get; set; }
}

public class Arrival
{
    public string IataCode { get; set; }
    public string Terminal { get; set; }
    public DateTime At { get; set; }
}

public class Aircraft1
{
    public string Code { get; set; }
}

public class Operating
{
    public string CarrierCode { get; set; }
    public string Number { get; set; }
}

public class Pricingdetailperadult
{
    public string TravelClass { get; set; }
    public string FareClass { get; set; }
    public int Availability { get; set; }
    public string FareBasis { get; set; }
}
