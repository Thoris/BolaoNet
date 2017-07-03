using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Bolao>,
        Domain.Interfaces.Repositories.Boloes.IBolaoDao
    {
        
        #region Constructors/Destructors

        public BolaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoDao members

        public bool Iniciar(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            string command = "exec sp_Boloes_Iniciar " +
                           "  @CurrentLogin " +
                           ", @CurrentDateTime" +
                           ", @IniciadoBy" +
                           ", @NomeBolao" +
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

            base.DataContext.Database.SqlQuery<object>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("IniciadoBy", iniciadoBy.UserName),
                                                    new SqlParameter("NomeBolao", bolao.Nome),
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

        public bool Aguardar(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            string command = "exec sp_Boloes_Iniciar " +
                           "  @CurrentLogin " +
                           ", @CurrentDateTime" +
                           ", @NomeBolao" +
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

            base.DataContext.Database.SqlQuery<object>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("NomeBolao", bolao.Nome),
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

        public IList<Domain.Entities.Boloes.Bolao> GetBoloesDisponiveis(string currentUserName, DateTime currentDateTime)
        {
            return GetAll().ToList<Domain.Entities.Boloes.Bolao>();
        }
        public IList<Domain.Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User user)
        {
            string command = "exec sp_Users_Load_Boloes " +
                          "  @CurrentLogin " +
                          ", @CurrentDateTime" +
                          ", @UserName" +
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

            IList < Domain.Entities.ValueObjects.UserBoloesVO > res =
                base.DataContext.Database.SqlQuery<Domain.Entities.ValueObjects.UserBoloesVO>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("UserName", user.UserName),
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

            return res;

        }
        
        public IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User user)
        {
            string command = "exec sp_Users_Load_Pagamentos " +
                         "  @CurrentLogin " +
                         ", @CurrentDateTime" +
                         ", @UserName" +
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

            IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> res =
                base.DataContext.Database.SqlQuery<Domain.Entities.ValueObjects.UserSaldoBolaoVO>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("UserName", user.UserName),
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

            return res;
        }

        #endregion
        
    }
}
