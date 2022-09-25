using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Vehicles
{
    [Table("Mark", Schema = "vehicle")]
    public class Mark : Base
    {
        public string Name { get; set; }        
    }
}
