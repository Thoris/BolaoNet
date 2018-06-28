using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPremiacaoService :
        Base.BaseGenericService<Entities.Boloes.BolaoPremiacao>,
        Interfaces.Services.Boloes.IBolaoPremiacaoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoPremiacaoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoPremiacaoDao)base.BaseDao; }
        }

        #endregion
        
        #region Constructors/Destructors

        public BolaoPremiacaoService(string userName, Interfaces.Repositories.Boloes.IBolaoPremiacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPremiacao>)dao, logging)
        {

        }

        #endregion

        #region IBolaoPremiacaoService members

        public IList<Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoPremiacao> res = Dao.LoadPremiacaoBolao(base.CurrentUserName, DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de premiação do bolão [" + bolao.Nome + "] total: " + res.Count));
            }
            return res;
        }
         
        
        #endregion

    }
}
