using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Context;
using Car.Rental.Business.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public class ClientReadOnlyRepository : ReadOnlyBaseRepository<User> , IClientReadOnlyRepository
    {

        public ClientReadOnlyRepository(AuthContext context) : base(context)
        {
        }
    }
}
