using Store.Web.Models.Entities;

namespace Store.Web.Repositories
{
    public interface ISectionRepository
    {
        ICollection<SectionEntity> GetAll();
        SectionEntity GetOne(int id);
        void Add(SectionEntity model);
        void Remove(int id);
        bool Exists (int id);
        bool Exists(string name);
    }
}
