using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository
    {
        private readonly SuperStoreContext _context = new SuperStoreContext();

        //Get all Customers repo!
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        //Get Customers by detail id repo!
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        //Create Customers repo!
        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        //Edit Customers repo!
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        //Exist Customers repo!
        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.CustomerId == id);
        }

        //Delete Customers repo!
        public async Task DeleteCustomerAsync(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result != null)
            {
                _context.Customers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
