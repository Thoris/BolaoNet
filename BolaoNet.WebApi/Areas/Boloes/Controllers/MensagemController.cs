using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class MensagemController:
        GenericApiController<Domain.Entities.Boloes.Mensagem>, 
        Domain.Interfaces.Services.Boloes.IMensagemService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IMensagemService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IMensagemService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public MensagemController()
        //    : base(new Domain.Services.FactoryService(null).CreateMensagemService())
        //{

        //}
        public MensagemController(Domain.Interfaces.Services.Boloes.IMensagemService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IMensagemService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(int id, ArrayList data)
        {


            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Users.User user;


            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());

            return Service.GetMensagensUsuario(bolao, user);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetMensagensUsuario(bolao, user);
        }
        [HttpPost]
        public override bool Delete(Domain.Entities.Boloes.Mensagem entity)
        {
            Domain.Entities.Boloes.Mensagem entityLoaded = base.Load(entity);

            return base.Delete(entityLoaded);
        }
        [HttpPost]
        public int GetTotalMensagensNaoLidas(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Users.User user;


            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());

            return Service.GetTotalMensagensNaoLidas(bolao, user);
        }
        [HttpPost]
        public int GetTotalMensagensNaoLidas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetTotalMensagensNaoLidas(bolao, user);
        }
        [HttpPost]
        public void SetMensagensLidas(int id, ArrayList data)
        {
            Domain.Entities.Boloes.Bolao bolao;
            Domain.Entities.Users.User user;


            bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(data[0].ToString());
            user = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(data[1].ToString());

            Service.SetMensagensLidas(bolao, user);
        }
        [HttpPost]
        public void SetMensagensLidas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Service.SetMensagensLidas(bolao, user);
        }
        #endregion


    }
}