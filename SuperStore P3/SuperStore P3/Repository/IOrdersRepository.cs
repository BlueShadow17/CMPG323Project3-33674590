using Models; // Import the Models namespace to access the Order model.

namespace EcoPower_Logistics.Repository
{
    // Define an interface named IOrdersRepository that extends the IGenericRepository interface
    // with the Order model as its generic type parameter.
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        // This interface does not declare any additional members or methods.
        // It inherits the generic repository functionality for the Order model.
    }
}
