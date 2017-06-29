using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class CampeonatoClassificacaoApostaUsuarioViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public IList<CampeonatoClassificacaoApostaGrupoViewModel> Grupos { get; set; }

        #endregion
    }
}
