using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities
{
    [Table("Reservation", Schema = "business")]
    public class Reservation : Base
    {
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalPrix { get; set; }

        public virtual Inspection Inspection { get; set; }
    }
}
