using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class ApostaExtra : Base.AuditModel
    {
        #region Properties

        public int Posicao { get; set; }
        public Bolao Bolao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int TotalPontos { get; set; }
        public bool IsValido { get; set; }
        public DateTime DataValidacao { get; set; }
        public string ValidadoBy { get; set; }
        public string NomeTimeValidado { get; set; }

        #endregion
    }
}
