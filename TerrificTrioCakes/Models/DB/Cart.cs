﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int TotalAmount { get; set; }
        public int? CakeId { get; set; }
        public string? ShoppingCartId { get; set; }

        public virtual Cake? Cake { get; set; }


        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
