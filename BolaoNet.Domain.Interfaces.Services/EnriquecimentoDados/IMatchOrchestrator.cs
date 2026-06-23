using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.EnriquecimentoDados
{
    public interface IMatchOrchestrator
    { 
        Task<int> CreateMatches(int season);
        Task LoadExternalApiMatches(string season);
        Task AssociateMatches(int season);
        Task<bool> UpdateMatch(int id);
        Task<WorldCupMatch> LoadMatch(int id);

    }
}
