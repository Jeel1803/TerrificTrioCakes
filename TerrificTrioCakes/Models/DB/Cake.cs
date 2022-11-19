using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Cake
    {
        public Cake()
        {
            CakeIngredients = new HashSet<CakeIngredient>();
            CartItems = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public int CategoriesId { get; set; }
        public bool IsFeatured { get; set; }

        public virtual Category Categories { get; set; } = null!;
        public virtual ICollection<CakeIngredient> CakeIngredients { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
