using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public int PersonsCount { get; set; }

        public string ReservationNumber { get; set; }
    }
}