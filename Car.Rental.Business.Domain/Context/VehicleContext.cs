using Car.Rental.Business.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Business.Domain.Context
{
    public partial class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicle { get; }

        public VehicleContext()
        {
        }
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("vehicle");            
        }
    }
}
