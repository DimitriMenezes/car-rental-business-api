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
            //builder.HasOne(i => i.Operator)
            //    .WithMany(i => i.Inspections)
            //    .HasForeignKey(i => i.OperatorId);
            builder.HasOne(i => i.Reservation);
        }
    }
}
