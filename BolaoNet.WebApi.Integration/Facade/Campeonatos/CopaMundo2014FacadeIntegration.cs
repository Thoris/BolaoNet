using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Facade.Campeonatos
{
    public class CopaMundo2014FacadeIntegration: Base.JsonManagement,
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "CopaMundo2014Facade";

        #endregion
        
        #region Constructors/Destructors

        public CopaMundo2014FacadeIntegration(string url)
            : base(url, ModuleName)
        {

        }

        #endregion


        #region ICopaMundo2014FacadeService members

        public Domain.Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("nomeCampeonato", nomeCampeonato);
            parameters.Add("isClube", isClube);

            return base.HttpPostApi<Domain.Entities.Campeonatos.Campeonato>(parameters, "CreateCampeonato");
        }

        public bool InsertResults(Domain.Entities.Users.User validatedBy)
        {

            return base.HttpPostApi<bool>(new Dictionary<string, string>(), validatedBy, "InsertResults");
        }

        #endregion
    }
}
