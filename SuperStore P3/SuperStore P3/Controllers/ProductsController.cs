using System; // Import the System namespace.
using System.Linq; // Import the System.Linq namespace.
using System.Threading.Tasks; // Import the System.Threading.Tasks namespace.
using Microsoft.AspNetCore.Authorization; // Import the Microsoft.AspNetCore.Authorization namespace.
using Microsoft.AspNetCore.Mvc; // Import the Microsoft.AspNetCore.Mvc namespace.
using Microsoft.EntityFrameworkCore; // Import the Microsoft.EntityFrameworkCore namespace.
using Data; // Import the Data namespace to access the SuperStoreContext.
using Models; // Import the Models namespace to access the Product model.
using EcoPower_Logistics.Repository; // Import the repository namespace.

namespace Controllers
{
    // A controller class for handling product-related actions, requiring authentication.
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        // Constructor for the ProductsController class.
        // It takes a SuperStoreContext and an IProductRepository parameter for database access.
        public ProductsController(SuperStoreContext context, IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Products - Displays a list of products.
        public IActionResult Index()
        {
            var results = _productRepository.GetAll();
            return View(results);
        }

        // GET: Products/Details/5 - Displays details of a specific product.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _productRepository.GetByIdAsync(id.Value);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Products/Create - Displays a form to create a new product.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create - Handles the creation of a new product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5 - Displays a form to edit an existing product.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _productRepository.GetByIdAsync(id.Value);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Products/Edit/5 - Handles the update of an existing product.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,UnitsInStock")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productRepository.EntityExists(product.ProductId))
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
            return View(product);
        }

        // GET: Products/Delete/5 - Displays a confirmation page for deleting a product.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5 - Handles the deletion of a product.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_productRepository.EntityExists(id))
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
