namespace BolaoNet.Application.Interfaces.EnriquecimentoDados
{
    public interface IWorldCupMatchApp
        : Domain.Interfaces.Services.EnriquecimentoDados.IWorldCupMatchService,
        Base.IGenericApp<Domain.Entities.EnriquecimentoDados.WorldCupMatch>
    {
    }
}
