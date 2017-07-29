using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Base
{
    /// <summary>
    /// Classe base que contém o gerenciamento de dados de auditoria para identificar performance e logs das execuções.
    /// </summary>
    /// <typeparam name="T">Tipo de entidade a ser gerenciada.</typeparam>
    public class BaseAuditService<T>
    {
        #region Properties

        /// <summary>
        /// Propriedade que configura/retorna a data de execução da ação realizada pelo método.
        /// </summary>
        protected DateTime ExecutionTime { get; set; }
        /// <summary>
        /// Propriedadq que configura/retorna um flag indicando se deve armazenar em log o registro de saída.
        /// </summary>
        protected bool IsSaveLog { get; set; }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BaseAuditService{T, L}"/>.
        /// </summary>
        public BaseAuditService()
        {
            IsSaveLog = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que inicia a contagem de tempo de execução.
        /// </summary>
        protected void CheckStart()
        {
            this.ExecutionTime = DateTime.Now;
        }
        /// <summary>
        /// Método que retorna o tempo de execução coletado depois da execução do método CheckStart
        /// </summary>
        /// <returns>Tempo de execução</returns>
        protected TimeSpan GetCheckTime()
        {
            return DateTime.Now.Subtract(this.ExecutionTime);
        }
        /// <summary>
        /// Método que retorna o nome do tipo da entidade.
        /// </summary>
        /// <param name="entity">Entidade analisada</param>
        /// <returns>Nome da entidade analisada</returns>
        protected string GetTypeName(T entity)
        {
            return entity.GetType().Name;
        }
        /// <summary>
        /// Método que retorna string que contém o tempo total de execução.
        /// </summary>
        /// <returns>String com o tempo total de execução.</returns>
        protected string GetStringTotalTime()
        {
            return "[" + GetCheckTime() + "]";
        }
        /// <summary>
        /// Método que retorna o identificador da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser analisada</param>
        /// <returns>Identificador da entidade, ou 0 caso não seja do tipo BaseModel</returns>
        protected string GetId(T entity)
        {
            //T id = default(T);

            //if (typeof(T).IsSubclassOf(typeof(Entities.Base.IBaseModel)))
            //    id = (entity as Model.BaseModel).ID;


            if (typeof(T).IsSubclassOf(typeof(Entities.Base.BaseEntity)))
            {
                Entities.Base.BaseEntity entityData = entity as Entities.Base.BaseEntity;

                IDictionary<string, object> listKeys = entityData.GetPrimaryKey();

                string res = "";
                
                foreach (KeyValuePair<string, object> entry in listKeys)
                {
                    res += " [" + entry.Key + " = " + entry.Value + "]";
                }

                return res;
            }

            return "";
        }
        /// <summary>
        /// Método que retorna string que possui o identificador da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser analisado.</param>
        /// <returns>String com o identificador.</returns>
        protected string GetStringId(T entity)
        {
            return "(ID=" + GetId(entity) + ")";
        }
        /// <summary>
        /// Método que retorna a string com o nome do tipo com o identificador.
        /// </summary>
        /// <param name="entity">Entidade a ser analisada.</param>
        /// <returns>String com o conteúdo a ser impresso com o nome do tipo e o identificador.</returns>
        protected string GetStringTypeNameID(T entity)
        {
            return GetTypeName(entity) + ": " + GetStringId(entity) + " ";

        }
        /// <summary>
        /// Método que retorna a mensagem com o tempo total gasto na execução.
        /// </summary>
        /// <param name="message">Mensagem a ser impressa.</param>
        /// <returns>String composta de mensagem e o tempo total.</returns>
        protected string GetMessageTotalTime(string message)
        {
            return message + " " + GetStringTotalTime();
        }
        #endregion
    }
}
