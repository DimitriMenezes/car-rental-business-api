using Car.Rental.Business.Domain.Entities.Auth;
using Car.Rental.Business.Domain.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities
{
    [Table("Reservation")]
    public class Reservation : Base
    {
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalPrix { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
