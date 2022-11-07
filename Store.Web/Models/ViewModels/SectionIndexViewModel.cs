using Store.Web.Models.DTO;

namespace Store.Web.Models.ViewModels
{
    public class SectionIndexViewModel
    {
        public ICollection<SectionDTO>? Sections { get; set; }
    }
}
