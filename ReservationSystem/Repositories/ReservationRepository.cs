using ReservationSystem.Data;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReservationSystem.Repositories
{
    public class ReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public async Task Post(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}