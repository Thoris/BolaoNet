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

        private int _index;
        private int _jogoId;
        private int _possibilidadeId;

        #endregion

        #region Properties

        public int Index
        {
            get { return _index; }
        }

        #endregion

        #region Constructors/Destructors

        public Identifier(int index, int jogoId, int possibilidadeId)
        {
            _index = index;
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

            if (entry._possibilidadeId == _possibilidadeId && entry._jogoId == _jogoId)
                return true;

            return false;
        }

        public static Identifier Create(int id, int jogoId, int possibilidadeId)
        {
            return new Identifier(id, jogoId, possibilidadeId);
        } 

        public override string ToString()
        {
            return _index + " : JogoId [" + _jogoId + "] Possibilidade [" + _possibilidadeId + "]"; 
        }

        #endregion



    }
}
