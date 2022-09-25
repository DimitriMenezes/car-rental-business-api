using AutoMapper;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Concrete;
using Car.Rental.Business.Services.Mapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.IoC
{
    public static class ServicesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IInspectionService, InspectionService>();
            services.AddScoped<IRentalSimulationService, RentalSimulationService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IContractService, ContractService>();
        }
    }
}
