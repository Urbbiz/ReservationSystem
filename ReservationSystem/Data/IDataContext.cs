using ReservationSystem.Models;
using System.Data.Entity;

namespace ReservationSystem.Data
{
    public interface IDataContext
    {
        DbSet<Reservation> Reservations { get; set; }
    }
}