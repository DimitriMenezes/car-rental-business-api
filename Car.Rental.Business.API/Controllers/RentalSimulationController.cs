using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
//using Car.Rental.Vehicles.Management.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Rental.Vehicles.Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalSimulationController : ControllerBase
    {
        private readonly IRentalSimulationService _simulationService;
        public RentalSimulationController(IRentalSimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> AddVehicle(SimulationModel model)
        {           
            var result = await _simulationService.SimulateRentalPrice(model);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}
