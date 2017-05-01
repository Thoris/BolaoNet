using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Base
{
    /// <summary>
    /// Classe que possui o gerenciamento básico da comunicação REST.
    /// </summary>
    public class JsonBase
    {
        #region Variables

        /// <summary>
        /// Variável que armazena a url da aplicação.
        /// </summary>
        private string _url;
        /// <summary>
        /// Controlador da chamada da api.
        /// </summary>
        private string _controller;

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade que retorna a URL que possui o comando do caminho a ser executada a função.
        /// </summary>
        protected string UrlCommand
        {
            get
            {
                string result = _url + "/api/" + _controller;

                if (!result.EndsWith("/"))
                    result += "/";

                return result;

            }
        }

        #endregion

        #region Constructors/Destructors


        /// <summary>
        /// Inicializa nova instância da classe <see cref="JsonBase"/>.
        /// </summary>
        /// <param name="url">Url que possui o caminho do servidor.</param>
        /// <param name="controller">Controlador da API a ser executado o comando.</param>
        public JsonBase(string url, string controller)
        {
            _url = url;
            _controller = controller;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Propriedade que retorna o objeto usado para chamada das funcionalidades rest.
        /// </summary>
        /// <returns>Objeto HttpClient</returns>
        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            return client;
        }
        /// <summary>
        /// Método que verifica se o tipo genérico possui parte do tipo a ser analisado.
        /// </summary>
        /// <param name="generic">Tipo de dados a ser verificado.</param>
        /// <param name="toCheck">Tipo de objeto a ser comparado.</param>
        /// <returns>true se o tipo comparado está no hierarquia do tipo analisado.</returns>
        protected bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
        /// <summary>
        /// Método que efetua operação de get do método especificado.
        /// </summary>
        /// <param name="parameters">Lista de parâmetros.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <param name="message">Mensagem de saída da operação executada.</param>
        /// <returns>true se conseguiu concluir a operação com sucesso.</returns>
        protected bool HttpGetApi(IDictionary<string, string> parameters, object data, string method, out string message)
        {
            message = null;

            string queryString = "";

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (queryString.Length != 0)
                    {
                        queryString += "&";
                    }

                    queryString += pair.Key + "=" + pair.Value;
                }
            }

            //Creating the request
            HttpClient client = GetClient();

            var dataSerialized = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");


            //Requesting the post
            var response = client.PostAsync(new Uri(this.UrlCommand) + method + "?" + queryString, content).Result;

            //If could process the request sucessfully
            if (response.IsSuccessStatusCode)
            {
                //Getting the string processed
                var jsonString = response.Content.ReadAsStringAsync();

                message = jsonString.Result;

                return true;
            }
            else
            {
                message = response.ToString();

                return false;
            }
        }
        /// <summary>
        /// Método que efetua operação de get do método especificado.
        /// </summary>
        /// <param name="parameters">Lista de parâmetros.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <param name="message">Mensagem de saída da operação executada.</param>
        /// <returns>true se conseguiu concluir a operação com sucesso.</returns>
        protected bool HttpGetApi(IDictionary<string, string> parameters, string method, out string message)
        {
            message = null;

            //Creating the request
            HttpClient client = GetClient();

            string queryString = "";

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (queryString.Length != 0)
                    {
                        queryString += "&";
                    }

                    queryString += pair.Key + "=" + pair.Value;
                }
            }

            //Requesting the post
            //var response = client.GetAsync(new Uri(this.UrlCommand) + method + "?" + queryString).Result;

            var response = client.GetAsync(new Uri(this.UrlCommand) + method + "?" + queryString).Result;


            //If could process the request sucessfully
            if (response.IsSuccessStatusCode)
            {
                //Getting the string processed
                var jsonString = response.Content.ReadAsStringAsync();

                message = jsonString.Result;

                return true;
            }
            else
            {
                message = response.ToString();

                return false;
            }
        }

        /// <summary>
        /// Método que efetua operação de POST no método especificado.
        /// </summary>
        /// <param name="parameters">Lista de parâmetros para execução da operação.</param>
        /// <param name="data">Objeto a ser atribuído para execução da operação.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <param name="message">Mensagem de retorno da execução do método.</param>
        /// <returns>true se conseguiu efetuar a operação com sucesso.</returns>
        protected bool HttpPostApi(IDictionary<string, string> parameters, object data, string method, out string message)
        {
            message = null;

            string queryString = "";

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (queryString.Length != 0)
                    {
                        queryString += "&";
                    }

                    queryString += pair.Key + "=" + pair.Value;
                }
            }

            //Creating the request
            HttpClient client = GetClient();

            var dataSerialized = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");


            //Requesting the post
            //HttpResponseMessage response = client.PostAsync(new Uri(this.UrlCommand) + method + "?" + queryString, content).Result;


            HttpResponseMessage response = client.PostAsync(new Uri(this.UrlCommand) + method, content).Result;


            //If could process the request sucessfully
            if (response.IsSuccessStatusCode)
            {
                //Getting the string processed
                var jsonString = response.Content.ReadAsStringAsync();

                message = jsonString.Result;

                return true;
            }
            else
            {
                message = response.ToString();

                return false;
            }
        }

        /// <summary>
        /// Método que efetua operação de Delete do método especificado.
        /// </summary>
        /// <param name="parameters">Parâmetros de execução.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <param name="message">Mensagem de retorno.</param>
        /// <returns>
        /// true se conseguiu executar o método com sucesso.
        /// </returns>
        protected bool HttpDeleteApi(IDictionary<string, string> parameters, string method, out string message)
        {
            message = null;

            string queryString = "";

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (queryString.Length != 0)
                    {
                        queryString += "&";
                    }

                    queryString += pair.Key + "=" + pair.Value;
                }
            }

            //Creating the request
            HttpClient client = GetClient();

            //Requesting the post
            var response = client.DeleteAsync(new Uri(this.UrlCommand) + method + "?" + queryString).Result;

            //If could process the request sucessfully
            if (response.IsSuccessStatusCode)
            {
                //Getting the string processed
                var jsonString = response.Content.ReadAsStringAsync();

                message = jsonString.Result;

                return true;
            }
            else
            {
                message = response.ToString();

                return false;
            }
        }

        /// <summary>
        /// Método que efetua operação de PUT no método especificado.
        /// </summary>
        /// <param name="parameters">Lista de parâmetros para execução da operação.</param>
        /// <param name="data">Objeto a ser atribuído para execução da operação.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <param name="message">Mensagem de retorno da execução do método.</param>
        /// <returns>true se conseguiu efetuar a operação com sucesso.</returns>
        protected bool HttpPutApi(IDictionary<string, string> parameters, object data, string method, out string message)
        {
            message = null;

            string queryString = "";

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    if (queryString.Length != 0)
                    {
                        queryString += "&";
                    }

                    queryString += pair.Key + "=" + pair.Value;
                }
            }

            //Creating the request
            HttpClient client = GetClient();

            var dataSerialized = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(dataSerialized, Encoding.UTF8, "application/json");


            //Requesting the post
            var response = client.PostAsync(new Uri(this.UrlCommand) + method + "?" + queryString, content).Result;

            //If could process the request sucessfully
            if (response.IsSuccessStatusCode)
            {
                //Getting the string processed
                var jsonString = response.Content.ReadAsStringAsync();

                message = jsonString.Result;

                return true;
            }
            else
            {
                message = response.ToString();

                return false;
            }
        }

        #endregion
    }
}
