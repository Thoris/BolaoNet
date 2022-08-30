using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembro>,
        Domain.Interfaces.Repositories.Boloes.IBolaoMembroDao
    {      
        #region Constructors/Destructors

        public BolaoMembroRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoMembroDao membros
        
        public bool OrganizePontosRodada(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, Domain.Entities.Boloes.Bolao bolao, int rodada)
        {
            string command = "exec sp_BoloesMembrosPontosRodadas_Organize " +
                  "  @CurrentLogin " +
                  ", @CurrentDateTime" +
                  ", @NomeCampeonato" +
                  ", @NomeGrupo" + 
                  ", @NomeFase" +
                  ", @NomeBolao" +
                  ", @Rodada" +
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
                                                        new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                        new SqlParameter("NomeGrupo", grupo.Nome),
                                                        new SqlParameter("NomeFase", fase.Nome),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("Rodada", rodada),
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
        public IList<Domain.Entities.Boloes.BolaoMembro> GetListUsersInBolao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            return base.GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0).ToList();
        }
        public IList<Domain.Entities.Boloes.BolaoMembro> GetListBolaoInUsers(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User user)
        {
            return base.GetList(x => string.Compare(x.UserName, user.UserName, true) == 0).ToList();
        }
        public IList<Domain.Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            string command = "exec sp_BoloesMembros_LoadStatus " +
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



            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> res =
                base.DataContext.Database.SqlQuery<Domain.Entities.ValueObjects.UserMembroStatusVO>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList ();

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
        public bool RemoverMembroBolao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Boloes.BolaoMembro membro)
        {
            string command = "exec sp_BoloesMembros_Del " +
                  "  @CurrentLogin " +
                  ", @CurrentDateTime" +
                  ", @NomeBolao" +
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



            object res =
                base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("UserName", membro.UserName),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            //int error = 0;
            //try
            //{
            //    error = (int)errorNumber.Value;
            //}
            //catch
            //{

            //}

            return true;
        }
        public IList<Domain.Entities.Users.User> GetUsersToNotificate(string currentUserName, Domain.Entities.Boloes.Bolao bolao)
        {
            var q =
            (from m in base.DataContext.BoloesMembros


             join u in base.DataContext.Usuarios
                     on new { c1 = m.UserName }
                 equals new { c1 = u.UserName }

             where string.Compare(m.NomeBolao, bolao.Nome, true) == 0 &&
              u.ReceiveEmails == true
             orderby u.UserName descending
             select u).ToList();

            return q;
        }

        #endregion
    }
}
