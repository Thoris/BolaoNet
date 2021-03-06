﻿using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class ApostaExtraService : 
        Base.BaseGenericService<Entities.Boloes.ApostaExtra>,
        Interfaces.Services.Boloes.IApostaExtraService
    {

        #region Properties
        
        private Interfaces.Repositories.Boloes.IApostaExtraDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IApostaExtraDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraService(string userName, Interfaces.Repositories.Boloes.IApostaExtraDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.ApostaExtra>)dao, logging)
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

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.ApostaExtra> res = Dao.GetApostasBolao(this.CurrentUserName,DateTime.Now, bolao);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Apostas do bolão: [" + bolao.Nome + "] carregados : " + res.Count));
            }

            return res;
        }
        public bool InsertResult(Entities.Boloes.Bolao bolao, Entities.DadosBasicos.Time time, int posicao, Entities.Users.User validadoBy)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (time == null)
                throw new ArgumentException("time");
            if (string.IsNullOrEmpty(time.Nome))
                throw new ArgumentException("time.Nome");
            if (posicao == 0)
                throw new ArgumentException("posicao");
            if (validadoBy == null)
                throw new ArgumentException("validadoBy");
            if (string.IsNullOrEmpty(validadoBy.UserName))
                throw new ArgumentException("validadoBy.UserName");

            if (IsSaveLog)
                CheckStart();

            bool res = Dao.InsertResult(this.CurrentUserName, DateTime.Now, bolao, time, posicao, validadoBy);

            if (IsSaveLog)
            {
                if (res)
                    _logging.Info(this, GetMessageTotalTime("Resultado do bolão: [" + bolao.Nome + "] da posição: [" + posicao + "] time: ["+ time.Nome + "] : " + res));
                else
                    _logging.Warn(this, GetMessageTotalTime("Resultado do bolão: [" + bolao.Nome + "] da posição: [" + posicao + "] time: [" + time.Nome + "] : " + res));
            }

            return res;
        }

        #endregion


    }
}
