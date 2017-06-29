using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class CampeonatoClassificacaoApostaGrupoViewModel
    {
        #region Properties

        public string NomeGrupo { get; set; }
        public IList<CampeonatoClassificacaoApostaEntryViewModel> Posicoes { get; set; }

        #endregion
    }
}
