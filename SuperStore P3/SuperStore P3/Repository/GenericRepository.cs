using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context;

        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            //T does not have parameter Id so must use Primary Key!
            var entityType = _context.Model.FindEntityType(typeof(T));
            var pK = entityType.FindPrimaryKey();
            if (pK != null && pK.Properties.Count == 1)
            {
                var primaryKeyPropertyName = pK.Properties[0].Name;
                return _context.Set<T>().Any(e => EF.Property<int>(e, primaryKeyPropertyName) == id);
            }
            else
            {
                throw new InvalidOperationException("Entity must have a primary key property for this method to work!");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
