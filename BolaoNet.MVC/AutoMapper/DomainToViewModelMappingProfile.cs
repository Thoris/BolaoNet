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


        }
    }
}