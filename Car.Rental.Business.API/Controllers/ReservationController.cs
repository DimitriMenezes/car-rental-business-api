using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Rental.Business.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> AddReservation(ReservationModel model)
        {
            var result = await _reservationService.AddReservation(model);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}
