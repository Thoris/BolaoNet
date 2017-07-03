using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroGrupoService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembroGrupo>,
        Interfaces.Services.Boloes.IBolaoMembroGrupoService
    {

        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroGrupoService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembroGrupo>)dao, logging)
        {

        }

        #endregion

        #region IBolaoMembroGrupoService members

        public IList<Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (bolao == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.Nome");


            return Dao.LoadClassificacao(base.CurrentUserName, DateTime.Now, bolao, user);

        }

        #endregion
    }
}
