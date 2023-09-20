using Models; // Import the Models namespace to access the Product model.

namespace EcoPower_Logistics.Repository
{
    // Define an interface named IProductRepository that extends the IGenericRepository interface
    // with the Product model as its generic type parameter.
    public interface IProductRepository : IGenericRepository<Product>
    {
        // This interface does not declare any additional members or methods.
        // It inherits the generic repository functionality for the Product model.
    }
}

