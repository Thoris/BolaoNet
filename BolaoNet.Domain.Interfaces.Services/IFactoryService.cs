using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services
{
    public interface IFactoryService
    {
        Boloes.IApostaExtraService CreateApostaExtraService();
        Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService();
        Boloes.IApostaPontosService CreateApostaPontosService();
        Boloes.IApostasRestantesService CreateApostasRestantesService();
        Boloes.IBolaoService CreateBolaoService();
        Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService();
        Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService();
        Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService();
        Boloes.IBolaoMembroService CreateBolaoMembroService();
        Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService();
        Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService();
        Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService();
        Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService();
        Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService();
        Boloes.IBolaoPremioService CreateBolaoPremioService();
        Boloes.IBolaoRegraService CreateBolaoRegraService();
        Boloes.IBolaoRequestService CreateBolaoRequestService();
        Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService();
        Boloes.ICriterioService CreateCriterioService();
        Boloes.IJogoUsuarioService CreateJogoUsuarioService();
        Boloes.IMensagemService CreateMensagemService();
        Boloes.IPagamentoService CreatePagamentoService();
        Boloes.IPontuacaoService CreatePontuacaoService();

        Campeonatos.ICampeonatoService CreateCampeonatoService();
        Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService();
        Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService();
        Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService();
        Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService();
        Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService();
        Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService();
        Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService();
        Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService();
        Campeonatos.IHistoricoService CreateHistoricoService();
        Campeonatos.IJogoService CreateJogoService();
        Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService();

        DadosBasicos.ICriterioFixoService CreateCriterioFixoService();
        DadosBasicos.IEstadioService CreateEstadioService();
        DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService();
        DadosBasicos.ITimeService CreateTimeService();

        Users.IRoleService CreateRoleService();
        Users.IUserService CreateUserService();
        Users.IUserInRoleService CreateUserInRoleService();

        Facade.IBolaoFacadeService CreateBolaoFacadeService();
        Facade.ICampeonatoFacadeService CreateCampeonatoFacadeService();
        Facade.IInitializationFacadeService CreateInitializationFacadeService();
        Facade.IUserFacadeService CreateUserFacadeService();

    }
}
