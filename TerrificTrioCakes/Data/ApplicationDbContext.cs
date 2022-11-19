using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TerrificTrioCakes.Models;

namespace TerrificTrioCakes.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //List<IdentityRole> roles = new List<IdentityRole>() {
            //         new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            //         new IdentityRole { Name = "Staff", NormalizedName = "STAFF" },
            //        new IdentityRole { Name = "User", NormalizedName = "USER" },
            //         };
            //builder.Entity<IdentityRole>().HasData(roles);

            // Create USERS
            //        var passwordHasher = new PasswordHasher<IdentityUser>();
            //        List<IdentityUser> users = new List<IdentityUser>() {
            //                new IdentityUser {
            //                    UserName = "admin@mail.com",
            //                    NormalizedUserName = "ADMIN@MAIL.COM",
            //                    Email = "admin@mail.com",
            //                    NormalizedEmail = "ADMIN@MAIL.COM",
            //                    EmailConfirmed=true,
            //                },
            //                new IdentityUser {
            //                    UserName = "staff@mail.com",
            //                    NormalizedUserName = "STAFF@MAIL.COM",
            //                    Email = "staff@mail.com",
            //                    NormalizedEmail = "STAFF@MAIL.COM",
            //                    EmailConfirmed=true
            //                },
            //                new IdentityUser {
            //                    UserName = "user@mail.com",
            //                    NormalizedUserName = "USER@MAIL.COM",
            //                    Email = "user@mail.com",
            //                    NormalizedEmail = "USER@MAIL.COM",
            //                    EmailConfirmed=true
            //                }

            //            };
            //        builder.Entity<IdentityUser>().HasData(users);

            //        // Add password to users
            //        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Password@123");
            //        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Password@123");
            //        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Password@123");

            //        //Add roles to user
            //        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            //        userRoles.Add(new IdentityUserRole<string>
            //        {
            //            UserId = users[0].Id,
            //            RoleId = roles.First(q => q.Name == "Admin").Id
            //        });
            //        userRoles.Add(new IdentityUserRole<string>
            //        {
            //            UserId = users[1].Id,
            //            RoleId = roles.First(q => q.Name == "Staff").Id
            //        });
            //        userRoles.Add(new IdentityUserRole<string>
            //        {
            //            UserId = users[2].Id,
            //            RoleId = roles.First(q => q.Name == "User").Id
            //        });

            //        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }

    }
    }