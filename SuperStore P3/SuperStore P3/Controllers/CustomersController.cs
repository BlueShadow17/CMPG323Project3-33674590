using System; // Import the System namespace.
using System.Collections.Generic; // Import the System.Collections.Generic namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.
using Microsoft.AspNetCore.Authorization; // Import the Microsoft.AspNetCore.Authorization namespace.
using Microsoft.AspNetCore.Mvc; // Import the Microsoft.AspNetCore.Mvc namespace.
using Microsoft.AspNetCore.Mvc.Rendering; // Import the Microsoft.AspNetCore.Mvc.Rendering namespace.
using Microsoft.EntityFrameworkCore; // Import the Microsoft.EntityFrameworkCore namespace.
using Data; // Import the Data namespace to access the SuperStoreContext.
using Models; // Import the Models namespace to access the Customer model.
using EcoPower_Logistics.Repository; // Import the repository namespace.

namespace Controllers
{
    // A controller class for handling customer-related actions, requiring authentication.
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        // Constructor for the CustomersController class.
        // It takes a SuperStoreContext and an ICustomerRepository parameter for database access.
        public CustomersController(SuperStoreContext context, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customers - Displays a list of customers.
        public async Task<IActionResult> Index()
        {
            var results = _customerRepository.GetAll();
            return View(results);
        }

        // GET: Customers/Details/5 - Displays details of a specific customer.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _customerRepository.GetByIdAsync(id.Value);
            if (results == null)
            {
                return NotFound();
            }

            return View(results);
        }

        // GET: Customers/Create - Displays a form to create a new customer.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create - Handles the creation of a new customer.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            ModelState.Remove("Customer");

            if (ModelState.IsValid)
            {
                await _customerRepository.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5 - Displays a form to edit an existing customer.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var results = await _customerRepository.GetByIdAsync(id.Value);
            if (results == null)
            {
                return NotFound();
            }
            return View(results);
        }

        // POST: Customers/Edit/5 - Handles the update of an existing customer.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            ModelState.Remove("Customer");

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_customerRepository.EntityExists(customer.CustomerId))
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

        // GET: Customers/Delete/5 - Displays a confirmation page for deleting a customer.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerRepository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5 - Handles the deletion of a customer.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_customerRepository.EntityExists(id))
            {
                return NotFound();
            }

            await _customerRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
