using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventArea> EventAreas { get; set; }
        public DbSet<EventSeat> EventSeats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
