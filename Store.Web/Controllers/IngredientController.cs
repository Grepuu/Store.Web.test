using Microsoft.AspNetCore.Mvc;
using Store.Web.Data;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Services;
using Store.Web.Services.Implementation;
using System.Security.Cryptography.X509Certificates;

namespace Store.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIngredientService _ingredientService;

        public IngredientController(ApplicationDbContext dbContext, IIngredientService ingredientService)
        {
            _dbContext = dbContext;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public IActionResult AddIngredientToProduct(int productId)
        {
            return View(new IngredientDTO { ProductId = productId });
        }

        [HttpPost]
        public IActionResult AddIngredientToProduct(IngredientDTO model)
        {
            _ingredientService.Add(model, ModelState);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", "Product", new { id = model.ProductId });
            }
            return View(new IngredientDTO());
        }

        public IActionResult RemoveIngredient(int id)
        {
            var model = _dbContext.Ingredients.FirstOrDefault(n => n.Id == id);

            _dbContext.Ingredients.Remove(model);
            _dbContext.SaveChanges();

            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }

    }
}
