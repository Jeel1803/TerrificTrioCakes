using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int TotalAmount { get; set; }
        public int OrderId { get; set; }
        public int CakeId { get; set; }
        public decimal Price { get; set; }

        public virtual Cake Cake { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
