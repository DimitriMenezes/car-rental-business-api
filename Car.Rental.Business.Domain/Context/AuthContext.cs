using Car.Rental.Business.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Car.Rental.Business.Domain.Context
{
    public partial class AuthContext : DbContext
    {
        public DbSet<User> User { get; set; }        

        public AuthContext()
        {
        }
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
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
