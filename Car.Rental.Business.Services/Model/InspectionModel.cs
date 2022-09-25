using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.Model
{
    public class InspectionModel
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int OperatorId { get; set; }
        public bool VehicleClean { get; set; }
        public bool FuelFilled { get; set; }
        public bool HasScratches { get; set; }
        public bool HasDamages { get; set; }
    }
}
