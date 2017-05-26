using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostaExtraBO : 
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostaExtra>,
        Interfaces.Boloes.IApostaExtraBO
    {

        #region Properties
        
        private Dao.Boloes.IApostaExtraDao Dao
        {
            get { return (Dao.Boloes.IApostaExtraDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraBO(string userName, Dao.Boloes.IApostaExtraDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostaExtra>)dao)
        {

        }

        #endregion

        #region IApostaExtraBO members

        public IList<Entities.Boloes.ApostaExtra> GetApostasBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetApostasBolao(this.CurrentUserName, bolao);
        }

        #endregion
    }
}
