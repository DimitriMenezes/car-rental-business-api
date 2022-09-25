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
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public InspectionService(IInspectionRepository inspectionRepository, IReservationRepository reservationRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReturnModel> MakeInspection(InspectionModel model)
        {
            var reservation = await _reservationRepository.GetById(model.ReservationId);

            if (reservation == null)
                new ReturnModel { Errors = "Reservation not Found" };

            if (model.HasScratches)
                reservation.TotalPrix = reservation.TotalPrix + (reservation.TotalPrix * 0.3m);

            if (model.HasDamages)
                reservation.TotalPrix = reservation.TotalPrix + (reservation.TotalPrix * 0.3m);

            if (!model.FuelFilled)
                reservation.TotalPrix = reservation.TotalPrix + (reservation.TotalPrix * 0.3m);

            if (!model.VehicleClean)
                reservation.TotalPrix = reservation.TotalPrix + (reservation.TotalPrix * 0.3m);

            await _reservationRepository.Update(reservation);

            var inspection = _mapper.Map<Inspection>(model);

            await _inspectionRepository.Insert(inspection);

            return new ReturnModel { Data = _mapper.Map<InspectionModel>(inspection) };
        }
    }
}
