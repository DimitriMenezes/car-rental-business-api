using Car.Rental.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Domain.EntitiesMapping
{
    public class InspectionMapping : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.HasKey(c => c.Id);        
            builder.HasOne(i => i.Reservation)
                .WithOne(i => i.Inspection)
                .HasForeignKey<Inspection>(i => i.ReservationId);
        }
    }
}
