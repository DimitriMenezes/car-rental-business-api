using Car.Rental.Business.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Data.Repositories.Abstract
{
    public interface IVehicleReadOnlyRepository : IReadOnlyBaseRepository<Vehicle>
    {
        
    }
}
