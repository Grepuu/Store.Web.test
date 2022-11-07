using Microsoft.EntityFrameworkCore;
using Store.Web.Data;
using Store.Web.Models.Entities;

namespace Store.Web.Repositories.Implementation
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public IngredientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<IngredientEntity> GetAll()
        {
            return _dbContext.Ingredients.Select(n => n).ToList();
        }

        public IngredientEntity GetOne(int id)
        {
            return _dbContext.Ingredients
            .FirstOrDefault(n => n.Id == id) ?? new IngredientEntity();
        }
        public void Add(IngredientEntity model)
        {
            _dbContext.Ingredients.Add(model);
            _dbContext.SaveChanges();
        }
        public void Remove(int id)
        {
            var model = GetOne(id);
            _dbContext.Ingredients.Remove(model);
            _dbContext.SaveChanges();
        }
        public bool Exists(int id)
        {
            return _dbContext.Ingredients.Any(n => n.Id == id);
        }

        public bool Exists(string name)
        {
            return _dbContext.Ingredients.Any(n => n.Name == name);
        }

      

     
    }
}
