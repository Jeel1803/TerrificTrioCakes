using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class CakeIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int CakeId { get; set; }

        public virtual Cake Cake { get; set; } = null!;
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
