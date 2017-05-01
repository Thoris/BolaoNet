using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Base
{
    /// <summary>
    /// Classe que trabalha com funcionalidades genéricas para gerenciamento das entidades de integração.
    /// </summary>
    public class GenericIntegration<T> : Base.JsonManagement, IGenericIntegration<T> where T : class
    {

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="GenericIntegration" />.
        /// </summary>
        /// <param name="moduleName">Nome do módulo a ser enviada a requisição via rest.</param>
        /// <param name="url">Url de chamadas para a integração.</param>
        public GenericIntegration(string url, string moduleName)
            : base(url, moduleName)
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// Método que retorna a lista de parâmetros do objeto analisado.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto analisado.</typeparam>
        /// <param name="data">Dados do objeto.</param>
        /// <returns>Lista de objetos do tipo especificado.</returns>
        private IDictionary<string, string> GetParameters<T>(T data)
        {
            return new Dictionary<string, string>();
        }

        #endregion

        #region IGenericIntegration members

        /// <summary>
        /// Método que carrega um registro a partir de dados básicos da entidade.
        /// </summary>
        /// <param name="entity">Entidade que será utilizada para carregar os dados.</param>
        /// <returns>Item encontrado, ou null caso não encontre.</returns>
        public T Load(T entity)
        {
            //string command = "api/" + _moduleName + "/Load/0";

            //T result = base.HttpGet(command, entity);

            //return result;

            //return base.HttpGetApi<T>(GetParameters<T>(entity), "Load");

            return base.HttpPostApi<T>(new Dictionary<string, string>(), entity, "Load");
        }
        /// <summary>
        /// Método que insere um registro na base de dados.
        /// </summary>
        /// <param name="entity">Entidade com os dados a serem inseridos.</param>
        /// <returns>Identificador do registro, ou quantidade de registro afetados.</returns>
        public long Insert(T entity)
        {
            //string command = "api/" + _moduleName + "/Insert/0";
            //string command = base.UrlCommand;

            //bool result = base.HttpPost(command, entity);

            ////if (result == 1)
            ////    return true;
            ////else
            ////    return false;

            //return result;

            long id = base.HttpPostApi<long>(new Dictionary<string, string>(), entity, "Insert");

            //if (!typeof(L).IsClass)
            //{
            //    PropertyInfo property = entity.GetType().GetProperty("ID");

            //    if (property != null)
            //    {
            //        property.SetValue(entity, id, null);
            //    }
            //}


            Entities.Base.BaseEntity baseEntity = entity as Entities.Base.BaseEntity;
            string identityName = baseEntity.GetIdentityName();

            if (string.IsNullOrEmpty(identityName))
                return id;

            PropertyInfo pinfo = entity.GetType().GetProperty(identityName);

            //object value = baseEntity.GetIdentityValue();

            object value = Convert.ChangeType(id, pinfo.PropertyType);
            pinfo.SetValue(entity, value, null);



            return id;

        }
        /// <summary>
        /// Método que exclui um registro da base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser pesquisada para ser excluída.</param>
        /// <returns>True se conseguiu excluir o registro.</returns>
        public bool Delete(T id)
        {
            //string command = "api/" + _moduleName + "/Delete/0";

            //bool result = base.HttpPost(command, entity);

            ////if (result >= 1)
            ////    return true;
            ////else
            ////    return false;

            //return result;

            return base.HttpPostApi<bool>(new Dictionary<string, string>(), id, "Delete");
        }
        /// <summary>
        /// Método que atualiza um registro na base de dados.
        /// </summary>
        /// <param name="oldEntity">Registro atual que deve ser pesquisado na base de dados.</param>
        /// <param name="entity">Dados do registro a ser atualizado na base de dados.</param>
        /// <returns>True se conseguiu atualizar o registro.</returns>
        public bool Update(T entity)
        {
            //string command = "api/" + _moduleName + "/Update/0";

            //bool result = base.HttpPost(command, oldEntity, entity);

            ////if (result >= 1)
            ////    return true;
            ////else
            ////    return false;

            //return result;

            return HttpPostApi<bool>(new Dictionary<string, string>(), entity, "Update");
        }
        /// <summary>
        /// Método que retorna a lista de registros de entidades a partir de uma condição.
        /// </summary>
        /// <param name="where">Condição a ser usada na pesquisa.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        public ICollection<T> GetList(Expression<Func<T, bool>> where)
        {
            //string command = "api/" + _moduleName+  "/GetList/";

            //ICollection<T> list = base.HttpGet(command, )


            //return null;

            return HttpGetApi<ICollection<T>>(new Dictionary<string, string>(), "GetList");

        }
        /// <summary>
        /// Método que retorna lista de registros de uma entidade em específico.
        /// </summary>
        /// <returns>Lista de registros encontrados.</returns>
        public ICollection<T> GetAll()
        {
            //string command = "api/" + _moduleName + "/GetAll/0";

            //ICollection<T> list = base.HttpGet(command, 0);

            //return list;

            return HttpGetApi<ICollection<T>>(new Dictionary<string, string>(), "GetAll");
        }
        /// <summary>
        /// Método que retorna a quantidade de registros da entidade.
        /// </summary>
        /// <returns>Quantidade de registros encontrados.</returns>
        public long Count()
        {
            //string command = "api/" + _moduleName + "/Count/0";

            //long result = base.HttpGet(command);

            //return result;


            return HttpGetApi<long>(new Dictionary<string, string>(), "Count");
        }
        public long Count(Expression<Func<T, bool>> where)
        {
            return HttpGetApi<long>(new Dictionary<string, string>(), "Count");
        }

        #endregion



    }
}
