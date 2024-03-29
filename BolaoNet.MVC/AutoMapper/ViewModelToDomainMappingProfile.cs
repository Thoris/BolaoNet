﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Admin.AdminUserMailViewModel>();
            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Account.RegistrationUserViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Apostas.ApostaJogoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Apostas.ApostaJogoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Account.ActivationCodeViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO, ViewModels.Apostas.ApostasAutomaticasViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO, ViewModels.Apostas.ApostaExtraViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtraUsuario, ViewModels.Apostas.ApostaExtraViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.BolaoClassificacaoVO, ViewModels.Bolao.ClassificacaoViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.BolaoClassificacaoVO, ViewModels.Admin.AdminClassificacaoViewModel>();


            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Admin.AdminJogoViewModel>();
            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Campeonatos.CampeonatoJogoEntryViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.CampeonatoClassificacao, ViewModels.Campeonatos.CampeonatoClassificacaoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Campeonatos.CampeonatoHistorico, ViewModels.Campeonatos.CampeonatoHistoricoViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtra, ViewModels.Resultados.ApostaExtraViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario, ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Bolao.ApostasJogoViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.JogoUsuario, ViewModels.Bolao.ApostaJogoUsuarioPontosViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtraUsuario, ViewModels.Bolao.ApostasExtrasUsuariosPontosViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtra, ViewModels.Bolao.ApostasExtrasEntryViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Bolao.ApostaJogoUsuarioEntryViewModel>();


            Mapper.CreateMap<Domain.Entities.Boloes.BolaoCriterioPontos, ViewModels.Pontuacao.BolaoCriterioPontosViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.BolaoCriterioPontosTimes, ViewModels.Pontuacao.BolaoCriterioTimeViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.BolaoRegra, ViewModels.Regras.BolaoRegrasViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.Pagamento, ViewModels.Pagamentos.PagamentoViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.UserBoloesVO, ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoPosicoesViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.UserSaldoBolaoVO, ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoSaldoDevedorViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO, ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO, ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel>();


            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Users.PaginaPrincipal.PaginaPrincipalProximaApostaViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Users.PaginaPrincipal.PaginaPrincipalPontosObtidosViewModel>();


            Mapper.CreateMap<Domain.Entities.Boloes.Bolao, ViewModels.Admin.BolaoIniciarPararViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.UserMembroStatusVO, ViewModels.Admin.BolaoIniciarStatusMembroViewModel>();


            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Admin.UserProfileViewModel>();
            Mapper.CreateMap<Domain.Entities.Users.Role, ViewModels.Admin.RoleViewModel>();

            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Users.UserProfileViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.Pagamento, ViewModels.Pagamentos.PagamentoViewModel>();


            Mapper.CreateMap<Domain.Entities.Boloes.BolaoPremio, ViewModels.Bolao.PremioViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.BolaoPremio, ViewModels.Admin.AdminPremioViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.CampeonatoRecordVO, ViewModels.Campeonatos.CampeonatoRecordsViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.Mensagem, ViewModels.Mensagens.MensagemViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.BolaoHistorico, ViewModels.Bolao.BolaoHistoricoViewModel>();
            Mapper.CreateMap<Domain.Entities.LogReporting.LogEvent, ViewModels.LogReporting.LogEventViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Bolao.BolaoComparacaoApostaJogoViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.BolaoPremiacao, ViewModels.Bolao.BolaoPremiacaoViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.Notification.PremioObject, ViewModels.Admin.AdminPremioViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.Notification.ClassificacaoObject, ViewModels.Admin.AdminClassificacaoViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.Notification.JogoObject, ViewModels.Admin.AdminJogoViewModel>();

        }
    }
}