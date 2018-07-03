using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ViewModels.Account.RegistrationUserViewModel, Domain.Entities.Users.User>();
            Mapper.CreateMap<ViewModels.Apostas.ApostaJogoEntryViewModel, Domain.Entities.ValueObjects.JogoUsuarioVO>();
            Mapper.CreateMap<ViewModels.Apostas.ApostaJogoEntryViewModel, Domain.Entities.Campeonatos.Jogo>();

            Mapper.CreateMap<ViewModels.Account.ActivationCodeViewModel, Domain.Entities.Users.User>();
            Mapper.CreateMap<ViewModels.Apostas.ApostasAutomaticasViewModel, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO>();

            Mapper.CreateMap<ViewModels.Apostas.ApostaExtraViewModel, Domain.Entities.ValueObjects.ApostaExtraUsuarioVO>();
            Mapper.CreateMap<ViewModels.Apostas.ApostaExtraViewModel, Domain.Entities.Boloes.ApostaExtraUsuario>();

            Mapper.CreateMap<ViewModels.Bolao.ClassificacaoViewModel, Domain.Entities.ValueObjects.BolaoClassificacaoVO>();

            Mapper.CreateMap<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel, Domain.Entities.Campeonatos.Jogo>();
            Mapper.CreateMap<ViewModels.Resultados.JogoResultadoViewModel, Domain.Entities.Campeonatos.Jogo>();

            Mapper.CreateMap<ViewModels.Campeonatos.CampeonatoClassificacaoEntryViewModel, Domain.Entities.Campeonatos.CampeonatoClassificacao>();
            Mapper.CreateMap<ViewModels.Campeonatos.CampeonatoHistoricoViewModel, Domain.Entities.Campeonatos.CampeonatoHistorico>();

            Mapper.CreateMap<ViewModels.Resultados.ApostaExtraViewModel, Domain.Entities.Boloes.ApostaExtra>();

            Mapper.CreateMap<ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel, Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>();


            Mapper.CreateMap<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel, Domain.Entities.ValueObjects.JogoUsuarioVO>();

            Mapper.CreateMap<ViewModels.Bolao.ApostasJogoViewModel, Domain.Entities.Campeonatos.Jogo>();
            Mapper.CreateMap<ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel, Domain.Entities.Boloes.JogoUsuario>();


            Mapper.CreateMap<ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel, Domain.Entities.Boloes.ApostaExtraUsuario>();
            Mapper.CreateMap<ViewModels.Bolao.ApostasExtrasEntryViewModel, Domain.Entities.Boloes.ApostaExtra>();


            Mapper.CreateMap<ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel, Domain.Entities.Campeonatos.Jogo>();


            Mapper.CreateMap<ViewModels.Pontuacao.BolaoCriterioPontosViewModel, Domain.Entities.Boloes.BolaoCriterioPontos>();
            Mapper.CreateMap<ViewModels.Pontuacao.BolaoCriterioTimeViewModel, Domain.Entities.Boloes.BolaoCriterioPontosTimes>();

            Mapper.CreateMap<ViewModels.Regras.BolaoRegrasViewModel, Domain.Entities.Boloes.BolaoRegra>();

            Mapper.CreateMap<ViewModels.Pagamentos.PagamentoViewModel, Domain.Entities.Boloes.Pagamento>();

            Mapper.CreateMap<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoPosicoesViewModel, Domain.Entities.ValueObjects.UserBoloesVO>();
            Mapper.CreateMap<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoSaldoDevedorViewModel, Domain.Entities.ValueObjects.UserSaldoBolaoVO>();


            Mapper.CreateMap<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView, Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>();
            Mapper.CreateMap<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel, Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>();


            Mapper.CreateMap<ViewModels.Users.PaginaPrincipal.PaginaPrincipalProximaApostaViewModel, Domain.Entities.ValueObjects.JogoUsuarioVO>();
            Mapper.CreateMap<ViewModels.Users.PaginaPrincipal.PaginaPrincipalPontosObtidosViewModel, Domain.Entities.ValueObjects.JogoUsuarioVO>();

            Mapper.CreateMap<ViewModels.Admin.BolaoIniciarPararViewModel, Domain.Entities.Boloes.Bolao>();

            Mapper.CreateMap<ViewModels.Admin.BolaoIniciarStatusMembroViewModel, Domain.Entities.ValueObjects.UserMembroStatusVO>();

            Mapper.CreateMap<ViewModels.Users.UserProfileViewModel, Domain.Entities.Users.User>();


            Mapper.CreateMap<ViewModels.Pagamentos.PagamentoViewModel, Domain.Entities.Boloes.Pagamento>();

            Mapper.CreateMap<ViewModels.Bolao.PremioViewModel, Domain.Entities.Boloes.BolaoPremio>();

            Mapper.CreateMap<ViewModels.Campeonatos.CampeonatoRecordsViewModel, Domain.Entities.ValueObjects.CampeonatoRecordVO>();


            Mapper.CreateMap<ViewModels.Mensagens.MensagemViewModel, Domain.Entities.Boloes.Mensagem>();
            Mapper.CreateMap<ViewModels.Bolao.BolaoHistoricoViewModel, Domain.Entities.Boloes.BolaoHistorico>();
            Mapper.CreateMap<ViewModels.LogReporting.LogEventViewModel, Domain.Entities.LogReporting.LogEvent>();

            Mapper.CreateMap<ViewModels.Bolao.BolaoComparacaoApostaJogoViewModel, Domain.Entities.ValueObjects.JogoUsuarioVO>();

            Mapper.CreateMap<ViewModels.Bolao.BolaoPremiacaoViewModel, Domain.Entities.Boloes.BolaoPremiacao>();
 

        }
    }
}