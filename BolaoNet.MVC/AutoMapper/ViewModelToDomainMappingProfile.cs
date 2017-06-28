using AutoMapper;
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

        }
    }
}