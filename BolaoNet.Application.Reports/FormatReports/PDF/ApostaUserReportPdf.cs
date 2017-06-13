using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.FormatReports.PDF
{
    public class ApostaUserReportPdf : Base.BasePdfCopaMundoReport, IApostasUserReport
    {
        #region Constructors/Destructors

        public ApostaUserReportPdf(string outputFile)
            : base (outputFile)
        {

        }

        #endregion

        #region IApostasUserReport members

        public void Create()
        {
            
        }

        public void Close()
        {
            
        }

        public void CreatePageUserApostas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Users.User user, IList<Domain.Entities.Campeonatos.Jogo> jogos, IList<Domain.Entities.Boloes.JogoUsuario> jogosUsuarios, IList<Domain.Entities.Boloes.ApostaExtra> apostasExtras, IList<Domain.Entities.Boloes.ApostaExtraUsuario> apostasUsuarios)
        {
            
        }

        #endregion
    }
}
