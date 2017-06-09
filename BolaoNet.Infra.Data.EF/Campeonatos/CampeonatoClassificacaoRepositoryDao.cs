using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoClassificacaoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.CampeonatoClassificacao>, Domain.Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao
    {

        
        #region Constructors/Destructors

        public CampeonatoClassificacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoClassificacaoDao members

        public bool LoadRodada(string currentUserName, DateTime currentDateTime, int rodada, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase currentFase, Domain.Entities.Campeonatos.CampeonatoGrupo currentGrupo)
        {
            string command = "exec sp_CampeonatosClassificacao_LoadRodada " +
              "  @CurrentLogin " +
              ", @CurrentDateTime" +
              ", @CurrentRodada" +
              ", @CurrentNomeFase" +
              ", @NomeCampeonato" +
              ", @CurrentNomeGrupo" +
              ", @ErrorNumber out" +
              ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("currentRodada", rodada),
                                                        new SqlParameter("currentNomeFase", currentFase.Nome),
                                                        new SqlParameter("NomeCampeonato", campeonato.Nome),
                                                        new SqlParameter("CurrentNomeGrupo", currentGrupo.Nome),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        public bool Organize(string currentUserName, DateTime currentDateTime, int currentRodada, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase currentFase, Domain.Entities.Campeonatos.CampeonatoGrupo currentGrupo)
        {
            string command = "exec sp_CampeonatosClassificacao_Organize " +
             "  @CurrentLogin " +
             ", @CurrentDateTime" +
             ", @CurrentRodada" +
             ", @CurrentNomeFase" +
             ", @NomeCampeonato" +
             ", @CurrentNomeGrupo" +
             ", @ErrorNumber out" +
             ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("currentRodada", currentRodada),
                                                        new SqlParameter("currentNomeFase", currentFase.Nome),
                                                        new SqlParameter("NomeCampeonato", campeonato.Nome),
                                                        new SqlParameter("CurrentNomeGrupo", currentGrupo.Nome),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
