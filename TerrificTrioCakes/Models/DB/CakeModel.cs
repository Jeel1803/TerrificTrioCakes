namespace TerrificTrioCakes.Models.DB
{
    public class CakeModel
    {
        public List<Cake> cakes { get; set; }

        public List<Cake> findAll()
        {
            using (CakeShopContext ctx = new())
            {
                return ctx.Cakes.ToList();
            }
        }

        public Cake find(int id)
        {
            List<Cake> cakes = findAll();
            var cake = cakes.Where(c => c.Id == id).FirstOrDefault();
            return cake;
        }
    }
}
