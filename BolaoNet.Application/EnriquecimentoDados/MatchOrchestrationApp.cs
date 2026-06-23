using BolaoNet.Domain.Entities.EnriquecimentoDados;
using System.Threading.Tasks;

namespace BolaoNet.Application.EnriquecimentoDados
{
    public class  MatchOrchestrationApp :
            Base.GenericApp<Domain.Entities.EnriquecimentoDados.WorldCupMatch>,
            Application.Interfaces.EnriquecimentoDados.IMatchOrchestrationApp
    {
        #region Variables

        private Domain.Interfaces.Services.EnriquecimentoDados.IMatchOrchestrator _service;

        #endregion

        #region Properties

        private Domain.Interfaces.Services.EnriquecimentoDados.IMatchOrchestrator Service
        {
            get { return _service; }
        }

        #endregion

        #region Constructors/Destructors

        public MatchOrchestrationApp(Domain.Interfaces.Services.EnriquecimentoDados.IMatchOrchestrator service)
            : base(null)
        {
            _service = service;
        }

        public async Task<int> CreateMatches(int season)
        {
            return await _service.CreateMatches(season);
        
        }

        public async Task LoadExternalApiMatches(string season)
        {
            await _service.LoadExternalApiMatches(season); 
        }

        public async Task AssociateMatches(int season)
        {
            await _service.AssociateMatches(season);
        }

        public async Task<bool> UpdateMatch(int id)
        { 
           return await _service.UpdateMatch(id);
        }

        public async Task<WorldCupMatch> LoadMatch(int id)
        {
            return await _service.LoadMatch(id);
        }

        #endregion
    }
}
