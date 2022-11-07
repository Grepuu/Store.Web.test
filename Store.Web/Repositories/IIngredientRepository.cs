using Store.Web.Models.Entities;

namespace Store.Web.Repositories
{
    public interface IIngredientRepository
    {
        ICollection<IngredientEntity> GetAll();
        IngredientEntity GetOne(int id);
        void Add(IngredientEntity model);
        void Remove(int id);
        bool Exists(int id);
        bool Exists(string name);
    }
}
