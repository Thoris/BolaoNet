using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoCriterioPontosRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoCriterioPontos>, Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoCriterioPontosDao members

        public bool BuscaPontos(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, out int pontosEmpate, out int pontosVitoria, out int pontosDerrota, out int pontosGanhador, out int pontosPerdedor, out int pontosTime1, out int pontosTime2, out int pontosVDE, out int pontosErro, out int pontosGanhadorFora, out int pontosGanhadorDentro, out int pontosPerdedorFora, out int pontosPerdedorDentro, out int pontosEmpateGols, out int pontosGolsTime1, out int pontosGolsTime2, out int pontosCheio)
        {
            pontosCheio = 0;
            pontosDerrota = 0;
            pontosEmpate = 0;
            pontosEmpateGols = 0;
            pontosErro = 0;
            pontosGanhador = 0;
            pontosGanhadorDentro = 0;
            pontosGanhadorFora = 0;
            pontosGolsTime1 = 0;
            pontosGolsTime2 = 0;
            pontosPerdedor = 0;
            pontosPerdedorDentro = 0;
            pontosPerdedorFora = 0;
            pontosTime1 = 0;
            pontosTime2 = 0;
            pontosVDE = 0;
            pontosVitoria = 0;

            string command = "exec sp_Boloes_BuscaCriteriosPontos " +
                "  @CurrentLogin " +
                ", @CurrentDateTime" +
                ", @NomeBolao" +
                ", @PontosEmpate					OUT" +
                ", @PontosVitoria					OUT" +
                ", @PontosDerrota					OUT" +
                ", @PontosGanhador					OUT" +
                ", @PontosPerdedor					OUT" +
                ", @PontosTime1						OUT" +
                ", @PontosTime2						OUT" +
                ", @PontosVDE						OUT" +
                ", @PontosErro						OUT" +
                ", @PontosGanhadorFora				OUT" +
                ", @PontosGanhadorDentro			OUT" +
                ", @PontosPerdedorFora				OUT" +
                ", @PontosPerdedorDentro			OUT" +
                ", @PontosEmpateGols				OUT" +
                ", @PontosGolsTime1					OUT" +
                ", @PontosGolsTime2					OUT" +
                ", @PontosCheio						OUT" +
                ", @ErrorNumber                     out" +
                ", @ErrorDescription                out";


            #region Criando os parâmetros de retorno

            var parPontosEmpate = new SqlParameter
            {
                ParameterName = "@PontosEmpate",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosVitoria = new SqlParameter
            {
                ParameterName = "@PontosVitoria",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosDerrota = new SqlParameter
            {
                ParameterName = "@PontosDerrota",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosGanhador = new SqlParameter
            {
                ParameterName = "@PontosGanhador",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosPerdedor = new SqlParameter
            {
                ParameterName = "@PontosPerdedor",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosTime1 = new SqlParameter
            {
                ParameterName = "@PontosTime1",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosTime2 = new SqlParameter
            {
                ParameterName = "@PontosTime2",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosVDE = new SqlParameter
            {
                ParameterName = "@PontosVDE",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosErro = new SqlParameter
            {
                ParameterName = "@PontosErro",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosGanhadorFora = new SqlParameter
            {
                ParameterName = "@PontosGanhadorFora",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosGanhadorDentro = new SqlParameter
            {
                ParameterName = "@PontosGanhadorDentro",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosPerdedorFora = new SqlParameter
            {
                ParameterName = "@PontosPerdedorFora",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosPerdedorDentro = new SqlParameter
            {
                ParameterName = "@PontosPerdedorDentro",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosEmpateGols = new SqlParameter
            {
                ParameterName = "@PontosEmpateGols",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosGolsTime1 = new SqlParameter
            {
                ParameterName = "@PontosGolsTime1",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosGolsTime2 = new SqlParameter
            {
                ParameterName = "@PontosGolsTime2",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var parPontosCheio = new SqlParameter
            {
                ParameterName = "@pontosCheio",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
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

            #endregion


            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        parPontosEmpate,
                                                        parPontosVitoria,
                                                        parPontosDerrota,
                                                        parPontosGanhador,
                                                        parPontosPerdedor,
                                                        parPontosTime1,
                                                        parPontosTime2,
                                                        parPontosVDE,
                                                        parPontosErro,
                                                        parPontosGanhadorFora,
                                                        parPontosGanhadorDentro,
                                                        parPontosPerdedorFora,
                                                        parPontosPerdedorDentro,
                                                        parPontosEmpateGols,
                                                        parPontosGolsTime1,
                                                        parPontosGolsTime2,
                                                        parPontosCheio,
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
