using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class MemberShip
    {
        public string Id { get; set; } = null!;
        public string Membership { get; set; } = null!;
        public DateTime MembershipExpiry { get; set; }
        public int MembershipDuration { get; set; }
    }
}
