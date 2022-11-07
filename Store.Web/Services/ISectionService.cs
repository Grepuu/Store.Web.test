using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Models.ViewModels;

namespace Store.Web.Services
{
    public interface ISectionService 
    {
        SectionIndexViewModel List();
        SectionDetailsViewModel Details(int id);
        void Add(SectionDTO model, ModelStateDictionary modelState);
        void Remove(int id, ModelStateDictionary modelState);
    }
}
