using System; // Import the System namespace.
using System.Collections.Generic; // Import the System.Collections.Generic namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.
using Microsoft.AspNetCore.Authorization; // Import the Microsoft.AspNetCore.Authorization namespace.
using Microsoft.AspNetCore.Mvc; // Import the Microsoft.AspNetCore.Mvc namespace.
using Microsoft.AspNetCore.Mvc.Rendering; // Import the Microsoft.AspNetCore.Mvc.Rendering namespace.
using Microsoft.EntityFrameworkCore; // Import the Microsoft.EntityFrameworkCore namespace.
using Models; // Import the Models namespace to access the Order model.
using Data; // Import the Data namespace to access the SuperStoreContext.
using EcoPower_Logistics.Repository; // Import the repository namespace.

namespace Controllers
{
    // A controller class for handling order-related actions, requiring authentication.
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerRepository _customerRepository;

        // Constructor for the OrdersController class.
        // It takes a SuperStoreContext, IOrdersRepository, and ICustomerRepository as parameters for database access.
        public OrdersController(SuperStoreContext context, IOrdersRepository ordersRepository, ICustomerRepository customerRepository)
        {
            _ordersRepository = ordersRepository;
            _customerRepository = customerRepository;
        }

        // GET: Orders - Displays a list of orders.
        public async Task<IActionResult> Index()
        {
            var results = _ordersRepository.GetAll();
            return View(results);
        }

        // GET: Orders/Details/5 - Displays details of a specific order.
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

        // GET: Orders/Create - Displays a form to create a new order.
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerId");
            return View();
        }

        // POST: Orders/Create - Handles the creation of a new order.
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

        // GET: Orders/Edit/5 - Displays a form to edit an existing order.
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

        // POST: Orders/Edit/5 - Handles the update of an existing order.
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

        // GET: Orders/Delete/5 - Displays a confirmation page for deleting an order.
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

        // POST: Orders/Delete/5 - Handles the deletion of an order.
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

