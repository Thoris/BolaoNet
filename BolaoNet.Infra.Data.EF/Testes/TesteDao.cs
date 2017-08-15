using BolaoNet.Domain.Interfaces.Repositories.Testes;
using BolaoNet.Infra.Data.EF.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Testes
{
    public class TesteDao : ITesteDao
    {
        #region Variables

        /// <summary>
        /// Objeto de conexão com o banco de dados.
        /// </summary>
        private UnitOfWork _context;

        #endregion

        #region Properties

        /// <summary>
        /// Retorna o objeto que possui as conexões.
        /// </summary>
        /// <value>
        /// Objeto que possui as conexões.
        /// </value>
        protected UnitOfWork DataContext
        {
            get { return _context; }
        }

        #endregion

        #region Constructors/Destructors

        public TesteDao(IUnitOfWork context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context as UnitOfWork;
        }

        #endregion

        #region Methods

        public void ThrowException(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            var fail = new Exception(msg, dbEx);
            throw fail;
        }

        #endregion

        #region ITesteDao members

        public bool TestConnection()
        {
            try
            {
                this.DataContext.Database.Connection.Open();
                this.DataContext.Database.Connection.Close();

                return true;
            }
            catch
            {
                return false;
            } 
        }

        public DateTime GetCurrentDateTime()
        {
            string command = "SELECT GETDATE()";

            DateTime res = this.DataContext.Database.SqlQuery<DateTime>(command).Single();

            return res;
        }

        #endregion
    }

}