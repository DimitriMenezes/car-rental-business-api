using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Auth
{
    public class Operator : Base
    {
        public string Name { get; set; }
        public string EnrollmentCode { get; set; }
        public List<Inspection> Inspections { get; set; }
    }
}
