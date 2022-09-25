using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities
{
    [Table("Inspection", Schema = "business")]
    public class Inspection : Base
    {
        public int ReservationId { get; set; }
        public int OperatorId { get; set; }
        public bool VehicleClean { get; set; }
        public bool FuelFilled { get; set; }
        public bool HasScratches { get; set; }
        public bool HasDamages { get; set; }

        public virtual Reservation Reservation { get; set; }
        //public virtual Operator Operator { get; }
    }
}
