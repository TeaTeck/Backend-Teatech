using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.PreAnalysis;
using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Services
{
    public class PreAnalysisService : IPreAnalysisService
    {
        private readonly IPreAnalysisRepository _preAnalysisRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public PreAnalysisService(IPreAnalysisRepository preAnalysisRepository, IEmployeeRepository employeeRepository)
        {
            _preAnalysisRepository = preAnalysisRepository;
            _employeeRepository = employeeRepository;
        }

        public PreAnalysis CreatePreAnalysis(PreAnalysis preAnalysis)
        {
            PreAnalysis preAnalysisAdd = _preAnalysisRepository.Add(preAnalysis);
            return preAnalysisAdd;
        }

        public PreAnalysis UpdatePreAnalysis(Guid id, PreAnalysisRequestDTO preAnalysis)
        {
            PreAnalysis preAnalysisUpdate = _preAnalysisRepository.GetById(id);

            if (preAnalysisUpdate == null)
            {
                throw new ArgumentException($"Pre Analysis with ID {id} not found.");
            }

            if (preAnalysis.ProposedActivity != preAnalysisUpdate.ProposedActivity && preAnalysis.ProposedActivity != null)
            {
                preAnalysisUpdate.ProposedActivity = preAnalysis.ProposedActivity;
            }
            if (preAnalysis.FinalDuration != preAnalysisUpdate.FinalDuration && preAnalysis.FinalDuration != null)
            {
                preAnalysisUpdate.FinalDuration = preAnalysis.FinalDuration;
            }
            if (preAnalysis.IdentifiedSkills != preAnalysisUpdate.IdentifiedSkills && preAnalysis.IdentifiedSkills != null)
            {
                preAnalysisUpdate.IdentifiedSkills = preAnalysis.IdentifiedSkills;
            }
            if (preAnalysis.Protocol != preAnalysisUpdate.Protocol && preAnalysis.Protocol != null)
            {
                preAnalysisUpdate.Protocol = preAnalysis.Protocol;
            }

            Employee employee = _employeeRepository.GetByID(preAnalysis.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }
            else
            {
                preAnalysisUpdate.Employee = employee;

                _preAnalysisRepository.Update(preAnalysisUpdate);

            }

            return preAnalysisUpdate;

        }

        public void DeletePreAnalysisById(Guid id)
        {
            var existingPreAnalysis = _preAnalysisRepository.GetById(id);
            if (existingPreAnalysis != null)
            {
                _preAnalysisRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Pre Analysis not found.");
            }
        }

        public PreAnalysis GetPreAnalysisById(Guid id)
        {
            try
            {
                var preAnalysis = _preAnalysisRepository.GetById(id);
                if (preAnalysis == null)
                {
                    throw new ArgumentException($"Pre Analysis with ID {id} not found.");
                }
                return preAnalysis;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public List<PreAnalysisDTO> ListAllPreAnalysis()
        {
            var preAnalysiss = _preAnalysisRepository.GetAll();

            List<PreAnalysisDTO> preAnalysisDTO = preAnalysiss.Select(preAnalysis => new PreAnalysisDTO
            {
                Id = preAnalysis.Id,
                ProposedActivity = preAnalysis.ProposedActivity,
                FinalDuration = preAnalysis.FinalDuration,
                IdentifiedSkills = preAnalysis.IdentifiedSkills,
                Protocol = preAnalysis.Protocol,
                StatusCode = preAnalysis.StatusCode,
                Employee = new EmployeeDTO(preAnalysis.Employee),
                ChildAssisted = new ChildAssistedDTO(preAnalysis.ChildAssisted),


            }).ToList();

            return preAnalysisDTO;
        }

       
    }
}
