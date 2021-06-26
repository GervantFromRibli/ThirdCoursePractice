using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement.Models;

namespace TicketManagement.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<EventArea> EventAreas { get; set; }
        public DbSet<EventSeat> EventSeats { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
