﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Models;
using TerrificTrioCakes.Models.DB;

namespace TerrificTrioCakes.Controllers
{
    public class OrderController : Controller
    {
        private readonly CakeShopContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(CakeShopContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult CheckOut()
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            return RedirectToAction("Index");
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }

        //Code to clear the session when the payment is approved. This method is called in the onApprove() in the javascript of the PayPal API. This method will redirect user to the Homepage
        public IActionResult Clear()
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                MemberShip member = new MemberShip()
                {
                    
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Membership = user.Membership,
                    MembershipDuration = user.MembershipDuration,
                    MembershipExpiry = user.MembershipExpiry
                };

                if (member.Membership == "gold" && member.MembershipExpiry > DateTime.Now)
                {
                    ViewBag.Cart = cart;

                    //Hosam: string message to display the discount amount to each user
                    string msg = "As a Gold member - Your order includes a 14% Discount";

                    //Akhil: calculations of doscount and total for each member
                    double discount = 0.14;
                    decimal total = cart.Sum(item => item.Cake.Price * item.Quantity) * decimal.Parse(discount.ToString());
                    decimal discounted = cart.Sum(item => item.Cake.Price * item.Quantity) - total;

                    ViewBag.msg = msg;
                    ViewBag.total = Math.Round(discounted, 2);
                    ViewBag.Discount = Math.Round(discount * 100, 2);
                }
                else if (member.Membership == "silver" && member.MembershipExpiry > DateTime.Now)
                {
                    ViewBag.Cart = cart;

                    //Hosam: string message to display the discount amount to each user
                    string msg = "As a Silver member - Your order includes a 9% Discount";

                    //Akhil: calculations of doscount and total for each member
                    double discount = 0.09;
                    decimal total = cart.Sum(item => item.Cake.Price * item.Quantity) * decimal.Parse(discount.ToString());
                    Math.Round(total, 2);
                    decimal discounted = cart.Sum(item => item.Cake.Price * item.Quantity) - total;

                    ViewBag.msg = msg;
                    ViewBag.total = Math.Round(discounted, 2);
                    ViewBag.Discount = Math.Round(discount * 100, 2);
                }
                else if (member.Membership == "bronze" && member.MembershipExpiry > DateTime.Now)
                {
                    ViewBag.Cart = cart;

                    //Hosam: string message to display the discount amount to each user
                    string msg = "As a Bronze member - Your order includes a 6% Discount";

                    //Akhil: calculations of doscount and total for each member
                    double discount = 0.06;
                    decimal total = cart.Sum(item => item.Cake.Price * item.Quantity) * decimal.Parse(discount.ToString());
                    Math.Round(total, 2);
                    decimal discounted = cart.Sum(item => item.Cake.Price * item.Quantity) - total;

                    //returning discount message using viewBag
                    ViewBag.msg = msg;
                    ViewBag.total = Math.Round(discounted, 2);
                    ViewBag.Discount = Math.Round(discount * 100, 2);
                }
                else
                {
                    ViewBag.Cart = cart;

                    decimal total = cart.Sum(item => item.Cake.Price * item.Quantity);

                    ViewBag.total = Math.Round(total, 2);
                }

            }
            else if (cart == null)
                ViewBag.Empty = "Empty";


            return View();
        }

       
        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Address,Email,FirstName,LastName,OrderTotal,Phone,UserId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Address,Email,FirstName,LastName,OrderTotal,Phone,UserId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'CakeShopContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
