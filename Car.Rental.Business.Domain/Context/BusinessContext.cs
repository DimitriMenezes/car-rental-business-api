using Car.Rental.Business.Domain.Entities;
using Car.Rental.Business.Domain.EntitiesMapping;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Business.Domain.Context
{
    public partial class BusinessContext : DbContext
    {      
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Inspection> Inspection { get; set; }

        public BusinessContext()
        {
        }
        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("business");            
            modelBuilder.ApplyConfiguration(new InspectionMapping());
            modelBuilder.ApplyConfiguration(new ReservationMapping());
        }
    }
}
