﻿using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoCriterioPontosService :
        Base.BaseGenericService<Entities.Boloes.BolaoCriterioPontos>,
        Interfaces.Services.Boloes.IBolaoCriterioPontosService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao)base.BaseDao; }
        }

        #endregion
        
        #region Constructors/Destructors

        public BolaoCriterioPontosService(string userName, Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontos>)dao, logging)
        {

        }

        #endregion

        #region IBolaoCriterioPontosBO members

        public int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao)
        {

            IList<Entities.Boloes.BolaoCriterioPontos> criterios = GetCriterioPontosBolao(bolao);

            int[] values = new int[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio + 1];

            for (int c = 0; c < criterios.Count; c++)
            {
                if (criterios[c].Pontos != null)
                    values[(int)criterios[c].CriterioID] = (int)criterios[c].Pontos;
            }

            return values;
        }

        public IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.BolaoCriterioPontos> res = Dao.LoadCriteriosPontos(base.CurrentUserName, DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Busca de pontos dos critérios do bolão [" + bolao.Nome + "] total: " + res.Count));
            }
            return res;
        }
        
        #endregion
    }
}
