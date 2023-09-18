using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly SuperStoreContext _context;
        CustomerRepository customerRepository = new CustomerRepository();

        public CustomersController(SuperStoreContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var resluts = customerRepository.GetAll();

            return View(resluts);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await customerRepository.GetCustomerByIdAsync(id.Value);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await customerRepository.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = customerRepository.GetCustomerById(id.Value);
            if (results == null)
            {
                return NotFound();
            }
            return View(results);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await customerRepository.UpdateCustomerAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!customerRepository.CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await customerRepository.GetCustomerByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            await customerRepository.DeleteCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return customerRepository.CustomerExists(id);
        }
    }
}
