using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Vehicles
{
    [Table("Vehicle", Schema = "vehicle")]
    public class Vehicle : Base
    {
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TrunkCapacity { get; set; }       
        public int MarkId { get; set; }
        public int ModelId { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual Mark Mark { get; set; }
        public virtual Model Model { get; set; }
    }
}
