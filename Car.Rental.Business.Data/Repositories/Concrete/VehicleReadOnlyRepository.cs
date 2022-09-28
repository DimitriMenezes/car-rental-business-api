using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Context;
using Car.Rental.Business.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public class VehicleReadOnlyRepository : ReadOnlyBaseRepository<Vehicle>, IVehicleReadOnlyRepository
    {
        public VehicleReadOnlyRepository(VehicleContext context) : base(context)
        {
        }
        
        public override async Task<Vehicle> GetById(int id)
        {
            return await _dbSet.Include(i => i.Mark)
                .Include(i => i.Model)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
