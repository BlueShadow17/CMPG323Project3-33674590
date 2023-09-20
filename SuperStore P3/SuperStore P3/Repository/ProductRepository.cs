using Data; // Import the Data namespace to access the SuperStoreContext.
using Microsoft.EntityFrameworkCore; // Import the Entity Framework Core namespace.
using Models; // Import the Models namespace to access the Product model.
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    // Define a class named ProductRepository that implements the IProductRepository interface.
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        // Constructor for the ProductRepository class.
        // It takes a SuperStoreContext parameter, which is used for database access.
        public ProductRepository(SuperStoreContext context) : base(context)
        {
            // Initialize the base class (GenericRepository) with the provided context.
        }
    }
}
