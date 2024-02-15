using Microsoft.EntityFrameworkCore;
using NationalPark_API_C3.Models;

namespace NationalPark_API_C3.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<NationalPark>NationalParks { get; set; }
        public DbSet<Trail>Trails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
