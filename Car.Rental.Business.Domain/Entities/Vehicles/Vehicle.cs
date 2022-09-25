using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Vehicles
{
    public class Vehicle : Base
    {
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TrunkCapacity { get; set; }       
        public Mark Mark { get; set; }
        public Model Model { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
