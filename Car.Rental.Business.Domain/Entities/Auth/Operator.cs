using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Auth
{    
    public class Operator : User
    {        
        public string EnrollmentCode { get; set; }
        public List<Inspection> Inspections { get; set; }
    }
}
