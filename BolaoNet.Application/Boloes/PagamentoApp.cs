﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class PagamentoApp :
        Base.GenericApp<Domain.Entities.Boloes.Pagamento>,
        Application.Interfaces.Boloes.IPagamentoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IPagamentoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IPagamentoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PagamentoApp" />.
        /// </summary>
        public PagamentoApp(Domain.Interfaces.Services.Boloes.IPagamentoService service)
            : base (service)
        {

        }

        #endregion

        #region IPagamentoApp members

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolao(bolao);
        }

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolaoSoma(bolao);
        }

        #endregion
    }
}
