using Car.Rental.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Domain.EntitiesMapping
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(i => i.TotalPrix)
                .IsRequired(false);

            //builder.HasOne(i => i.Client)
            //    .WithMany(i => i.Reservations)
            //    .HasForeignKey(i => i.ClientId); 

            //builder.HasOne(i => i.Vehicle)
            //   .WithMany(i => i.Reservations)
            //   .HasForeignKey(i => i.VehicleId);

         
        }
    }
}
