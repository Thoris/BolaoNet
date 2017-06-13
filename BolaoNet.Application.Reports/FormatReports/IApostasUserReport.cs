using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.FormatReports
{
    public interface IApostasUserReport
    {
        void Create();
        void Close();

        void CreatePageUserApostas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Campeonato campeonato,
            Domain.Entities.Users.User user, IList<Domain.Entities.Campeonatos.Jogo> jogos,
            IList<Domain.Entities.Boloes.JogoUsuario> jogosUsuarios, IList<Domain.Entities.Boloes.ApostaExtra> apostasExtras,
            IList<Domain.Entities.Boloes.ApostaExtraUsuario> apostasUsuarios);


    }
}
