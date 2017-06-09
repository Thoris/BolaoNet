using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class ApostaExtraRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.ApostaExtra>, Domain.Interfaces.Repositories.Boloes.IApostaExtraDao
    {

        #region Constructors/Destructors

        public ApostaExtraRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IApostaExtraDao members

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(string currentUserName, Domain.Entities.Boloes.Bolao bolao)
        {
            return base.GetList(x =>
                string.Compare(x.NomeBolao, bolao.Nome, true) == 0).ToList<Domain.Entities.Boloes.ApostaExtra>();
        }
        public bool InsertResult(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            string command = "exec sp_ApostasExtras_InsertResult " +
                   "  @CurrentLogin " +
                   ", @CurrentDateTime" +
                   ", @NomeBolao" +
                   ", @NomeTime" +
                   ", @Posicao" +
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
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("NomeTime", time.Nome),
                                                        new SqlParameter("Posicao", posicao),
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

        #endregion

    }
}
