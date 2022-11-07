using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;

namespace Store.Web.Services
{
    public interface IProductValidator
    {
        bool ValidateAddRequest(ProductDTO model, ModelStateDictionary modelState);
        bool ValidateRemoveRequest(int id, ModelStateDictionary modelState);
    }
}
