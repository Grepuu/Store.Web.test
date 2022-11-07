using Store.Web.Models.DTO;

namespace Store.Web.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Data { get; set; }
        public SectionEntity? Section { get; set; }
        public int? SectionId { get; set; }

        public ICollection<IngredientEntity>? Ingredients;
    }
}
