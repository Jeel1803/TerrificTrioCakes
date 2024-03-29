﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerrificTrioCakes.Models.DB
{
    public partial class CartItemFromDatabase
    {
        [Key]
        public int CartItemId { get; set; }
        public int TotalAmount { get; set; }
        public int? CakeId { get; set; }
        public string? ShoppingCartId { get; set; }
        public string? CartId { get; set; }

        public virtual Cake? Cake { get; set; }
    }
}
