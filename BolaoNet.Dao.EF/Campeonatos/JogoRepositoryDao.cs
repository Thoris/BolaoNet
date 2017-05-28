using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class JogoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.Jogo>, Dao.Campeonatos.IJogoDao
    {
        
        #region Constructors/Destructors

        public JogoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IJogoDao Members

        public bool CalculeGrupo(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            string command = "exec sp_Jogos_Calcule_Grupo " +
               "  @CurrentLogin " +
               ", @CurrentDateTime" +
               ", @NomeCampeonato" +
               ", @NomeFase" +
               ", @NomeGrupo" +
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

            IList<int> res = base.DataContext.Database.SqlQuery<int>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                        new SqlParameter("NomeFase", fase.Nome),
                                                        new SqlParameter("NomeGrupo", grupo.Nome),
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
        public bool InsertResult(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Entities.Users.User validadoBy)
        {
            string command = "exec sp_Jogos_ResultInsert " +
               "  @CurrentLogin " +
               ", @CurrentDateTime" +
               ", @IdJogo" +
               ", @NomeCampeonato" +
               ", @Gols1" +
               ", @Penaltis1" +
               ", @Gols2" +
               ", @Penaltis2" +
               ", @SetCurrentData" +
               ", @ValidadoBy" +
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
                                                        new SqlParameter("IdJogo", jogo.JogoId),
                                                        new SqlParameter("NomeCampeonato", jogo.NomeCampeonato),
                                                        new SqlParameter("Gols1", gols1),
                                                        new SqlParameter("Penaltis1", penaltis1 ?? SqlInt32.Null),
                                                        new SqlParameter("Gols2", gols2),
                                                        new SqlParameter("Penaltis2", penaltis2 ?? SqlInt32.Null),
                                                        new SqlParameter("SetCurrentData", setCurrentData),
                                                        new SqlParameter("ValidadoBy", validadoBy.UserName),
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
        public IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(string currentUserName, Entities.Campeonatos.Campeonato campeonato)
        {
            return base.GetList(x => 
                string.Compare(x.NomeCampeonato, campeonato.Nome, true) == 0).ToList<Entities.Campeonatos.Jogo>();
        }

        #endregion


        public IList<Entities.Campeonatos.Jogo> LoadJogos(string currentUserName, DateTime currentDateTime, int rodada, DateTime dataInicial, DateTime dataFinal, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            string command = "exec sp_Jogos_LoadJogos " +
               "  @CurrentLogin " +
               ", @CurrentDateTime" +
               ", @Rodada" +
               ", @DataInicial" +
               ", @DataFinal" +
	           ", @NomeFase" + 
	           ", @NomeCampeonato" +
	           ", @NomeGrupo" +
	           ", @Condition" + 
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

            IList<Entities.Campeonatos.Jogo> res = base.DataContext.Database.SqlQuery<Entities.Campeonatos.Jogo>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("Rodada", rodada),
                                                        new SqlParameter("DataInicial", dataInicial),
                                                        new SqlParameter("DataFinal", dataFinal),
                                                        new SqlParameter("NomeFase", fase.Nome),
                                                        new SqlParameter("NomeCampeoanto", campeonato.Nome),
                                                        new SqlParameter("NomeGrupo", grupo.Nome),
                                                        new SqlParameter("Condition", condition),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            return res;
        }

        public IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            string command = "exec sp_Jogos_LoadLastFinishedJogos " +
              "  @CurrentLogin " +
              ", @CurrentDateTime" +
              ", @NomeCampeonato" +
              ", @TotalJogos" +
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

            IList<Entities.Campeonatos.Jogo> res = base.DataContext.Database.SqlQuery<Entities.Campeonatos.Jogo>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeCampeoanto", campeonato.Nome),
                                                        new SqlParameter("TotalJogos", totalJogos),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            return res;
        }

        public IList<Entities.Campeonatos.Jogo> LoadNextJogos(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            string command = "exec sp_Jogos_LoadNextJogos " +
             "  @CurrentLogin " +
             ", @CurrentDateTime" +
             ", @NomeCampeonato" +
             ", @TotalJogos" +
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

            IList<Entities.Campeonatos.Jogo> res = base.DataContext.Database.SqlQuery<Entities.Campeonatos.Jogo>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeCampeoanto", campeonato.Nome),
                                                        new SqlParameter("TotalJogos", totalJogos),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            return res;
        }
    }
}
