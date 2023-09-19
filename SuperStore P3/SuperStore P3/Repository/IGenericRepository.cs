using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        T GetById(int id);
        Task UpdateAsync(T entity);
        bool EntityExists(int id);
        Task DeleteAsync(int id);
    }
}
