using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Data.Repositories.Concrete
{
    public abstract class ReadOnlyBaseRepository<TEntity> : IReadOnlyBaseRepository<TEntity> where TEntity : Base
    {
        internal readonly DbContext _context;
        internal DbSet<TEntity> _dbSet;

        protected ReadOnlyBaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await Include().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await Include().FirstOrDefaultAsync(c => c.Id == id);
        }

        public virtual IQueryable<TEntity> Include()
        {
            return _dbSet;
        }
    }
}
