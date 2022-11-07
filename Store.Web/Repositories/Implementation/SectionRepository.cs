using Microsoft.EntityFrameworkCore;
using Store.Web.Data;
using Store.Web.Models;
using Store.Web.Models.Entities;

namespace Store.Web.Repositories.Implementation
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<SectionEntity> GetAll()
        {
            return _dbContext.Sections.Select(n => n).ToList();
        }

        public SectionEntity GetOne(int id)
        {
            return _dbContext.Sections
                .Include(n => n.Products)
                .FirstOrDefault(n => n.Id == id) ?? new SectionEntity();
        }

        public void Add(SectionEntity model)
        {
            _dbContext.Sections.Add(model);
            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var model = GetOne(id);
            _dbContext.Sections.Remove(model);
            _dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _dbContext.Sections.Any(n => n.Id == id);
        }

        public bool Exists(string name)
        {
            return _dbContext.Sections.Any(n => n.Name == name);
        }
    }
}
