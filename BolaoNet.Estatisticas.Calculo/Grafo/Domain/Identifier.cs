using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.Grafo.Domain
{
    public class Identifier : IIdentifier
    {
        #region Variables

        private int _id;
        private int _jogoId;
        private int _possibilidadeId;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
        }

        #endregion

        #region Constructors/Destructors

        public Identifier(int id, int jogoId, int possibilidadeId)
        {
            _id = id;
            _jogoId = jogoId;
            _possibilidadeId = possibilidadeId;
        }

        #endregion

        #region Methods

        public bool IsEqual(IIdentifier identifier)
        {
            if (identifier.GetType() != typeof(Identifier))
                return false;

            Identifier entry = identifier as Identifier;

            if (entry._id == _id && entry._jogoId == _jogoId)
                return true;

            return false;
        }

        public static Identifier Create(int id, int jogoId, int possibilidadeId)
        {
            return new Identifier(id, jogoId, possibilidadeId);
        }

        #endregion
    }
}
