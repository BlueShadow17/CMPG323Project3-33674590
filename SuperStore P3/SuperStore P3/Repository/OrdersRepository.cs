using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository
    {
        private readonly SuperStoreContext _context = new SuperStoreContext();

        //Get all order repo!
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        //Get order by detail id repo!
        public async Task<Order> GetCustomerByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        //Create order repo!
        public async Task AddOrderAsync(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        //Edit order repo!
        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        //Exist order repo!
        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.OrderId == id);
        }

        //Delete order repo!
        public async Task DeleteOrderAsync(int id)
        {
            var result = await _context.Orders.FindAsync(id);
            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
