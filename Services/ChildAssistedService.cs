using System;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.DTO.ChildAssisteds;

namespace Backend_TeaTech.Services
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

        public void DeleteChildById(Guid id)
        {
            var existingChild = _childAssistedRepository.GetById(id);
            if (existingChild != null)
            {
                _childAssistedRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Child not found.");
            }
        }

        public List<ChildAssistedDTO> FilterByData(string data)
        {
            var childs = _childAssistedRepository.GetByData(data);

            List<ChildAssistedDTO> childAssistedDTOs = new List<ChildAssistedDTO>();

            childs.ForEach(child => childAssistedDTOs.Add(new ChildAssistedDTO(child.Id, child.Name, child.Responsible.User.Email, child.Responsible.ContactOne)));

            return childAssistedDTOs;
        }

        public ChildAssisted GetChildById(Guid id)
        {
            try
            {
                var childAssisted = _childAssistedRepository.GetById(id);
                if (childAssisted == null)
                {
                    throw new ArgumentException($"Child with ID {id} not found.");
                }
                return childAssisted;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
