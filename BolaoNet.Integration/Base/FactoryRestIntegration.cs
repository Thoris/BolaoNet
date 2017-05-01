using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Base
{
    public class FactoryRestIntegration : Business.Interfaces.IFactoryBO
    {
        #region Variables

        /// <summary>
        /// Variável que armazena a url usada para requisições via REST.
        /// </summary>
        private static string _url;

        #endregion


        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        public FactoryRestIntegration()
        {

        }
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        /// <param name="url">Url de conexão.</param>
        public FactoryRestIntegration(string url)
        {
            _url = url;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Método que carrega a url para realização das chamadas de integração.
        /// </summary>
        /// <returns>Url configurada.</returns>
        protected static string GetUrl()
        {
            //Se não existe url carregada
            if (string.IsNullOrEmpty(_url))
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];

                if (!string.IsNullOrEmpty(url))
                {
                    _url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];
                }
                else
                {
                    _url = "http://localhost:1230/";
                }
            }//endif url null

            return _url;

        }

        #endregion


        #region IFactoryBO members

        //public Business.Interfaces.IJogadorBO CreateJogador()
        //{
        //    return new JogadorIntegration(GetUrl());
        //}

        //public Business.Interfaces.IModalidadeBO CreateModalidade()
        //{
        //    return new ModalidadeIntegration(GetUrl());
        //}

        #endregion
    }
}
