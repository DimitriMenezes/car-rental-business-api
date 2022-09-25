using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Data.Repositories.Abstract
{
    public interface IReadOnlyBaseRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
    }
}
