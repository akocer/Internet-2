using Uyg.API.Models;

namespace Uyg.API.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetList()
        {
            var products = _context.Products.ToList();
            return products;
        }
        public Product GetById(int id)
        {
            var product =_context.Products.Where(s => s.Id == id).FirstOrDefault();
            return product;
        }
        public void Add(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
        }
        public void Update(Product model)
        {
            _context.Products.Update(model);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product); 
            _context.SaveChanges();
        }
    }
}
