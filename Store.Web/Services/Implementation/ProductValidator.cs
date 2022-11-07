using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Repositories;
using Store.Web.Repositories.Implementation;

namespace Store.Web.Services.Implementation
{
    public class ProductValidator : IProductValidator
    {
        private readonly IProductRepository _productRepository;
        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool ValidateAddRequest(ProductDTO model, ModelStateDictionary modelState)
        {
            if (_productRepository.Exists(model.Name))
            {
                modelState.AddModelError(nameof(model.Name), "Product with the same name already exists");

            }

            return modelState.IsValid;
        }

        public bool ValidateRemoveRequest(int id, ModelStateDictionary modelState)
        {
            if (id == 0)
            {
                modelState.AddModelError(nameof(id), "False parameter");
            }

            if (_productRepository.Exists(id) == false)
            {
                modelState.AddModelError(nameof(id), "This product doesn`t exist");
            }



            return modelState.IsValid;
        }
    }
}
