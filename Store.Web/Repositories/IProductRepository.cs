using Store.Web.Models.Entities;

namespace Store.Web.Repositories
{
    public interface IProductRepository
    {
        ICollection<ProductEntity> GetAll();
        ProductEntity GetOne(int id);
        void Add(ProductEntity model);
        void Remove(int id);
        bool Exists(int id);
        bool Exists(string name);
    }
}
