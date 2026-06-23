namespace BolaoNet.Infra.Data.EF.Mapping.EnriquecimentoDados
{
    public class TeamAliasConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.EnriquecimentoDados.TeamAlias>
    {

        #region Constructors/Destructors

        public TeamAliasConfiguration()
        {
            ToTable("ApiTeamAliases");
             

        }

        #endregion
    }
}
