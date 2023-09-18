using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository
    {
        private readonly SuperStoreContext _context = new SuperStoreContext();

        //Get all orders repo!
        public IEnumerable<Order> GetAll()
        {
           return _context.Orders.ToList();
        }

        //Get orders by detail id repo!
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == id);
        }

        //Create orders repo!
        public async Task CreateOrderAsync(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }


        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        }        

        public async Task UpdateAsync(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
        }
    }
}
