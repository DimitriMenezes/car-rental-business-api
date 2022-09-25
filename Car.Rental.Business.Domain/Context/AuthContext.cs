using Car.Rental.Business.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Business.Domain.Context
{
    public partial class AuthContext : DbContext
    {
        public DbSet<Client> User { get; }

        public AuthContext()
        {
        }
        public AuthContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("auth");
        }
    }
}
