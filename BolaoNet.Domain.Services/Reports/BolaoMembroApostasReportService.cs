using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Reports
{
    public class BolaoMembroApostasReportService : BaseAuditService<Domain.Entities.Boloes.Bolao>,
        Interfaces.Services.Reports.IBolaoMembroApostasReportService
    {
        #region Variables

        private string _userName;
        private Interfaces.Services.Boloes.IBolaoService _bolao;
        private Interfaces.Services.Boloes.IApostaExtraUsuarioService _apostaExtraUsuarios;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuario;
        private Interfaces.Services.Users.IUserService _user;
        private Interfaces.Services.Reports.FormatReport.IBolaoMembroApostasFormatReportService _output;
        private ILogging _logging;
        private Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService _bolaoCampeonatoClassificacaoUsuarioService;

        #endregion

        #region Constructors/Destructors

        public BolaoMembroApostasReportService(string userName, ILogging logging, Interfaces.Services.Boloes.IBolaoService bolao, Interfaces.Services.Boloes.IApostaExtraUsuarioService apostaExtraUsuarios, Interfaces.Services.Boloes.IJogoUsuarioService jogoUsuario, Interfaces.Services.Users.IUserService user,Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService bolaoCampeonatoClassificacaoUsuarioService, Interfaces.Services.Reports.FormatReport.IBolaoMembroApostasFormatReportService output)
        {
            _bolao = bolao;
            _userName = userName;
            _apostaExtraUsuarios = apostaExtraUsuarios;
            _jogoUsuario = jogoUsuario;
            _user = user;
            _bolaoCampeonatoClassificacaoUsuarioService = bolaoCampeonatoClassificacaoUsuarioService;
            _output = output;
            _logging = logging;
        }

        #endregion

        #region IBolaoMembroApostasReportService members

        public Entities.ValueObjects.Reports.BolaoMembroApostasVO GetData(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            Entities.ValueObjects.Reports.BolaoMembroApostasVO res = new Entities.ValueObjects.Reports.BolaoMembroApostasVO();


            Domain.Entities.Users.User userLoaded = _user.Load(user);
            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolao.Load(bolao);

            res.Email = userLoaded.Email;
            res.UserName = userLoaded.UserName;
            res.FullName = userLoaded.FullName;
            res.ApostasExtras = _apostaExtraUsuarios.GetApostasUser(bolaoLoaded, user);
            res.JogosUsuarios = _jogoUsuario.GetJogosUser(bolaoLoaded, user, new Entities.ValueObjects.FilterJogosVO());


            res.ClassificacaoTimes = new List<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>>();
            string[] grupos = { "A", "B", "C", "D", "E", "F", "G", "H" };

            for (int c = 0; c < grupos.Length; c++)
            {
                IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> classificacao =
                    _bolaoCampeonatoClassificacaoUsuarioService.LoadClassificacao(bolao,
                        new Domain.Entities.Campeonatos.CampeonatoFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria, bolaoLoaded.NomeCampeonato),
                        new Domain.Entities.Campeonatos.CampeonatoGrupo(grupos[c], bolaoLoaded.NomeCampeonato),
                        userLoaded);


                //Validando as posições
                for (int i = 0; i < classificacao.Count; i++)
                    classificacao[i].Posicao = i + 1;

                res.ClassificacaoTimes.Add(classificacao);
            }


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento dos dados do bolão [" + bolao.Nome + "]"));
            }


            return res;

        }
        public Stream Generate(string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data)
        {

            if (IsSaveLog)
                CheckStart();

            Stream res = _output.Generate(extension, folderProfiles, folderTimes, data);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Relatório gerado."));
            }

            return res;
        
        }

        #endregion
    
    }
}
