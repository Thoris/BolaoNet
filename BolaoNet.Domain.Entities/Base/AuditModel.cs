using System;
using System.ComponentModel.DataAnnotations;

namespace BolaoNet.Domain.Entities.Base
{
    /// <summary>
    /// Classe base da entidade que possui informações básicas do registro.
    /// </summary>
    public abstract class AuditModel : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Propriedade que configura/retorna o login do usuário que criou o registro.
        /// </summary>
        [StringLength(25)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Propriedade que configura/retorna a data de criação do registro.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Propriedade que configura/retorna o login do usuário que modificou o registro.
        /// </summary>
        [StringLength(25)]
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Propriedade que configura/retorna a data de modificação do registro.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Propriedade que configura/retorna o status do registro.
        /// </summary>
        //public Enum.RowType StatusRegistro { get; set; }
        public short? ActiveFlag { get; set; }

        #endregion

        #region Methods

        public void Copy(AuditModel entity)
        {
            if (entity == null)
                return;

            this.ActiveFlag = entity.ActiveFlag;
            this.CreatedBy = entity.CreatedBy;
            this.CreatedDate = entity.CreatedDate;
            this.ModifiedBy = entity.ModifiedBy;
            this.ModifiedDate = entity.ModifiedDate;
        }

        #endregion
    }
}
