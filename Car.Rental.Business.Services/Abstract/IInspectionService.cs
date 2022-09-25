using Car.Rental.Business.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Services.Abstract
{
    public interface IInspectionService
    {
        Task<ReturnModel> MakeInspection(InspectionModel model);
    }
}
