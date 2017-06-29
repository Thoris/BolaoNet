using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Campeonatos
{
    public class CampeonatoClassificacaoGrupoViewModel
    {
        #region Properties

        public string NomeGrupo { get; set; }
        public IList<CampeonatoClassificacaoEntryViewModel> Posicoes { get; set; }

        #endregion
    }
}
