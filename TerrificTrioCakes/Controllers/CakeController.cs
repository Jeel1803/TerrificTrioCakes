using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Models.DB;

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
        public async Task<IActionResult> Index()
        {
            var cakeShopContext = _context.Cakes.Include(c => c.Categories);
            return View(await cakeShopContext.ToListAsync());
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

            if (ModelState.IsValid)
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
