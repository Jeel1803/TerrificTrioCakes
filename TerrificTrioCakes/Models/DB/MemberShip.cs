using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.Models.DB
{
    public partial class MemberShip
    {
        

        public string Id { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string Membership { get; set; } = null!;

        [Display(Name = "Membership Expiry")]
        public DateTime MembershipExpiry { get; set; }

        [Display(Name = "Membership Duration")]
        public int MembershipDuration { get; set; }

    }
}
