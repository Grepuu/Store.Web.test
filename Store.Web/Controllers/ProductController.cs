using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Web.Data;
using Store.Web.Models;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Models.ViewModels;
using Store.Web.Services;
using Store.Web.Services.Implementation;

namespace Store.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductService _productService;

        public ProductController(ApplicationDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }

        public IActionResult Details(int id)
        {
            return View(_productService.Details(id)); 
        }


        [HttpGet]
        public IActionResult AddProductToSection(int sectionId)
        {
            return View(new ProductDTO { SectionId = sectionId });
        }

        [HttpPost]
        public IActionResult AddProductToSection(ProductDTO model)
        {
            _productService.Add(model, ModelState);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", "Section", new { id = model.SectionId });
            }
            return View(new ProductDTO());
        }
        public IActionResult RemoveProduct(int id)
        {
            _productService.Remove(id, ModelState);

            return RedirectToAction("Details", "Section");
        }
    }
}
