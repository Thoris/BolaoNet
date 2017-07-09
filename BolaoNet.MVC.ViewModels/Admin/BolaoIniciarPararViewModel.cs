using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Admin
{
    public class BolaoIniciarPararViewModel : Domain.Entities.Boloes.Bolao
    {
        #region Properties

        [DisplayName("Bolão Iniciado")]
        public new bool? IsIniciado { get; set; }
        
        [DisplayName("Iniciado Por")]
        public new string IniciadoBy { get; set; }


        [DisplayName("Data de início")]
        public new DateTime? DataIniciado { get; set; }


        //public new bool? IsIniciado
        //{
        //    get { return base.IsIniciado; }
        //    set { base.IsIniciado = value; }
        //}
        public IList<BolaoIniciarStatusMembroViewModel> StatusMembros { get; set; }

        #endregion
    }
}
