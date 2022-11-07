using Microsoft.EntityFrameworkCore;
using Store.Web.Data;
using Store.Web.Models.Entities;

namespace Store.Web.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<ProductEntity> GetAll()
        {
            return _dbContext.Products.Select(n => n).ToList();
        }

        public ProductEntity GetOne(int id)
        {
            return _dbContext.Products
               .Include(n => n.Ingredients)
               .FirstOrDefault(n => n.Id == id) ?? new ProductEntity();
        }
        public void Add(ProductEntity model)
        {
            _dbContext.Products.Add(model);
            _dbContext.SaveChanges();
        }
        public void Remove(int id)
        {
            var model = GetOne(id);
            _dbContext.Products.Remove(model);
            _dbContext.SaveChanges();
        }
        public bool Exists(int id)
        {
            return _dbContext.Products.Any(n => n.Id == id);
        }

        public bool Exists(string name)
        {
            return _dbContext.Products.Any(n => n.Name == name);
        }

      

       
    }
}
