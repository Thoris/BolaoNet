using BolaoNet.Dao.EF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF
{
    /// <summary>
    /// Classe que trabalha com a fábrica de criação de objetos para acesso à dados.
    /// </summary>
    public class FactoryDaoEF : Dao.IFactoryDao
    {
        #region Variables

        /// <summary>
        /// Variável que gerencia o banco de dados através do padrão de projeto UnitOfWork.
        /// </summary>
        private static IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryDaoEF"/>.
        /// </summary>
        public FactoryDaoEF()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que cria o objeto de conexão unit of work.
        /// </summary>
        /// <returns>Objeto de conexão no padrão unit of work.</returns>
        public IUnitOfWork CreateUnitOfWork()
        {
            //Se ainda não foi criado o objeto de conexão.
            if (FactoryDaoEF._unitOfWork == null)
            {
                FactoryDaoEF._unitOfWork = new UnitOfWork();
            }

            return FactoryDaoEF._unitOfWork;
        }


        #endregion

        #region IFactoryDao members

        ///// <summary>
        ///// Método que cria o objeto de acesso à dados do para gerenciamento do jogador.
        ///// </summary>
        ///// <returns>
        ///// Objeto que possui a instância do jogador.
        ///// </returns>
        //public IJogadorDao CreateJogadorDao()
        //{
        //    return new JogadorRepositoyDao(CreateUnitOfWork());
        //}
        //public IModalidadeDao CreateModalidadeDao()
        //{
        //    return new ModalidadeRepositoryDao(CreateUnitOfWork());
        //}
        




        public Dao.Campeonatos.ICampeonatoDao CreateCampeonatoDao()
        {
            return new Dao.EF.Campeonatos.CampeonatoRepositoryDao(CreateUnitOfWork());
        }

        #endregion
    }
}
