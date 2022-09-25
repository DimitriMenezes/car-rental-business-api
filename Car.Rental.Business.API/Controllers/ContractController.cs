using Car.Rental.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Car.Rental.Business.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost("{reservationId}")]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> GenerateContract(int reservationId)
        {
            try
            {
                var bytes = await _contractService.GenerateContract(reservationId);

                return File(bytes, "application/pdf", "Car Rental Reservation Contract");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
