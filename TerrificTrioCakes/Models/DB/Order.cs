using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal OrderTotal { get; set; }
        public string Phone { get; set; } = null!;
        public string? UserId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
