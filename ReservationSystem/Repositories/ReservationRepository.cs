using ReservationSystem.Data;
using ReservationSystem.Models;
using ReservationSystem.Services;
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
        private readonly ReservationService _service;

        public ReservationRepository(DataContext context, ReservationService service)
        {
            _context = context;
            _service = service;
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public async Task<Reservation> GetById(int Id)
        {
            var model = await _context.Reservations.FindAsync(Id);
            return model;
        }

        public async Task Post(Reservation reservation)
        {
            reservation.ReservationNumber = _service.ReservationNumbGenerator();

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Reservation reservation)
        {
            
            var entity = _context.Reservations.Find(reservation.Id);
            _context.Entry(entity).CurrentValues.SetValues(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var reservationToDelete = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationToDelete);
            await _context.SaveChangesAsync();
        }


    }
}