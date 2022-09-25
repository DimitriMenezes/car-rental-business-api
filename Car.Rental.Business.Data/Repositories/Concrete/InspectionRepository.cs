using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public class InspectionRepository : BaseRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(DbContext context) : base(context)
        {
        }
    }
}
