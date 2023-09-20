using Models; // Import the Models namespace to access the Customer model.

namespace EcoPower_Logistics.Repository
{
    // Define an interface named ICustomerRepository that extends the IGenericRepository interface
    // with the Customer model as its generic type parameter.
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // This interface does not declare any additional members or methods.
        // It inherits the generic repository functionality for the Customer model.
    }
}
