using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Repositories;
using Store.Web.Repositories.Implementation;

namespace Store.Web.Services.Implementation
{
    public class IngredientValidator : IIngredientValidator   
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientValidator(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public bool ValidateAddRequest(IngredientDTO model, ModelStateDictionary modelState)
        {
            if (_ingredientRepository.Exists(model.Name))
            {
                modelState.AddModelError(nameof(model.Name), "Ingredient with the same name already exists");

            }

            return modelState.IsValid;
        }

        public bool ValidateRemoveRequest(int id, ModelStateDictionary modelState)
        {
            if (id == 0)
            {
                modelState.AddModelError(nameof(id), "False parameter");
            }

            if (_ingredientRepository.Exists(id) == false)
            {
                modelState.AddModelError(nameof(id), "This ingredient doesn`t exist");
            }



            return modelState.IsValid;
        }
    }
}
