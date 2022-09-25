using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Services.Concrete
{
    public class RentalSimulationService : IRentalSimulationService
    {
        private readonly IVehicleReadOnlyRepository _vehicleRepository;
        public RentalSimulationService(IVehicleReadOnlyRepository repository)
        {
            _vehicleRepository = repository;
        }
        public async Task<ReturnModel> SimulateRentalPrice(SimulationModel model)
        {
            var vehicle = await _vehicleRepository.GetById(model.VehicleId);
            if (vehicle == null)
                return new ReturnModel { Errors = "Vehicle not found" };

            var hours = (model.EndDate - model.StartDate).TotalHours;            
            var result = (decimal)hours * vehicle.HourlyRate;
            return new ReturnModel { Data = result };
        }
    }
}
