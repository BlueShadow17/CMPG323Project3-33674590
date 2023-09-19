using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(SuperStoreContext context, IOrdersRepository ordersRepository, ICustomerRepository customerRepository)
        {
            _ordersRepository = ordersRepository;
            _customerRepository = customerRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var results = _ordersRepository.GetAll();
            return View(results);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _ordersRepository.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            ModelState.Remove("Customer");

            if (ModelState.IsValid)
            {
                await _ordersRepository.AddAsync(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _ordersRepository.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            ModelState.Remove("Customer");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ordersRepository.UpdateAsync(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ordersRepository.EntityExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _ordersRepository.GetByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_ordersRepository.EntityExists(id))
            {
                return NotFound();
            }

            await _ordersRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

