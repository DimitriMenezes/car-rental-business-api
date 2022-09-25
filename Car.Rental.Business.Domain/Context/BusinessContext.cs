using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Business.Domain.Context
{
    public partial class BusinessContext : DbContext
    {      

        public BusinessContext()
        {
        }
        public BusinessContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("business");            
        }
    }
}
