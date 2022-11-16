using Microsoft.AspNetCore.Identity;

namespace TerrificTrioCakes.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Custom Fields

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Membership { get; set; }


    }
}
