using Store.Web.Models.DTO;
using Store.Web.Models.Entities;

namespace Store.Web.Models.ViewModels
{
    public class SectionDetailsViewModel
    {
        public SectionDTO? Section { get; set; }
        public ProductEntity? Product { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }

    }
}
