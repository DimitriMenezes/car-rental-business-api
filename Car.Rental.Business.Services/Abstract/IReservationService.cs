using Car.Rental.Business.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Services.Abstract
{
    public interface IReservationService
    {
        Task<ReturnModel> AddReservation(ReservationModel model);
        Task<ReturnModel> UpdateReservation(ReservationModel model);
        Task<ReturnModel> DeleteReservation(int id);
        Task<ReturnModel> GetReservation(int id);
    }
}
