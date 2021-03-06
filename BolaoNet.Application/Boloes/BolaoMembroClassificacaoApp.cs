﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroClassificacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroClassificacao>,
        Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroClassificacaoApp" />.
        /// </summary>
        public BolaoMembroClassificacaoApp(Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoMembroClassificacaoApp members

        public IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, int? rodada)
        {
            return Service.LoadClassificacao(bolao, rodada);
        }

        #endregion
    }
}
