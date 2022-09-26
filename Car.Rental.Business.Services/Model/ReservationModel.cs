using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.Model
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? TotalPrix { get; set; }
    }
}
