using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class BolaoComparacaoApostaJogoViewModel : ApostaJogoUsuarioEntryViewModel
    {
        public int ? GolsTime1Usuario2 { get; set; }
        public int ? GolsTime2Usuario2 { get; set; }
        public int ? PontosUsuario2 { get; set; }
    }
}
