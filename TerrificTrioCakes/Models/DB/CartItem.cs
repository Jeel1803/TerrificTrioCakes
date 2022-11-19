using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.Models.DB
{
    public partial class CartItem
    {
        

        public int CartItemId { get; set; }
        public int TotalAmount { get; set; }
        public int? CakeId { get; set; }
        public string? ShoppingCartId { get; set; }

        [Key]
        public int? CartId { get; set; }

        public virtual Cake? Cake { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
