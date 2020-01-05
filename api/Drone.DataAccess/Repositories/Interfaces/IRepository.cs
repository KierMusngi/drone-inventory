using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drone.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        void Update(T entity);

        void Remove(T entity);
    }
}
