using System; // Import the System namespace.
using System.Collections.Generic; // Import the System.Collections.Generic namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.

namespace EcoPower_Logistics.Repository
{
    // Define a generic interface named IGenericRepository that works with entities of type T.
    public interface IGenericRepository<T>
    {
        // Retrieve all entities of type T from the repository.
        IEnumerable<T> GetAll();

        // Asynchronously retrieve an entity of type T by its unique identifier.
        Task<T> GetByIdAsync(int id);

        // Asynchronously add a new entity of type T to the repository.
        Task AddAsync(T entity);

        // Retrieve an entity of type T by its unique identifier.
        T GetById(int id);

        // Asynchronously update an entity of type T in the repository.
        Task UpdateAsync(T entity);

        // Check if an entity of type T with a specific identifier exists in the repository.
        bool EntityExists(int id);

        // Asynchronously delete an entity of type T by its identifier.
        Task DeleteAsync(int id);
    }
}
