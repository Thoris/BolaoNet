using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoMembroClassificacaoService :
        Base.BaseGenericService<Entities.Boloes.BolaoMembroClassificacao>,
        Interfaces.Services.Boloes.IBolaoMembroClassificacaoService
    {

        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroClassificacaoService(string userName, Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoMembroClassificacao>)dao, logging)
        {

        }

        #endregion

        #region IBolaoMembroClassificacaoService members

        public IList<Entities.ValueObjects.BolaoClassificacaoVO> LoadClassificacao(Entities.Boloes.Bolao bolao, int? rodada)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.LoadClassificacao(base.CurrentUserName, DateTime.Now, bolao, rodada);

        }

        #endregion
    }
}
