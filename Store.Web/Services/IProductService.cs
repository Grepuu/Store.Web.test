using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Models.ViewModels;

namespace Store.Web.Services
{
    public interface IProductService
    {
        ProductDetailsViewModel List();
        ProductDetailsViewModel Details(int id);
        void Add(ProductDTO model, ModelStateDictionary modelState);
        void Remove(int id, ModelStateDictionary modelState);
    }
}
