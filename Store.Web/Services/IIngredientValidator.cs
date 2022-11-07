using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;

namespace Store.Web.Services
{
    public interface IIngredientValidator
    {
        bool ValidateAddRequest(IngredientDTO model, ModelStateDictionary modelState);
        bool ValidateRemoveRequest(int id, ModelStateDictionary modelState);
    }
}
