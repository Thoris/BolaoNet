using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class AdminBolaoClassificacaoViewModel
    {
        #region Properties

        public IList<AdminClassificacaoViewModel> Classificacao { get; set; }
        public IList<AdminPremioViewModel> Premios { get; set; }
        public IList<AdminJogoViewModel> Jogos { get; set; }
        public IList<AdminUserMailViewModel> Mails { get; set; }

        #endregion
    }
}
