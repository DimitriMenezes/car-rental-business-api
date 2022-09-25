using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Context;
using Car.Rental.Business.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public class UserRepository : ReadOnlyBaseRepository<Client>, IUserRepository
    {
        public UserRepository(AuthContext context) : base(context)
        {

        }
    }
}
