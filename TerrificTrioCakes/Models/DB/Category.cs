using System;
using System.Collections.Generic;

namespace TerrificTrioCakes.Models.DB
{
    public partial class Category
    {
        public Category()
        {
            Cakes = new HashSet<Cake>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Cake> Cakes { get; set; }
    }
}
