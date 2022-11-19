using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Data;
using TerrificTrioCakes.Models;
using TerrificTrioCakes.Models.DB;

namespace TerrificTrioCakes.Controllers
{
    public class MemberShipController : Controller
    {
        private readonly CakeShopContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public MemberShipController(CakeShopContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Membership
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                List<MemberShip> members = new List<MemberShip>();
                var users = _context.AspNetUsers.ToList();
                foreach (var u in users)
                {
                    MemberShip member = new MemberShip
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Membership = u.Membership,
                        MembershipDuration = u.MembershipDuration,
                        MembershipExpiry = u.MembershipExpiry
                    };
                    members.Add(member);
                }

                return View(members);
            }
            else if (User.Identity.IsAuthenticated)
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

                return View(member);
            }
            else
                return View();
        }

        // GET: Membership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MemberShips == null)
            {
                return NotFound();
            }

            var memberships = await _context.MemberShips
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (memberships == null)
            {
                return NotFound();
            }

            return View(memberships);
        }

        // GET: Membership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membership/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Membership,MembershipExpiry,MembershipDuration")] MemberShip memberships)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberships);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberships);
        }

        // GET: Membership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.MemberShips == null)
            {
                return NotFound();
            }

            var memberships = await _context.MemberShips.FindAsync(id);
            if (memberships == null)
            {
                return NotFound();
            }
            return View(memberships);
        }

        // POST: Membership/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Membership,MembershipExpiry,MembershipDuration")] MemberShip memberships)
        {
            if (id.ToString() != memberships.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberships);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipsExists(int.Parse(memberships.Id)))
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
            return View(memberships);
        }

        // GET: Membership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MemberShips == null)
            {
                return NotFound();
            }

            var memberships = await _context.MemberShips
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (memberships == null)
            {
                return NotFound();
            }

            return View(memberships);
        }

        // POST: Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberShips == null)
            {
                return Problem("Entity set 'CakeShopContext.Memberships'  is null.");
            }
            var memberships = await _context.MemberShips.FindAsync(id);
            if (memberships != null)
            {
                _context.MemberShips.Remove(memberships);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipsExists(int id)
        {
            return _context.MemberShips.Any(e => e.Id == id.ToString());
        }
    }
}
