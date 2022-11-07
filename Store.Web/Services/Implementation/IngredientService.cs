using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Models.ViewModels;
using Store.Web.Repositories;
using Store.Web.Repositories.Implementation;

namespace Store.Web.Services.Implementation
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientValidator _ingredientValidator;
        public IngredientService(IIngredientRepository ingredientRepository, IIngredientValidator ingredientValidator)
        {
            _ingredientRepository = ingredientRepository;
            _ingredientValidator = ingredientValidator;
        }
        public void Add(IngredientDTO model, ModelStateDictionary modelState)
        {
            if (_ingredientValidator.ValidateAddRequest(model, modelState))
            {
                var dbModel = new IngredientEntity()
                {
                    Name = model.Name,
                    Mass = model.Mass,
                    ProductId = model.ProductId
                };
                _ingredientRepository.Add(dbModel);
            }
        }

        public void Remove(int id, ModelStateDictionary modelState)
        {
            if (_ingredientValidator.ValidateRemoveRequest(id, modelState))
            {
                _ingredientRepository.Remove(id);
            }
        }
    }
}
