using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class BolaoIniciarPararViewModel : Domain.Entities.Boloes.Bolao
    {
        #region Properties

        public new bool? IsIniciado
        {
            get { return base.IsIniciado; }
            set { base.IsIniciado = value; }
        }
        public IList<BolaoIniciarStatusMembroViewModel> StatusMembros { get; set; }

        #endregion
    }
}
