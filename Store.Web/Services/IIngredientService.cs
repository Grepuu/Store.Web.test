using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Models.ViewModels;

namespace Store.Web.Services
{
    public interface IIngredientService
    {
        
        void Add(IngredientDTO model, ModelStateDictionary modelState);
        void Remove(int id, ModelStateDictionary modelState);
    }
}
