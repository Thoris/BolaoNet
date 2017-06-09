using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application
{
    public class FactoryApp : Domain.Interfaces.Services.IFactoryService
    {
        #region Variables

        private string _userName;
        private string _url;

        #endregion

        #region Constructors/Destructors

        public FactoryApp(string userName, string url)
        {
            _userName = userName;
            _url = url;
        }

        #endregion

        #region IFactoryService members

        public Domain.Interfaces.Services.Boloes.IApostaExtraService CreateApostaExtraService()
        {
            return new Boloes.ApostaExtraApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService()
        {
            return new Boloes.ApostaExtraUsuarioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IApostaPontosService CreateApostaPontosService()
        {
            return new Boloes.ApostaPontosApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IApostasRestantesService CreateApostasRestantesService()
        {
            return new Boloes.ApostasRestantesApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoService CreateBolaoService()
        {
            return new Boloes.BolaoApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService()
        {
            return new Boloes.BolaoCriterioPontosApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService()
        {
            return new Boloes.BolaoCriterioPontosTimesApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroService CreateBolaoMembroService()
        {
            return new Boloes.BolaoMembroApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService()
        {
            return new Boloes.BolaoMembroClassificacaoApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService()
        {
            return new Boloes.BolaoMembroGrupoApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService()
        {
            return new Boloes.BolaoPontoRodadaApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService()
        {
            return new Boloes.BolaoPontoRodadaUsuarioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService()
        {
            return new Boloes.BolaoPontuacaoApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoPremioService CreateBolaoPremioService()
        {
            return new Boloes.BolaoPremioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRegraService CreateBolaoRegraService()
        {
            return new Boloes.BolaoRegraApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestService CreateBolaoRequestService()
        {
            return new Boloes.BolaoRequestApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService()
        {
            return new Boloes.BolaoRequestStatusApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.ICriterioService CreateCriterioService()
        {
            return new Boloes.CriterioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IJogoUsuarioService CreateJogoUsuarioService()
        {
            return new Boloes.JogoUsuarioApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IMensagemService CreateMensagemService()
        {
            return new Boloes.MensagemApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IPagamentoService CreatePagamentoService()
        {
            return new Boloes.PagamentoApp(_url);
        }

        public Domain.Interfaces.Services.Boloes.IPontuacaoService CreatePontuacaoService()
        {
            return new Boloes.PontuacaoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoService CreateCampeonatoService()
        {
            return new Campeonatos.CampeonatoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService()
        {
            return new Campeonatos.CampeonatoClassificacaoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService()
        {
            return new Campeonatos.CampeonatoFaseApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService()
        {
            return new Campeonatos.CampeonatoGrupoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService()
        {
            return new Campeonatos.CampeonatoGrupoTimeApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService()
        {
            return new Campeonatos.CampeonatoHistoricoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService()
        {
            return new Campeonatos.CampeonatoPosicaoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService()
        {
            return new Campeonatos.CampeonatoRecordApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService()
        {
            return new Campeonatos.CampeonatoTimeApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.IHistoricoService CreateHistoricoService()
        {
            return new Campeonatos.HistoricoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.IJogoService CreateJogoService()
        {
            return new Campeonatos.JogoApp(_url);
        }

        public Domain.Interfaces.Services.Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService()
        {
            return new Campeonatos.PontuacaoApp(_url);
        }

        public Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService CreateCriterioFixoService()
        {
            return new DadosBasicos.CriterioFixoApp(_url);
        }

        public Domain.Interfaces.Services.DadosBasicos.IEstadioService CreateEstadioService()
        {
            return new DadosBasicos.EstadioApp(_url);
        }

        public Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService()
        {
            return new DadosBasicos.PagamentoTipoApp(_url);
        }

        public Domain.Interfaces.Services.DadosBasicos.ITimeService CreateTimeService()
        {
            return new DadosBasicos.TimeApp(_url);
        }

        public Domain.Interfaces.Services.Users.IRoleService CreateRoleService()
        {
            return new Users.RoleApp(_url);
        }

        public Domain.Interfaces.Services.Users.IUserService CreateUserService()
        {
            return new Users.UserApp(_url);
        }

        public Domain.Interfaces.Services.Users.IUserInRoleService CreateUserInRoleService()
        {
            return new Users.UserInRoleApp(_url);
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
