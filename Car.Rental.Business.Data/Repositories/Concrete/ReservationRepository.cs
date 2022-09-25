using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Context;
using Car.Rental.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public class ReservationRepository : BaseRepository<Reservation> , IReservationRepository
    {
        public ReservationRepository(BusinessContext context) : base(context)
        {

        }
    }
}
