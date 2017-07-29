using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoPosicaoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoPosicao>,
        Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {

        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao Dao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoPosicaoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoPosicao>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoPosicaoService members

        public IList<Entities.Campeonatos.CampeonatoPosicao> GetPosicao(Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            else if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (fase == null)
                throw new ArgumentException("fase");
            else if (string.IsNullOrEmpty(fase.Nome))
                throw new ArgumentException("fase.Nome");

            if (IsSaveLog)
                CheckStart();
            
            
            IList<Entities.Campeonatos.CampeonatoPosicao> res =
                Dao.GetPosicao(base.CurrentUserName, DateTime.Now, campeonato, fase);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando posições do campeonato [" + campeonato.Nome + "] fase [" + fase.Nome + "] total: " + res.Count));
            }

            return res;

        }

        #endregion
    }
}
