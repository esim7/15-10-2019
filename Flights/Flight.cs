using System;
using System.Collections.Generic;
using System.Text;

namespace Flights
{
    public class Flight : Entity
    {
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartuteTime { get; set; } = DateTime.Now;
        public DateTime ArrivalTime { get; set; } = DateTime.Now;

        public Flight(string flightNumber, string departureCity, string arrivalCity)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartuteTime = departuteTime;
            ArrivalTime = arrivalTime;
        }
    }
}
