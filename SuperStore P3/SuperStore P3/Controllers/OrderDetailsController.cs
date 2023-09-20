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
using EcoPower_Logistics.Repository; // Import the Repository namespace to access the repositories.

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository; // Inject the OrderDetail repository.
        private readonly IGenericRepository<Order> _ordersRepository; // Inject the Orders repository.
        private readonly IGenericRepository<Product> _productRepository; // Inject the product repository.

        public OrderDetailsController(IGenericRepository<OrderDetail> orderDetailRepository, IGenericRepository<Order> ordersRepository, IGenericRepository<Product> productRepository)
        {
            _orderDetailRepository = orderDetailRepository; // Initialize the OrderDetail repository.
            _ordersRepository = ordersRepository; // Initialize the Orders repository.
            _productRepository = productRepository; // Initialize the Product repository.
        }

        // GET: OrderDetails
        public IActionResult Index()
        {
            // Retrieve all OrderDetails using the OrderDetail repository.
            var orderDetails = _orderDetailRepository.GetAll();
            return View(orderDetails);
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve a specific OrderDetail by ID using the OrderDetail repository.
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            // Populate dropdown lists with Orders and Products using their respective repositories.
            ViewData["OrderId"] = new SelectList(_ordersRepository.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId");
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                // Add a new OrderDetail using the OrderDetail repository.
                await _orderDetailRepository.AddAsync(orderDetail);
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdown lists with Orders and Products if the model is not valid.
            ViewData["OrderId"] = new SelectList(_ordersRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve a specific OrderDetail by ID using the OrderDetail repository.
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            // Repopulate dropdown lists with Orders and Products for editing.
            ViewData["OrderId"] = new SelectList(_ordersRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the OrderDetail using the OrderDetail repository.
                    await _orderDetailRepository.UpdateAsync(orderDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_orderDetailRepository.EntityExists(orderDetail.OrderDetailsId))
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

            // Repopulate dropdown lists with Orders and Products if the model is not valid.
            ViewData["OrderId"] = new SelectList(_ordersRepository.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve a specific OrderDetail by ID using the OrderDetail repository.
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_orderDetailRepository.EntityExists(id))
            {
                return Problem("Entity set 'SuperStoreContext.OrderDetails' is null.");
            }

            // Delete the OrderDetail using the OrderDetail repository.
            await _orderDetailRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _orderDetailRepository.EntityExists(id);
        }
    }
}
