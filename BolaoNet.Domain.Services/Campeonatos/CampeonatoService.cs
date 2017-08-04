using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoService :
        Base.BaseGenericService<Entities.Campeonatos.Campeonato>,
        Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoDao BaseDao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Campeonato>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoService members

        public IList<int> GetRodadasCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<int> res = BaseDao.GetRodadasCampeonato(base.CurrentUserName, campeonato);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando as rodadas do campeonato [" + campeonato.Nome + "] total: " + res.Count));
            }

            return res;
        }



        public void Reiniciar(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");


            if (IsSaveLog)
                CheckStart();

            BaseDao.Reiniciar(base.CurrentUserName, DateTime.Now, campeonato);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Reiniciando campeonato [" + campeonato.Nome + "] "));
            }

        }

        public void ClearDatabase()
        {
            if (IsSaveLog)
                CheckStart();

            BaseDao.ClearDatabase(base.CurrentUserName, DateTime.Now);



            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Apagando o banco de dados"));
            }
        }

        public IList<IList<Entities.ValueObjects.CampeonatoRecordVO>> GetRecords(Entities.Campeonatos.Campeonato campeonato, Interfaces.Services.Campeonatos.RecordTipoPesquisa tipo)
        {

            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<IList<Entities.ValueObjects.CampeonatoRecordVO>> res = BaseDao.GetRecords(base.CurrentUserName, DateTime.Now,
                campeonato, (int)tipo);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Records obtidos do campeonato [" + campeonato.Nome + "] tipo: [" + tipo +"]"));
            }

            return res;
        }

        #endregion





    }
}
