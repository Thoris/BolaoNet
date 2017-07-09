using BolaoNet.MVC.ViewModels.Bolao;
using BolaoNet.MVC.ViewModels.Users.PaginaPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class UserGrupoComparacaoViewModel
    {
        public IList<PaginaPrincipalGrupoComparacaoModelView> GrupoSelecionado { get; set; }
        public IList<ClassificacaoViewModel> Classificacao { get; set; }
    }
}
