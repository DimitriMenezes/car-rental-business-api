﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Car.Rental.Business.Domain.Entities.Auth
{    
    public class Client : Base
    {        
        public string Cpf { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
