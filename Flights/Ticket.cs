using System;
using System.Collections.Generic;
using System.Text;

namespace Flights
{
    public class Ticket : Flight
    {
        public string Number { get; set; }
        public string Place { get; set; }
        public string Class { get; set; }
        public int Price { get; set; }
        public DateTime FlightId { get; set; }

        public Ticket(string flightNumber, string departureCity, string arrivalCity, string number, string place, string classs, int price, DateTime flightId)
        {
            this.FlightNumber = flightNumber;
            this.DepartureCity = departureCity;
            this.ArrivalCity = arrivalCity;
            Number = number;
            Place = place;
            Class = classs;
            Price = price;
            FlightId = flightId;
        }

    }
}
