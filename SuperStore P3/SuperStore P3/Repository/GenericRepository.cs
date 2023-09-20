using Data; // Import the Data namespace to access the SuperStoreContext.
using Microsoft.EntityFrameworkCore; // Import the Entity Framework Core namespace.
using System; // Import the System namespace.
using System.Collections.Generic; // Import the System.Collections.Generic namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.

namespace EcoPower_Logistics.Repository
{
    // Define a generic repository class named GenericRepository<T> that implements the IGenericRepository interface.
    // It works with entities of type T and ensures that T is a class.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Protected field to hold the database context.
        protected readonly SuperStoreContext _context;

        // Constructor for the GenericRepository class that takes a SuperStoreContext parameter.
        public GenericRepository(SuperStoreContext context)
        {
            // Initialize the database context using dependency injection.
            _context = context;
        }

        // Retrieve all entities of type T from the repository.
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        // Asynchronously retrieve an entity of type T by its unique identifier.
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Asynchronously add a new entity of type T to the repository.
        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        // Retrieve an entity of type T by its unique identifier.
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // Asynchronously update an entity of type T in the repository.
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // Check if an entity of type T with a specific identifier exists in the repository.
        public bool EntityExists(int id)
        {
            // Check if T has a primary key and use it for the existence check.
            var entityType = _context.Model.FindEntityType(typeof(T));
            var pK = entityType.FindPrimaryKey();
            if (pK != null && pK.Properties.Count == 1)
            {
                var primaryKeyPropertyName = pK.Properties[0].Name;
                return _context.Set<T>().Any(e => EF.Property<int>(e, primaryKeyPropertyName) == id);
            }
            else
            {
                // Throw an exception if the entity doesn't have a primary key.
                throw new InvalidOperationException("Entity must have a primary key property for this method to work!");
            }
        }

        // Asynchronously delete an entity of type T by its identifier.
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
