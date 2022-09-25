using AutoMapper;
using Car.Rental.Business.Domain.Entities;
using Car.Rental.Business.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.Mapper
{
    public class ServicesMapperProfile : Profile
    {
        public ServicesMapperProfile()
        {
            CreateMap<ReservationModel, Reservation>()
                .ReverseMap();
            CreateMap<InspectionModel, Inspection>()
                .ReverseMap();
        }
    }
}
