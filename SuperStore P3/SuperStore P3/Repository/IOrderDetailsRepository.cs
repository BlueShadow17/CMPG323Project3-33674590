using Models; // Import the Models namespace to access the OrderDetail model.

namespace EcoPower_Logistics.Repository
{
    // Define an interface named IOrderDetailsRepository that extends the IGenericRepository interface
    // with the OrderDetail model as its generic type parameter.
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        // This interface does not declare any additional members or methods.
        // It inherits the generic repository functionality for the OrderDetail model.
    }
}