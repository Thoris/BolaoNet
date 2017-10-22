using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration
{
    public class FactoryIntegration : Domain.Interfaces.Services.IFactoryService
    {
        #region Variables

        private string _userName;
        private string _url;

        #endregion

        #region Constructors/Destructors

        public FactoryIntegration(string userName, string url)
        {
            _userName = userName;
            _url = url;
        }

        #endregion

        #region Methods

        public static string GetToken()
        {
            return "";
        }

        #endregion

        #region IFactoryService members

        public Domain.Interfaces.Services.Boloes.IApostaExtraService CreateApostaExtraService()
        {
            return new Boloes.ApostaExtraIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService()
        {
            return new Boloes.ApostaExtraUsuarioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IApostaPontosService CreateApostaPontosService()
        {
            return new Boloes.ApostaPontosIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IApostasRestantesService CreateApostasRestantesService()
        {
            return new Boloes.ApostasRestantesIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoService CreateBolaoService()
        {
            return new Boloes.BolaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService()
        {
            return new Boloes.BolaoCriterioPontosIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService()
        {
            return new Boloes.BolaoCriterioPontosTimesIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroService CreateBolaoMembroService()
        {
            return new Boloes.BolaoMembroIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService()
        {
            return new Boloes.BolaoMembroClassificacaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService()
        {
            return new Boloes.BolaoMembroGrupoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService()
        {
            return new Boloes.BolaoPontoRodadaIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService()
        {
            return new Boloes.BolaoPontoRodadaUsuarioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService()
        {
            return new Boloes.BolaoPontuacaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPremioService CreateBolaoPremioService()
        {
            return new Boloes.BolaoPremioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRegraService CreateBolaoRegraService()
        {
            return new Boloes.BolaoRegraIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestService CreateBolaoRequestService()
        {
            return new Boloes.BolaoRequestIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService()
        {
            return new Boloes.BolaoRequestStatusIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.ICriterioService CreateCriterioService()
        {
            return new Boloes.CriterioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IJogoUsuarioService CreateJogoUsuarioService()
        {
            return new Boloes.JogoUsuarioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IMensagemService CreateMensagemService()
        {
            return new Boloes.MensagemIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IPagamentoService CreatePagamentoService()
        {
            return new Boloes.PagamentoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Boloes.IPontuacaoService CreatePontuacaoService()
        {
            return new Boloes.PontuacaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoService CreateCampeonatoService()
        {
            return new Campeonatos.CampeonatoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService()
        {
            return new Campeonatos.CampeonatoClassificacaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService()
        {
            return new Campeonatos.CampeonatoFaseIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService()
        {
            return new Campeonatos.CampeonatoGrupoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService()
        {
            return new Campeonatos.CampeonatoGrupoTimeIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService()
        {
            return new Campeonatos.CampeonatoHistoricoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService()
        {
            return new Campeonatos.CampeonatoPosicaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService()
        {
            return new Campeonatos.CampeonatoRecordIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService()
        {
            return new Campeonatos.CampeonatoTimeIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.IHistoricoService CreateHistoricoService()
        {
            return new Campeonatos.HistoricoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.IJogoService CreateJogoService()
        {
            return new Campeonatos.JogoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService()
        {
            return new Campeonatos.PontuacaoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService CreateCriterioFixoService()
        {
            return new DadosBasicos.CriterioFixoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.DadosBasicos.IEstadioService CreateEstadioService()
        {
            return new DadosBasicos.EstadioIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService()
        {
            return new DadosBasicos.PagamentoTipoIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.DadosBasicos.ITimeService CreateTimeService()
        {
            return new DadosBasicos.TimeIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Users.IRoleService CreateRoleService()
        {
            return new Users.RoleIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Users.IUserService CreateUserService()
        {
            return new Users.UserIntegration(_url, GetToken());
        }

        public Domain.Interfaces.Services.Users.IUserInRoleService CreateUserInRoleService()
        {
            return new Users.UserInRoleIntegration(_url, GetToken());
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
