namespace BolaoNet.Application.EnriquecimentoDados
{
    public class WorldCupMatchApp :
            Base.GenericApp<Domain.Entities.EnriquecimentoDados.WorldCupMatch>,
        Application.Interfaces.EnriquecimentoDados.IWorldCupMatchApp
    {
        #region Properties

        private Domain.Interfaces.Services.EnriquecimentoDados.IWorldCupMatchService Service
        {
            get { return (Domain.Interfaces.Services.EnriquecimentoDados.IWorldCupMatchService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        public WorldCupMatchApp(Domain.Interfaces.Services.EnriquecimentoDados.IWorldCupMatchService service)
            : base(service)
        {

        #endregion
    }
}
}
