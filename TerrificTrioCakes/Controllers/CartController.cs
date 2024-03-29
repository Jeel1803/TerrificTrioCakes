﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Models;
using TerrificTrioCakes.Models.DB;

namespace TerrificTrioCakes.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly CakeShopContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(CakeShopContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Action method to add cakes to the cart
        public IActionResult Buy(int id)
        {
            CakeModel cakeModel = new CakeModel();
            //Checking if the cart is null?
            if (SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart") == null)
            {
                //Creting a list of cartitems using session helper class
                List<CartItems> cart = new List<CartItems>();
                cart.Add(new CartItems { Cake = cakeModel.find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItems { Cake = cakeModel.find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        //Action method to prompt user to the checkout
        public IActionResult CheckOut()
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return View();
        }

        //Code to increase the quantity of the cakes added in the cart
        public IActionResult Add(int id)
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        //Code to decrease the quantity of the cakes added in the cart

        public IActionResult decrese(int id)
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            int index = isExist(id);
            //if the cake with same id exists in the cart, it will addd up the quaantity
            if (index != -1)
            {
                //making sure it doesn't go under 1
                if (cart[index].Quantity > 1)
                    cart[index].Quantity--;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        //Code to Remove particular cakes added in the cart

        public IActionResult Remove(int id)
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart.RemoveAt(index);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        //Checking if the cake with same id exists in the cart
        private int isExist(int id)
        {
            List<CartItems> cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Cake.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // GET: Cart


        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItems>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                //fetching the current user
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

                //Conditions to check the subscription of current user and calculating discount based on membership
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
                    ViewBag.total = Math.Round(discounted,2);
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

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Cake)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["CakeId"] = new SelectList(_context.Cakes, "Id", "Id");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,TotalAmount,CakeId,ShoppingCartId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CakeId"] = new SelectList(_context.Cakes, "Id", "Id", cart.CakeId);
            return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["CakeId"] = new SelectList(_context.Cakes, "Id", "Id", cart.CakeId);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,TotalAmount,CakeId,ShoppingCartId")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
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
            ViewData["CakeId"] = new SelectList(_context.Cakes, "Id", "Id", cart.CakeId);
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Cake)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'CakeShopContext.Carts'  is null.");
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
