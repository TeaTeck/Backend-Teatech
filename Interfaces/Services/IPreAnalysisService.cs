using Backend_TeaTech.DTO.PreAnalysis;
using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IPreAnalysisService
    {
        PreAnalysis CreatePreAnalysis (PreAnalysis preAnalysis);
        PreAnalysis UpdatePreAnalysis (Guid id, PreAnalysisRequestDTO preAnalysis);
        void DeletePreAnalysisById (Guid id);
        List<PreAnalysisDTO> ListAllPreAnalysis();
        PreAnalysis GetPreAnalysisById (Guid id);

    }
}
