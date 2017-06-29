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
            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Account.RegistrationUserViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.JogoUsuarioVO, ViewModels.Apostas.ApostaJogoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Apostas.ApostaJogoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Users.User, ViewModels.Account.ActivationCodeViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO, ViewModels.Apostas.ApostasAutomaticasViewModel>();
            Mapper.CreateMap<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO, ViewModels.Apostas.ApostaExtraViewModel>();
            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtraUsuario, ViewModels.Apostas.ApostaExtraViewModel>();

            Mapper.CreateMap<Domain.Entities.ValueObjects.BolaoClassificacaoVO, ViewModels.Bolao.ClassificacaoViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Campeonatos.CampeonatoJogoEntryViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.Jogo, ViewModels.Resultados.JogoResultadoViewModel>();

            Mapper.CreateMap<Domain.Entities.Campeonatos.CampeonatoClassificacao, ViewModels.Campeonatos.CampeonatoClassificacaoEntryViewModel>();
            Mapper.CreateMap<Domain.Entities.Campeonatos.CampeonatoHistorico, ViewModels.Campeonatos.CampeonatoHistoricoViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.ApostaExtra, ViewModels.Resultados.ApostaExtraViewModel>();

            Mapper.CreateMap<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario, ViewModels.Bolao.CampeonatoClassificacaoApostaEntryViewModel>();

        }
    }
}