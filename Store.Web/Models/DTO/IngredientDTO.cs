using Store.Web.Models.Entities;

namespace Store.Web.Models.DTO
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mass { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO? Product { get; set; }
    }
}
