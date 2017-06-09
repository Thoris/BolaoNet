using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoController :
        GenericApiController<Domain.Entities.Boloes.Bolao>, 
        Domain.Interfaces.Services.Boloes.IBolaoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoController()
            : base(new Domain.Services.FactoryService().CreateBolaoService())
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoService members


        //http://www.dotnettricks.com/learn/webapi/passing-multiple-complex-type-parameters-to-aspnet-web-api

        [HttpPost]
        //public bool Iniciar(int id, ArrayList data)
        public bool Iniciar(ArrayList data)
        {
            //Domain.Entities.Users.User iniciadoBy = parameters["iniciadoBy"].ToObject<Domain.Entities.Users.User>();
            //Domain.Entities.Boloes.Bolao bolao = parameters["bolao"].ToObject<Domain.Entities.Boloes.Bolao>();


            Domain.Entities.Users.User iniciadoBy = null;
            Domain.Entities.Boloes.Bolao bolao = null;


            //iniciadoBy = (Domain.Entities.Users.User)data[0];
            //bolao = (Domain.Entities.Boloes.Bolao) data[1];

            //iniciadoBy = (Domain.Entities.Users.User)data[0];
            //bolao = (Domain.Entities.Boloes.Bolao)data[1];

            ////make sure the post we have contains multi-part data
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            ////read data
            //var provider = new MultipartMemoryStreamProvider();
            //Request.Content.ReadAsMultipartAsync(provider);

            ////declare backup file summary and file data vars
            //var content = new Content();
            
            ////iterate over contents to get Content and Config
            //foreach (var requestContents in provider.Contents)
            //{
            //    if (requestContents.Headers.ContentDisposition.Name == "Content")
            //    {
            //        content = JsonConvert.DeserializeObject<Content>(requestContents.ReadAsStringAsync().Result);
            //    }
            //    else if (string.Compare (requestContents.Headers.ContentDisposition.Name, "iniciadoBy", true) == 0)
            //    {
            //        iniciadoBy = JsonConvert.DeserializeObject<Domain.Entities.Users.User>(requestContents.ReadAsStringAsync().Result);
            //    }
            //    else if (string.Compare(requestContents.Headers.ContentDisposition.Name, "bolao", true) == 0)
            //    {
            //        bolao = JsonConvert.DeserializeObject<Domain.Entities.Boloes.Bolao>(requestContents.ReadAsStringAsync().Result);
            //    }
            //}


            return Iniciar(iniciadoBy, bolao);
        }
        [HttpPost]
        public bool Iniciar(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.Iniciar(iniciadoBy, bolao);
        }
        [HttpPost]
        public bool Aguardar(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.Aguardar(bolao);
        }

        #endregion
    }
}