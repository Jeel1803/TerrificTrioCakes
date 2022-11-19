using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Data;
using TerrificTrioCakes.Models;
using TerrificTrioCakes.Models.DB;

namespace TerrificTrioCakes.Controllers
{
    [Authorize]
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
            List<MemberShip> members = new List<MemberShip>();
            if (User.IsInRole("Admin"))
            {

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

                members.Add(member);
                return View(members);
            }
            else
                return View();
        }


    }
}
   
