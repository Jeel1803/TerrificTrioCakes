using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            CakeIngredients = new HashSet<CakeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CakeIngredient> CakeIngredients { get; set; }
    }
}
