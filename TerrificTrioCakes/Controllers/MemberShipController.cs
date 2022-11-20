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
    //Hosam: Users need to be logged in to access this controller
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

        // Hosam: GET: Membership
        public async Task<IActionResult> Index()
        {
            //creating a new list
            List<MemberShip> members = new List<MemberShip>();

            //condition to find a membership with role admin
            if (User.IsInRole("Admin"))
            {
                //retrieving all users from AspNetUsers table
                var users = _context.AspNetUsers.ToList();
                //loop to find all required fields from AspNetUsers table
                foreach (var u in users)
                {
                    //new object with fields
                    MemberShip member = new MemberShip
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Membership = u.Membership,
                        MembershipDuration = u.MembershipDuration,
                        MembershipExpiry = u.MembershipExpiry
                    };
                    //add found member to the initial new list
                    members.Add(member);
                }

                //return list
                return View(members);
            }

            //if user is authenticated
            else if (User.Identity.IsAuthenticated)
            {
                // find by name
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                //new object with details
                MemberShip member = new MemberShip()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Membership = user.Membership,
                    MembershipDuration = user.MembershipDuration,
                    MembershipExpiry = user.MembershipExpiry
                };

                //add this found member to original list and view it
                members.Add(member);
                return View(members);
            }
            else
                return View();
        }


    }
}
   
