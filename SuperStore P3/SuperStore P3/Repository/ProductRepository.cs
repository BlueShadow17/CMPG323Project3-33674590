using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository
    {
        private readonly SuperStoreContext _context = new SuperStoreContext();

        //Get all repo!
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
         
        //Get product by detail id repo!
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        //Create repo!
        public async Task AddProductAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        //Edit repo!
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        //Exist repo!
        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        //Delete repo!
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
