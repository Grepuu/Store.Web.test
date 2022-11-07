using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Models.ViewModels;
using Store.Web.Repositories;
using Store.Web.Repositories.Implementation;

namespace Store.Web.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductValidator _productValidator;
        public ProductService(IProductRepository productRepository, IProductValidator productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }

        public ProductDetailsViewModel List()
        {
            var entites = _productRepository.GetAll();
            var viewModel = new ProductDetailsViewModel()
            {
               Products = new List<ProductDTO>()
            };
            viewModel.Products = entites.Select(n => new ProductDTO
            {
              Id = n.Id,
              Name = n.Name,
              Description = n.Description,
              Weight = n.Weight,
              Data = n.Data
            }).ToList();

            return viewModel;
        }
        public ProductDetailsViewModel Details(int id)
        {
            var entity = _productRepository.GetOne(id);

            var viewModel = new ProductDetailsViewModel();

            viewModel.Product = new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Weight = entity.Weight,
                Data = entity.Data,
                SectionId = entity.SectionId,
                Ingredients = entity.Ingredients.Select(n => new IngredientDTO
                {
                    Id = n.Id,
                    Name = n.Name,
                    Mass = n.Mass,
                    ProductId = entity.Id
                }).ToList()
            };
            return viewModel;
        }
  
        public void Remove(int id, ModelStateDictionary modelState)
        {
            if (_productValidator.ValidateRemoveRequest(id, modelState))
            {
                _productRepository.Remove(id);
            }
        }

        public void Add(ProductDTO model, ModelStateDictionary modelState)
        {
            if (_productValidator.ValidateAddRequest(model, modelState))
            {
                var dbModel = new ProductEntity()
                {
                    SectionId = model.SectionId,
                    Name = model.Name,
                    Description = model.Description,
                    Weight = model.Weight,
                    Data = model.Data
                };
                _productRepository.Add(dbModel);
            }
        }
    }
}
