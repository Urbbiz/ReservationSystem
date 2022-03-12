using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReservationSystem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
    }
}