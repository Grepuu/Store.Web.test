using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Web.Models;
using Store.Web.Models.DTO;
using Store.Web.Repositories;

namespace Store.Web.Services.Implementation
{
    public class SectionValidator : ISectionValidator
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionValidator(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public bool ValidateAddRequest(SectionDTO model, ModelStateDictionary modelState)
        {
            if (_sectionRepository.Exists(model.Name))
            {
                modelState.AddModelError(nameof(model.Name), "Section with the same name already exists");

            }

            return modelState.IsValid;
        }

        public bool ValidateRemoveRequest(int id, ModelStateDictionary modelState)
        {
            if (id == 0)
            {
                modelState.AddModelError(nameof(id), "False parameter");
            }

            if (_sectionRepository.Exists(id) == false)
            {
                modelState.AddModelError(nameof(id), "This section doesn`t exist");
            }



            return modelState.IsValid;
        }
    }
}
