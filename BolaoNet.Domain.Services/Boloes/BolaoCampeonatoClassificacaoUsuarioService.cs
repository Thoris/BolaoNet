using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioService :
        Base.BaseGenericService<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {

        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioService(string userName, Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>)dao, logging)
        {

        }

        #endregion

        #region IBolaoCampeonatoClassificacaoUsuarioService members

        public IList<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(Entities.Boloes.Bolao bolao, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (fase == null)
                throw new ArgumentException("fase");
            if (string.IsNullOrEmpty(fase.Nome))
                throw new ArgumentException("fase.Nome");
            if (grupo == null)
                throw new ArgumentException("grupo");
            if (string.IsNullOrEmpty(grupo.Nome))
                throw new ArgumentException("grupo.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> res = Dao.LoadClassificacao(base.CurrentUserName, DateTime.Now, bolao, fase, grupo, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de Classificação do do bolão [" + bolao.Nome + "] Fase [" + fase.Nome + "] Grupo [" + grupo.Nome + "] usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        }

        #endregion
    }
}
