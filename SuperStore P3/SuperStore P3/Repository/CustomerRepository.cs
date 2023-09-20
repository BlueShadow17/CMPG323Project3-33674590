using System; // Import the System namespace.
using System.Collections.Generic; // Import the System.Collections.Generic namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.
using Data; // Import the Data namespace to access the SuperStoreContext.
using Microsoft.EntityFrameworkCore; // Import the Entity Framework Core namespace.
using Models; // Import the Models namespace to access the Customer model.

namespace EcoPower_Logistics.Repository
{
    // Define a class named CustomerRepository that inherits from the GenericRepository<Customer> class
    // and implements the ICustomerRepository interface.
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        // Constructor for the CustomerRepository class.
        // It takes a SuperStoreContext parameter, which is used for database access.
        public CustomerRepository(SuperStoreContext context) : base(context)
        {
            // Initialize the base class (GenericRepository) with the provided context.
        }
    }
}
