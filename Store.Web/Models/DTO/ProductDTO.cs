using Store.Web.Models.Entities;

namespace Store.Web.Models.DTO
{
    public class ProductDTO
    {
        public int? SectionId {get; set;}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Data { get; set; }
        public ICollection<ProductDTO>? Products;

        public ICollection<IngredientDTO>? Ingredients;
        
    }
}
