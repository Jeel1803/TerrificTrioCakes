using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int TotalAmount { get; set; }
        public int? CakeId { get; set; }
        public string? ShoppingCartId { get; set; }

        public virtual Cake? Cake { get; set; }
    }
}
