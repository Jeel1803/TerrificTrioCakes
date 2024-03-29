﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TerrificTrioCakes.Models.DB;
using X.PagedList;

namespace TerrificTrioCakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly CakeShopContext _context;

        public CakeController(CakeShopContext context)
        {
            _context = context;
        }

        // GET: Cake
        //code for displaying the the cakes as per the search string provided and filtering it through the input from the radio buttons
        public async Task<IActionResult> Index(string searchString, int? page, string radio)
        {
            var pageNumber = page ?? 1;

           
            //searching based on category
            if (!string.IsNullOrEmpty(searchString))
            {
               var cake = _context.Cakes.Where(ck => ck.Name.Contains(searchString)).Include(cat=> cat.Categories);
                return View(cake.ToPagedList(pageNumber, 6));

            }
            if (radio == "Standard")
            {
                var cake = _context.Cakes.Where(ct => ct.Categories.Name == "Standard").Include(c => c.Categories);
                return View(cake.ToPagedList(pageNumber, 10));
            }
            if (radio == "Vegan")
            {
                var cake = _context.Cakes.Where(ct => ct.Categories.Name == "Vegan").Include(c => c.Categories);
                return View(cake.ToPagedList(pageNumber, 10));
            }
            if (radio == "Eggless")
            {
                var cake = _context.Cakes.Where(ct => ct.Categories.Name == "Eggless").Include(c => c.Categories);
                return View(cake.ToPagedList(pageNumber, 10));
            }
            if(string.IsNullOrEmpty(searchString))
            {

                var cake = _context.Cakes.Include(c => c.Categories);
                return View(cake.ToPagedList(pageNumber, 6));
            }


            return RedirectToAction("Index");

        }

        //Code to search the cake as per the search string provided by users in the searchbar
        public string IndexAJAX(string searchString)
        {
            string sql = "SELECT * FROM Cakes WHERE Name LIKE @p0"; 
            string wrapString = "%" + searchString + "%";
            List<Cake> cakes = _context.Cakes.FromSqlRaw(sql, wrapString).ToList();
            string json = JsonConvert.SerializeObject(cakes);
            return json;
        }

        // GET: Cake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            var listOfIngredients = await _context.CakeIngredients.Where(x => x.CakeId == id).Select(x => x.Ingredient.Name).ToListAsync();
            ViewBag.CakeIngredients = listOfIngredients;
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // GET: Cake/Create
        public IActionResult Create()
        {
            ViewData["CategoriesId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Cake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image,Price,CategoriesId,IsFeatured")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesId"] = new SelectList(_context.Categories, "Id", "Id", cake.CategoriesId);
            return View(cake);
        }

        // GET: Cake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            ViewData["CategoriesId"] = new SelectList(_context.Categories, "Id", "Id", cake.CategoriesId);
            return View(cake);
        }

        // POST: Cake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,Price,CategoriesId,IsFeatured")] Cake cake)
        {
            if (id != cake.Id)
            {
                return NotFound();
            }

            if (id == cake.Id)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeExists(cake.Id))
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
            ViewData["CategoriesId"] = new SelectList(_context.Categories, "Id", "Id", cake.CategoriesId);

            return View(cake);
        }

        // GET: Cake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // POST: Cake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cakes == null)
            {
                return Problem("Entity set 'CakeShopContext.Cakes'  is null.");
            }
            var cake = await _context.Cakes.FindAsync(id);
            if (cake != null)
            {
                _context.Cakes.Remove(cake);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeExists(int id)
        {
          return _context.Cakes.Any(e => e.Id == id);
        }
    }
}
