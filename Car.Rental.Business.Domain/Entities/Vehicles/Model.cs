using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Vehicles
{
    [Table("Model", Schema = "vehicle")]
    public class Model : Base
    {
        public string Name { get; set; }

    }
}
