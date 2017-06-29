using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Resultados
{
    public class ApostaExtraViewModel
    {
        #region Variables

        private string _nomeTime;

        #endregion

        #region Properties

        public string NomeBolao { get; set; }
        public int Posicao { get; set; }
        public string Titulo { get; set; }
        public int? TotalPontos { get; set; }
        public bool? IsValido { get; set; }
        public DateTime? DataValidacao { get; set; }
        public string ValidadoBy { get; set; }
        
        public string NomeTimeValidado
        {
            get { return _nomeTime; }
            set
            {
                _nomeTime = value;
                this.SalvarNomeTime = value;
            }
        }
        
        public string SalvarNomeTime { get; set; }
        public bool IsChanged
        {
            get
            {
                if (_nomeTime != SalvarNomeTime)
                    return true;

                return false;
            }
        }

        #endregion
    }
}
