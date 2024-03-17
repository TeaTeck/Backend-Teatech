using Interfaces.Repositories;
using WebApplication1.Interfaces.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ChildAssistedService : IChildAssistedService
    {
        private readonly IChildAssistedRepository _childAssistedRepository;
        public ChildAssistedService(IChildAssistedRepository childAssistedRepository)
        {
            _childAssistedRepository = childAssistedRepository;
        }
        public ChildAssistedDTO CreateChild(ChildAssisted childAssisted)
        {
            var childAdd = _childAssistedRepository.Add(childAssisted);

            ChildAssistedDTO childAssistedDTO = new ChildAssistedDTO
            {
                Id = childAdd.Id,
                Name = childAdd.Name,
                BirthDate = childAdd.BirthDate,
                FoodSelectivity = childAdd.FoodSelectivity,
                Aversions = childAdd.Aversions,
                Preferences = childAdd.Preferences,
                MedicalRecord = childAdd.MedicalRecord,
                Responsible = childAdd.Responsible,
                Photo = childAdd.Photo,
            };

            return childAssistedDTO;

        }
    }
}
