﻿using BolaoNet.Domain.Entities.Boloes;
using BolaoNet.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Boloes
{
    public class BolaoMembroIntegration :
        Base.GenericIntegration<Domain.Entities.Boloes.BolaoMembro>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "BolaoMembro";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public BolaoMembroIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IBolaoMembroService members

        public IList<Domain.Entities.Boloes.BolaoMembro> GetListUsersInBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Boloes.BolaoMembro>>(
                new Dictionary<string, string>(), bolao, "GetListUsersInBolao").ToList<Domain.Entities.Boloes.BolaoMembro>();
        }
        public IList<Domain.Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Boloes.BolaoMembro>>(
                new Dictionary<string, string>(), user, "GetListBolaoInUsers").ToList<Domain.Entities.Boloes.BolaoMembro>();
        }
        public IList<Domain.Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(Domain.Entities.Boloes.Bolao bolao)
        {
            return base.HttpPostApi<IList<Domain.Entities.ValueObjects.UserMembroStatusVO>>(
             new Dictionary<string, string>(), bolao, "GetUserStatus").ToList<Domain.Entities.ValueObjects.UserMembroStatusVO>();
        
        }
        public bool RemoverMembroBolao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Boloes.BolaoMembro membro)
        {
            return base.HttpPostApi<bool>(
                new Dictionary<string, string>(), membro, "RemoverMembroBolao");        
        }
        public IList<User> GetUsersToNotificate(Bolao bolao)
        {
            return base.HttpGetApi<IList<User>>(
                new Dictionary<string, string>(), bolao, "GetUsersToNotificate");
        }

        #endregion
    }
}
