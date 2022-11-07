using Store.Web.Models.DTO;
using Store.Web.Models.Entities;

namespace Store.Web.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDTO Product { get; set; }
        public List<IngredientEntity> Ingredients { get; set; }
        public IngredientEntity IngredientToAdd { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
