using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Campeonatos
{
    public class CampeonatoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Campeonatos.Campeonato>, 
        Domain.Interfaces.Repositories.Campeonatos.ICampeonatoDao
    {
        #region Constructors/Destructors

        public CampeonatoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region ICampeonatoDao members

        public IList<int> GetRodadasCampeonato(string currentUserName, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            //var results = base.DataContext.Jogos.Distinct<(row => row.Text);
            //base.DataContext.Jogos.GroupBy(x => x.Text)
            //    .Where(g => g.Count() == 1)
            //    .Select(g => g.First());

            var results = base.DataContext.Jogos.Select( p => p.Rodada ).Distinct();

            return results.ToList<int>();

        }
        public void Reiniciar(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            string command = "exec sp_Campeonatos_Reiniciar " +
                                     "  @CurrentLogin " +
                                     ", @CurrentDateTime" +
                                     ", @NomeCampeonato" +
                                     
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
                            new SqlParameter("NomeCampeonato", campeonato.Nome),                                                        
                            errorNumber,
                            errorDescription
                        );

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }
             
        }

        public void ClearDatabase(string currentUserName, DateTime currentDateTime)
        {
            string command = "exec sp_Clear_Database ";
                                                 
            //base.DataContext.Database.SqlQuery<object>(command).Single();
            object[] parameters = new object[] { };
            base.DataContext.Database.ExecuteSqlCommand(command, parameters);

        }
        public IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> GetRecords(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.Campeonato campeonato, int tipo)
        {
            IList<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>> res =
                new List<IList<Domain.Entities.ValueObjects.CampeonatoRecordVO>>();


            var cmd = base.DataContext.Database.Connection.CreateCommand();
            string formatCommand = 
                @"EXEC	sp_CampeonatosRecords
		                @CurrentLogin = NULL,
		                @CurrentDateTime = NULL,
		                @NomeCampeonato = N'{0}',
		                @TipoPesquisa = {1}";

            cmd.CommandText = string.Format(formatCommand, campeonato.Nome, tipo);

            try
            {

                base.DataContext.Database.Connection.Open();
                var reader = cmd.ExecuteReader();
                var geral = ((IObjectContextAdapter)base.DataContext)
                    .ObjectContext
                    .Translate<Domain.Entities.ValueObjects.CampeonatoRecordVO>(reader);

                IList<Domain.Entities.ValueObjects.CampeonatoRecordVO> geralList = geral.ToList();
                res.Add(geralList);

                reader.NextResult();

                var casa = ((IObjectContextAdapter)base.DataContext)
                    .ObjectContext
                    .Translate<Domain.Entities.ValueObjects.CampeonatoRecordVO>(reader);


                IList<Domain.Entities.ValueObjects.CampeonatoRecordVO> casaList = casa.ToList();
                res.Add(casaList);

                reader.NextResult();

                var fora = ((IObjectContextAdapter)base.DataContext)
                    .ObjectContext
                    .Translate<Domain.Entities.ValueObjects.CampeonatoRecordVO>(reader);


                IList<Domain.Entities.ValueObjects.CampeonatoRecordVO> foralList = fora.ToList();
                res.Add(foralList);
            }
            finally
            {
                base.DataContext.Database.Connection.Close();
            }

            return res;
           
        }

        #endregion




    }
}
