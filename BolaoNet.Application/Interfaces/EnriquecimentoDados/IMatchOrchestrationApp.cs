namespace BolaoNet.Application.Interfaces.EnriquecimentoDados
{
    public interface IMatchOrchestrationApp

        : Domain.Interfaces.Services.EnriquecimentoDados.IMatchOrchestrator,
        Base.IGenericApp<Domain.Entities.EnriquecimentoDados.WorldCupMatch>
    { 
    }
}
