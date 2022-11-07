using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models;
using Store.Web.Models.DTO;
using Store.Web.Models.Entities;
using Store.Web.Models.ViewModels;
using Store.Web.Repositories;

namespace Store.Web.Services.Implementation
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly ISectionValidator _sectionValidator;
        public SectionService(ISectionRepository sectionRepository, ISectionValidator sectionValidator)
        {
            _sectionRepository = sectionRepository;
            _sectionValidator = sectionValidator;
        }
        public SectionIndexViewModel List()
        {
            var entites = _sectionRepository.GetAll();
            var viewModel = new SectionIndexViewModel()
            {
                Sections = new List<SectionDTO>()
            };
            viewModel.Sections = entites.Select(n => new SectionDTO
            {
                Id = n.Id,
                Name = n.Name,
                Description = n.Description,
                Size = n.Size,
                MaxNumberOfRacks = n.MaxNumberOfRacks
            }).ToList();

            return viewModel;
        }

        public SectionDetailsViewModel Details(int id)
        {

            var entity = _sectionRepository.GetOne(id);

            var viewModel = new SectionDetailsViewModel();

            viewModel.Section = new SectionDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Size = entity.Size,
                MaxNumberOfRacks = entity.MaxNumberOfRacks,
                Products = entity.Products.Select(n => new ProductDTO
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Weight = n.Weight,
                    Data = n.Data
                }).ToList()
            };
            return viewModel;
        }
        public void Add(SectionDTO model, ModelStateDictionary modelState)
        {
            if (_sectionValidator.ValidateAddRequest(model, modelState))
            {
                var dbModel = new SectionEntity()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Size = model.Size,
                    MaxNumberOfRacks = model.MaxNumberOfRacks
                };
                _sectionRepository.Add(dbModel);
            }

        }
        public void Remove(int id, ModelStateDictionary modelState)
        {
            if (_sectionValidator.ValidateRemoveRequest(id, modelState))
            {
                _sectionRepository.Remove(id);
            }

        }
    }
}
