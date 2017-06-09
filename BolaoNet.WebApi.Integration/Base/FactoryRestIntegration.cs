using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Base
{
    public class FactoryRestIntegration : Domain.Interfaces.Services.IFactoryService
    {
        #region Variables

        /// <summary>
        /// Variável que armazena a url usada para requisições via REST.
        /// </summary>
        private static string _url;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        public FactoryRestIntegration()
        {

        }
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        /// <param name="url">Url de conexão.</param>
        public FactoryRestIntegration(string url)
        {
            _url = url;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Método que carrega a url para realização das chamadas de integração.
        /// </summary>
        /// <returns>Url configurada.</returns>
        protected static string GetUrl()
        {
            //Se não existe url carregada
            if (string.IsNullOrEmpty(_url))
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];

                if (!string.IsNullOrEmpty(url))
                {
                    _url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];
                }
                else
                {
                    _url = "http://localhost:1230/";
                }
            }//endif url null

            return _url;

        }

        #endregion

        #region IFactoryService members

        //public Domain.Interfaces.Services.IJogadorService CreateJogador()
        //{
        //    return new JogadorIntegration(GetUrl());
        //}

        //public Domain.Interfaces.Services.IModalidadeService CreateModalidade()
        //{
        //    return new ModalidadeIntegration(GetUrl());
        //}

        public Domain.Interfaces.Services.Boloes.IApostaExtraService CreateApostaExtraService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IApostaPontosService CreateApostaPontosService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IApostasRestantesService CreateApostasRestantesService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoService CreateBolaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroService CreateBolaoMembroService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPremioService CreateBolaoPremioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRegraService CreateBolaoRegraService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestService CreateBolaoRequestService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.ICriterioService CreateCriterioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IJogoUsuarioService CreateJogoUsuarioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IMensagemService CreateMensagemService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IPagamentoService CreatePagamentoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Boloes.IPontuacaoService CreatePontuacaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoService CreateCampeonatoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.IHistoricoService CreateHistoricoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.IJogoService CreateJogoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService CreateCriterioFixoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.DadosBasicos.IEstadioService CreateEstadioService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.DadosBasicos.ITimeService CreateTimeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Users.IRoleService CreateRoleService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Users.IUserService CreateUserService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Users.IUserInRoleService CreateUserInRoleService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.IBolaoFacadeService CreateBolaoFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.ICampeonatoFacadeService CreateCampeonatoFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.IInitializationFacadeService CreateInitializationFacadeService()
        {
            throw new NotImplementedException();
        }

        public Domain.Interfaces.Services.Facade.IUserFacadeService CreateUserFacadeService()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
