using Car.Rental.Business.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.InMemory;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Concrete;
using Car.Rental.Business.Data.Repositories.Concrete;
using Moq;
using AutoMapper;
using Car.Rental.Business.Services.Mapper;

namespace Car.Rental.Business.Tests.Data
{
    public class Fixture : IDisposable
    {
        public VehicleContext VehicleContext { get; set; }
        public BusinessContext BusinessContext { get; set; }
        public IRentalSimulationService _simulationService { get; set; }
        public IReservationService _reservationService { get; set; }
        public IInspectionService _inspectionService { get; set; }


        public Fixture()
        {
            var options = new DbContextOptionsBuilder<VehicleContext>()
                    .UseInMemoryDatabase("VehicleDB")
                    .Options;

            VehicleContext = new VehicleContext(options);


            var businesseDbOptions = new DbContextOptionsBuilder<BusinessContext>()
                    .UseInMemoryDatabase("BusinessDb")
                    .Options;
            BusinessContext = new BusinessContext(businesseDbOptions);

            var vehicleRepository = new VehicleReadOnlyRepository(VehicleContext);
            var reservationRepository = new ReservationRepository(BusinessContext);
            var inspectionRepository = new InspectionRepository(BusinessContext);

            _simulationService = new RentalSimulationService(vehicleRepository);

            var _mapper = new Mock<IMapper>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            _reservationService = new ReservationService(reservationRepository, vehicleRepository, mapper);

            _inspectionService = new InspectionService(inspectionRepository, reservationRepository, mapper);
        }

        public void Dispose()
        {
            VehicleContext.Dispose();
        }
    }
}
