using Microsoft.EntityFrameworkCore;
using TicketManagement.Models;

namespace TicketManagement.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<EventArea> EventArea { get; set; }
        public DbSet<EventSeat> EventSeat { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
