namespace BolaoNet.Infra.Data.EF.Mapping.EnriquecimentoDados
{
    public class WorldCupMatchConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.EnriquecimentoDados.WorldCupMatch>
    {

        #region Constructors/Destructors

        public WorldCupMatchConfiguration()
        {
            ToTable("ApiWorldCupMatches");
             

        }

        #endregion
    }
}
