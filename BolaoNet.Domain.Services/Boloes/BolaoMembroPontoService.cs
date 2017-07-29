using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroPontoService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembroPonto>,
        Interfaces.Services.Boloes.IBolaoMembroPontoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoMembroPontoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoMembroPontoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroPontoService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroPontoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembroPonto>)dao, logging)
        {

        }

        #endregion

        #region IBolaoMembroGrupoService members

        public IList<Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (bolao == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.Nome");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoMembroPonto> res =
                Dao.GetHistoricoClassificacao(base.CurrentUserName, DateTime.Now, bolao, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de histórico do bolão [" + bolao.Nome + "] e usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        
        }



        #endregion


    }
}
