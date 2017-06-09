using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Base
{
    /// <summary>
    /// Classe que trabalha com o gerenciamento de funcionalidades Json
    /// </summary>
    /// <typeparam name="T">Tipo de entidade a ser gerenciado.</typeparam>
    /// <typeparam name="L">Chave do item da entidade.</typeparam>
    public class JsonManagement : JsonBase
    {
        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JsonManagement" />.
        /// </summary>
        /// <param name="url">Url de conexão com o objeto de conexão com a base.</param>
        /// <param name="controller">Controlador da chamada da API</param>
        public JsonManagement(string url, string controller)
            : base(url, controller)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que efetua um get via rest passando as informações via Json para o servidor.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a ser convertido.</typeparam>
        /// <param name="parameters">Lista de parâmetros</param>
        /// <param name="method">Método a ser executado.</param>
        /// <returns>Objeto recebido e convertido.</returns>
        protected T HttpGetApi<T>(IDictionary<string, string> parameters, object data, string method)
        {
            string message = null;

            bool sucess = HttpGetApi(parameters, data, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
            }

            try
            {
                T result = JsonConvert.DeserializeObject<T>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(T), ex);
            }
        }
        /// <summary>
        /// Método que efetua um get via rest passando as informações via Json para o servidor.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a ser convertido.</typeparam>
        /// <param name="data">Lista de parâmetros</param>
        /// <param name="method">Método a ser executado.</param>
        /// <returns>Objeto recebido e convertido.</returns>
        protected T HttpGetApi<T>(IDictionary<string, string> data, string method)
        {
            string message = null;

            bool sucess = HttpGetApi(data, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
                //T result = (T)Activator.CreateInstance(typeof(T));

                //if (IsSubclassOfRawGeneric(typeof(Entities.Communication.BaseResponse), typeof(T)))
                //{
                //    result.GetType().GetProperty("Message").SetValue(result, message, null);
                //    result.GetType().GetProperty("IsOk").SetValue(result, false, null);
                //}

                //return result;
            }

            try
            {
                T result = JsonConvert.DeserializeObject<T>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(T), ex);
            }
        }
        /// <summary>
        /// Método que efetua o post 
        /// </summary>
        /// <typeparam name="L">Tipo de objeto de retorno.</typeparam>
        /// <param name="parameters">Parâmetros de entrada para execução do método.</param>
        /// <param name="data">Objeto a ser atribuído à execução.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <returns>Retorno dos dados.</returns>
        protected L HttpPostApi<L>(IDictionary<string, string> parameters, object data, string method)
        {
            string message = null;

            bool sucess = HttpPostApi(parameters, data, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
            }

            try
            {
                L result = JsonConvert.DeserializeObject<L>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(L), ex);
            }
        }
        protected L HttpPostApi<L>(IDictionary<string, object> parameters, string method)
        {
            string message = null;

            bool sucess = HttpPostApi(parameters, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
            }

            try
            {
                L result = JsonConvert.DeserializeObject<L>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(L), ex);
            }
        }
        /// <summary>
        /// Método que executa a operação de DELETE do método especificado.
        /// </summary>
        /// <typeparam name="L">Tipo de retorno especificado.</typeparam>
        /// <param name="parameters">Parâmetros de execução do método especificado.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <returns>Tipo de objeto de retorno.</returns>
        protected L HttpDeleteApi<L>(IDictionary<string, string> parameters, string method)
        {
            string message = null;

            bool sucess = HttpDeleteApi(parameters, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
            }

            try
            {
                L result = JsonConvert.DeserializeObject<L>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(L), ex);
            }
        }
        /// <summary>
        /// Método que executa a operação de PUT para o método especificado.
        /// </summary>
        /// <typeparam name="L">Tipo de o</typeparam>
        /// <param name="parameters">Parâmetros de entrada para execução do método.</param>
        /// <param name="data">Objeto a ser aplicado na execução do método.</param>
        /// <param name="method">Nome do método a ser executado.</param>
        /// <returns>Objeto de retorno.</returns>
        protected L HttpPutApi<L>(IDictionary<string, string> parameters, object data, string method)
        {
            string message = null;

            bool sucess = HttpPutApi(parameters, data, method, out message);

            if (sucess == false)
            {
                throw new Exceptions.CommunicationException(message.ToString());
            }

            try
            {
                L result = JsonConvert.DeserializeObject<L>(message);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SerializationException("Error serializating object.", message, typeof(L), ex);
            }
        }


        #region Comments
        ///// <summary>
        ///// Propriedade que retorna o objeto usado para chamada das funcionalidades rest.
        ///// </summary>
        ///// <returns>Objeto HttpClient</returns>
        //private HttpClient GetClient()
        //{
        //    HttpClient client = new HttpClient();

        //    client.BaseAddress = new Uri(_url);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //    return client;
        //}
        ///// <summary>
        ///// Método que realiza o carregamento dos dados.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <param name="max">Quantidade máxima de registros. Caso configurado = 0 ou negativo, retornar todos os registros.</param>
        ///// <returns>
        ///// Lista de itens encontrados.
        ///// </returns>
        //protected ICollection<T> HttpGet(string command, long max)
        //{

        //    string cmd = _url + command;

        //    HttpClient client = GetClient();

        //    HttpResponseMessage response = client.GetAsync(cmd).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string res = response.Content.ReadAsStringAsync().Result;


        //        ICollection<T> list = response.Content.ReadAsAsync<ICollection<T>>().Result;

        //        return list;
        //    }



        //    return null;
        //}
        ///// <summary>
        ///// Método que realiza o carregamento da quantidade de registros.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <returns>Quantidade de registros encontrados.</returns>
        //protected long HttpGet(string command)
        //{
        //    //T result = default(T);

        //    string cmd = _url + command;

        //    HttpClient client = GetClient();

        //    HttpResponseMessage response = client.GetAsync(cmd).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string res = response.Content.ReadAsStringAsync().Result;

        //        return long.Parse(res);

        //    }


        //    return 0;
        //}
        ///// <summary>
        ///// Método que realiza o carregamento de um item baseado na chave específica.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <param name="key">Chave usada na pesquisa.</param>
        ///// <returns>Objeto encontrado, ou nulo caso não encontre.</returns>
        //protected T HttpGet(string command, L key)
        //{
        //    T result = default(T);

        //    string cmd = _url + command;

        //    HttpClient client = GetClient();

        //    HttpResponseMessage response = client.GetAsync(cmd).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string res = response.Content.ReadAsStringAsync().Result;



        //    }

        //    return default(T);
        //}
        ///// <summary>
        ///// Método que realiza o carregamento de um item baseado em sua entidade.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <param name="entity">Entidade usada como filtro.</param>
        ///// <returns>Entidade encontrada, caso contrário, nulo.</returns>
        //protected T HttpGet(string command, T entity)
        //{
        //    T result = default(T);

        //    return result;
        //}        
        ///// <summary>
        ///// Método que envia os dados da entidade para armazenamento.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <param name="entity">Entidade que possui os dados a serem armazenados.</param>
        ///// <returns>True se conseguiu aplicar os registros especificados.</returns>
        //protected bool HttpPost(string command, T entity)
        //{
        //    #region Comments

        //    //HttpClient client = GetClient();
        //    //HttpResponseMessage response1 = client.PostAsync("http://localhost:1230/api/Jogador/TT/0", entity, new JsonMediaTypeFormatter()).Result;




        //    //string json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        //    //HttpContent content1 = new StringContent(json);
        //    //content1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    //HttpClient client1 = new HttpClient();
        //    //client1.BaseAddress = new Uri("http://localhost:1230/api/");
        //    ////HttpResponseMessage response1 = client1.PostAsync("http://localhost:1230/api/Jogador/Teste", content1).Result;

        //    //HttpResponseMessage response1 = client1.PostAsync("http://localhost:1230/api/Jogador/TT/0", entity, new JsonMediaTypeFormatter()).Result;


        //    //if (response1.IsSuccessStatusCode)
        //    //{
        //    //    var result = response1.Content.ReadAsAsync<T>().Result;
        //    //}
        //    //else
        //    //{
        //    //    return 0;
        //    //}









        //    //// HTTP POST
        //    //var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
        //    //response = await client.PostAsJsonAsync("api/products", gizmo);
        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    // Get the URI of the created resource.
        //    //    Uri gizmoUrl = response.Headers.Location;
        //    //}




        //    //var httpClient = new HttpClient();
        //    //var response = httpClient.PostAsJsonAsync(posturi, model).Result;
        //    //bool returnValue = response.Content.ReadAsAsync<bool>().Result;


        //    //string cmd = _url + command;

        //    //HttpClient client = GetClient();

        //    //HttpResponseMessage response = client.(cmd).Result;

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    System.Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
        //    //    System.Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
        //    //}
        //    //else
        //    //{
        //    //    System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    //}




        //    //var client = new HttpClient();
        //    //HttpContent content = new HttpContent();
        //    //client.PostAsync<HttpContent>("http://localhost:44268/api/test", content, new FormUrlEncodedMediaTypeFormatter())
        //    //    .ContinueWith((postTask) => { postTask.Result.EnsureSuccessStatusCode(); });





        //    //string cmd = _url + command;

        //    //HttpClient client = GetClient();

        //    //var data = entity;
        //    ////response = await client.PostAsJsonAsync("api/products", gizmo);
        //    //HttpResponseMessage response = client.PostAsync(cmd, data).Result;

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    System.Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
        //    //    System.Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
        //    //}
        //    //else
        //    //{
        //    //    System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    //}

        //    //string cmd = _url + command;

        //    //HttpClient client = GetClient();




        //    //var content = new ObjectContent<long[]>(arr, new JsonMediaTypeFormatter());

        //    //var response = client.PostAsync(
        //    //    "https://<uri>/api/orderprocessing/UpdateBatchesToReadyToShip",
        //    //    content: content);



        //    //MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
        //    //HttpContent content = new ObjectContent<T>(entity, jsonFormatter);

        //    //cmd = "http://localhost:1230/api/Jogador/Teste";



        //    //Console.WriteLine(content);




        //    ////string postBody = JsonSerializer(p); 

        //    //var response = client.PostAsync(cmd, content).Result;

        //    ////var response = client.PostAsync(cmd,
        //    ////    new StringContent(new JavaScriptSerializer().Serialize(entity),
        //    ////        Encoding.UTF8, "application/json")
        //    ////    ).Result;

        //    //if (response.IsSuccessStatusCode)
        //    //{

        //    //}

        //    #endregion


        //    HttpClient client = GetClient();
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        //    HttpContent content = new StringContent(json);
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    HttpResponseMessage response = client.PostAsync(_url +"/" + command, entity,
        //        new JsonMediaTypeFormatter()).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string res = response.Content.ReadAsStringAsync().Result ;

        //        if (!string.IsNullOrEmpty (res))
        //        {
        //            bool result = bool.Parse(res);

        //            return result;
        //        }                
        //    }

        //    return false;
        //}        
        ///// <summary>
        ///// Método que envia os dados de entidades para armazenamento.
        ///// </summary>
        ///// <param name="command">Comando a ser executado.</param>
        ///// <param name="entity1">Entidade 1.</param>
        ///// <param name="entity2">Entidade 2.</param>
        ///// <returns>True se conseguiu atualizar o registro.</returns>
        //protected bool HttpPost(string command, T entity1, T entity2)
        //{
        //    return HttpPost(command, entity2);
        //}

        #endregion

        #endregion
    }
}
