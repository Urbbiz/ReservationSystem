using ReservationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Services
{
    public class ReservationService
    {

        private readonly DataContext _context;

        public ReservationService(DataContext context)
        {
            _context = context;
        }

        public string ReservationNumbGenerator()
        {
            var random = new Random();
           var code = $"LT{random.Next(100000,999999)}";
           if (this.IsReservationNumberUnique(code) == false)
            {
                return this.ReservationNumbGenerator(); 
            } 
           return code;
        }

        public bool IsReservationNumberUnique(string reservationNumber)
        {
            var answer =_context.Reservations.FirstOrDefault(r => r.ReservationNumber == reservationNumber);

            return answer == null;
           
            
        }
    }
}