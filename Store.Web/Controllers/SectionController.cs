using Microsoft.AspNetCore.Mvc;
using Store.Web.Data;
using Store.Web.Models.DTO;
using Store.Web.Repositories;
using Store.Web.Services;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISectionService _sectionService;
        private readonly ISectionRepository _sectionRepository;

        public SectionController(ApplicationDbContext dbContext, ISectionService sectionService, ISectionRepository sectionRepository)
        {
            _dbContext = dbContext;
            _sectionService = sectionService;
            _sectionRepository = sectionRepository;
        }

        public IActionResult Index()
        {
            return View(_sectionService.List());
        }

        public IActionResult Details(int id)
        {
            return View(_sectionService.Details(id));
        }

        [HttpGet]
        public IActionResult AddSection()
        {
            return View(new SectionDTO());
        }

        [HttpPost]
        public IActionResult AddSection(SectionDTO model)
        {
            _sectionService.Add(model, ModelState);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(new SectionDTO());
        }

        public IActionResult RemoveSection(int id)
        {
            _sectionService.Remove(id, ModelState);

            return RedirectToAction("Index");
        }

    }
}
