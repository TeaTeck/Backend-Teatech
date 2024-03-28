using Interfaces.Repositories;
using System;
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
        public ChildAssisted CreateChild(ChildAssisted childAssisted)
        {
            var childAdd = _childAssistedRepository.Add(childAssisted);
            return childAdd;

        }
        public List<ChildAssistedDTO> ListAllUser()
        {
            var childs = _childAssistedRepository.GetAll();

            List<ChildAssistedDTO> childDTO = childs.Select(childAssited => new ChildAssistedDTO
            {
                Id = childAssited.Id,
                Name = childAssited.Name,
                BirthDate = childAssited.BirthDate,
                FoodSelectivity = childAssited.FoodSelectivity,
                Aversions = childAssited.Aversions,
                Preferences = childAssited.Preferences,
                MedicalRecord = childAssited.MedicalRecord,
                Responsible = childAssited.Responsible,
                Photo = childAssited.Photo,

            }).ToList();

            return childDTO;
            
        }
        public void DeleteChildById(Guid id)
        {
            var existingChild = _childAssistedRepository.GetById(id);
            if (existingChild != null)
            {
                _childAssistedRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        public List<ChildAssisted> FilterByData(string data)
        {
            return _childAssistedRepository.GetByData(data);
        }

    }
}
