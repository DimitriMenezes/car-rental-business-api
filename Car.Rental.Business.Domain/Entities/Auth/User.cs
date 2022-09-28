using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Auth
{
    [Table("User", Schema="auth")]
    public class User : Base
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string EnrollmentCode { get; set; }
    }
}
