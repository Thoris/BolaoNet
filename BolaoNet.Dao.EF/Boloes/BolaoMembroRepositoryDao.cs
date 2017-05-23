﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoMembroRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.BolaoMembro>, Dao.Boloes.IBolaoMembroDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoMembroDao membros
        
        public bool OrganizePontosRodada(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, Entities.Boloes.Bolao bolao, int rodada)
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

        #endregion
    }
}
