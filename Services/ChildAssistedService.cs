﻿using System;
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
        private readonly IPreAnalysisRepository _preAnalysisRepository;
        public ChildAssistedService(IChildAssistedRepository childAssistedRepository, IPreAnalysisRepository preAnalysisRepository)
        {
            _childAssistedRepository = childAssistedRepository;
            _preAnalysisRepository = preAnalysisRepository;
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

        public ListChildAssistedDTO FilterByData(string data, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            var childs = _childAssistedRepository.GetByData(data, pageNumber, pageSize, orderBy, orderDirection);

            List<ChildAssistedDTO> childAssistedDTOs = new List<ChildAssistedDTO>();

            childs.ForEach(child => {
                PreAnalysis? preAnalysis = _preAnalysisRepository.GetByChildAssistedId(child.Id);
                childAssistedDTOs.Add(new ChildAssistedDTO(child, preAnalysis));
            });

            int totalChildAssisteds = _childAssistedRepository.CountAllChildAssisted();

            int totalPages = (int)Math.Ceiling((double)totalChildAssisteds / pageSize);

            ListChildAssistedDTO listChildAssistedDTO = new ListChildAssistedDTO(childAssistedDTOs, totalPages, pageNumber);

            return listChildAssistedDTO;
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
