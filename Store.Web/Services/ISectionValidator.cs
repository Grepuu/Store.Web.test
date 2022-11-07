using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;

namespace Store.Web.Services
{
    public interface ISectionValidator
    {
        bool ValidateAddRequest(SectionDTO model, ModelStateDictionary modelState);
        bool ValidateRemoveRequest(int id, ModelStateDictionary modelState);
    }
}
