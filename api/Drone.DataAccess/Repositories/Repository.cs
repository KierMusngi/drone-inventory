using Drone.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drone.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DroneContext _context;

        public Repository(DroneContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
