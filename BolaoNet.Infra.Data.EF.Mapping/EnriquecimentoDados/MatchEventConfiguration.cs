namespace BolaoNet.Infra.Data.EF.Mapping.EnriquecimentoDados
{
    public class MatchEventConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.EnriquecimentoDados.MatchEvent>
    {

        #region Constructors/Destructors

        public MatchEventConfiguration()
        {
            ToTable("ApiMatchEvents"); 

        }

        #endregion
    }
}
