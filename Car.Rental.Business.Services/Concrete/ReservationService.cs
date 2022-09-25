using AutoMapper;
using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Entities;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IVehicleReadOnlyRepository _vehicleRepository;
        public ReservationService(IReservationRepository reservationRepository, IVehicleReadOnlyRepository vehicleRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> AddReservation(ReservationModel model)
        {
            var vehicle = await _vehicleRepository.GetById(model.VehicleId);
            if (vehicle == null)
                return new ReturnModel { Errors = "Vehicle not found" };

            var reservation = _mapper.Map<Reservation>(model);
            reservation.TotalPrix = PrixCalc(reservation.StartDate, reservation.EndDate.Value, vehicle.HourlyRate);

            await _reservationRepository.Insert(reservation);

            return new ReturnModel { Data = _mapper.Map<Reservation>(reservation) };
        }      

        public async Task<ReturnModel> UpdateReservation(ReservationModel model)
        {
            var vehicle = await _vehicleRepository.GetById(model.VehicleId);
            if (vehicle == null)
                return new ReturnModel { Errors = "Vehicle not found" };

            var oldReservation = await _reservationRepository.GetById(model.ReservationId);
            if(oldReservation == null)
                return new ReturnModel { Errors = "Reservation not found" };
            
            var newReservation = _mapper.Map<Reservation>(model);
            newReservation.TotalPrix = PrixCalc(newReservation.StartDate, newReservation.EndDate.Value, vehicle.HourlyRate);

            await _reservationRepository.Update(newReservation);

            return new ReturnModel { Data = newReservation };
        }

        public async Task<ReturnModel> DeleteReservation(int id)
        {
            try
            {
                await _reservationRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return new ReturnModel { Errors = ex.Message };
            }
            return new ReturnModel { Data = "" };
        }

        public async Task<ReturnModel> GetReservation(int id)
        {
            return new ReturnModel { Data = _mapper.Map<Reservation>(await _reservationRepository.GetById(id)) };
        } 
        
        private decimal PrixCalc(DateTime startDate, DateTime endDate, decimal hourlyRate)
        {
            var hours = (endDate - startDate).TotalHours;
            var totalPrix = (decimal)hours * hourlyRate;
            return totalPrix;
        }
    }
}
