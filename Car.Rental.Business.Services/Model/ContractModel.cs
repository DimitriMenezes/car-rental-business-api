using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.Model
{
    public class ContractModel
    {
        public DateTime CurrentDate { get; set; }
        public string ClientName { get; set; }
        public string ClientCpf { get; set; }
        public string Vehicle { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public string Plate { get; set; }
        public int Year { get; set; }

    }
}
