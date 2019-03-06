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
    public class BolaoApostasInicioReportService : BaseAuditService<Domain.Entities.Boloes.Bolao>,
        Interfaces.Services.Reports.IBolaoApostasInicioReportService
    {
        #region Variables

        private string _userName;
        private Interfaces.Services.Boloes.IBolaoMembroService _bolaoMembro;
        private Interfaces.Services.Boloes.IBolaoService _bolao;
        private Interfaces.Services.Boloes.IApostaExtraUsuarioService _apostaExtraUsuarios;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuario;
        private Interfaces.Services.Users.IUserService _user;
        private Interfaces.Services.Campeonatos.ICampeonatoService _campeonato;
        private Interfaces.Services.Campeonatos.ICampeonatoGrupoService _campeonatoGrupo;
        private Interfaces.Services.Boloes.IBolaoRegraService _regraService;
        private Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService _bolaoCampeonatoClassificacaoUsuarioService;
        private Interfaces.Services.Reports.FormatReport.IBolaoApostasInicioFormatReportService _output;
        private ILogging _logging;

        #endregion

        #region Constructors/Destructors

        public BolaoApostasInicioReportService(string userName, ILogging logging, Interfaces.Services.Boloes.IBolaoMembroService bolaoMembro, Interfaces.Services.Boloes.IBolaoService bolao, Interfaces.Services.Boloes.IApostaExtraUsuarioService apostaExtraUsuarios, Interfaces.Services.Boloes.IJogoUsuarioService jogoUsuario, Interfaces.Services.Users.IUserService user, Interfaces.Services.Campeonatos.ICampeonatoService campeonato,Interfaces.Services.Campeonatos.ICampeonatoGrupoService campeonatoGrupo, Interfaces.Services.Boloes.IBolaoRegraService regraService, Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService bolaoCampeonatoClassificacaoUsuarioService, Interfaces.Services.Reports.FormatReport.IBolaoApostasInicioFormatReportService output)
        {
            _bolaoMembro = bolaoMembro;
            _bolao = bolao;
            _userName = userName;
            _apostaExtraUsuarios = apostaExtraUsuarios;
            _jogoUsuario = jogoUsuario;
            _user = user;
            _campeonatoGrupo = campeonatoGrupo;
            _regraService = regraService;
            _output = output;
            _logging = logging;
            _campeonato = campeonato;
            _bolaoCampeonatoClassificacaoUsuarioService = bolaoCampeonatoClassificacaoUsuarioService;
        }

        #endregion

        #region IBolaoMembroApostasReportService members

        public  Entities.ValueObjects.Reports.BolaoIniciarVO GetData(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            Entities.ValueObjects.Reports.BolaoIniciarVO res = new Entities.ValueObjects.Reports.BolaoIniciarVO();

            

            IList<Domain.Entities.Boloes.BolaoMembro> membros = _bolaoMembro.GetListUsersInBolao(bolao);

            Domain.Entities.Campeonatos.Campeonato campeonato = _campeonato.Load(new Entities.Campeonatos.Campeonato(bolao.NomeCampeonato));
            res.TipoCampeonato = (Entities.Campeonatos.Campeonato.Tipos) (campeonato.TipoCampeonato == null ? 0 : campeonato.TipoCampeonato);
            

           


            //IList<Entities.ValueObjects.Reports.BolaoMembroApostasVO> res = 
            res.Membros = new List<Entities.ValueObjects.Reports.BolaoMembroApostasVO>();

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolao.Load(bolao);
            res.Bolao = bolaoLoaded;


            IList<Entities.Campeonatos.CampeonatoGrupo> grupos =
                _campeonatoGrupo.GetGruposCampeonato(new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));


            for (int c = 0; c < membros.Count; c++)
            {
                Entities.ValueObjects.Reports.BolaoMembroApostasVO entry = new Entities.ValueObjects.Reports.BolaoMembroApostasVO();

                Domain.Entities.Users.User userLoaded = _user.Load(new Domain.Entities.Users.User(membros[c].UserName));
                
                entry.Email = userLoaded.Email;
                entry.UserName = userLoaded.UserName;
                entry.FullName = userLoaded.FullName;
                entry.ApostasExtras = _apostaExtraUsuarios.GetApostasUser(bolaoLoaded, userLoaded);
                entry.JogosUsuarios = _jogoUsuario.GetJogosUser(bolaoLoaded, userLoaded, new Entities.ValueObjects.FilterJogosVO());
                
                res.Membros.Add(entry);

                entry.ClassificacaoTimes = new List<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>>();
                for (int i = 0; i < grupos.Count; i++)
                {
                    IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> classificacao =
                        _bolaoCampeonatoClassificacaoUsuarioService.LoadClassificacao(bolao,
                            new Domain.Entities.Campeonatos.CampeonatoFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria, bolaoLoaded.NomeCampeonato),
                            new Domain.Entities.Campeonatos.CampeonatoGrupo(grupos[i].Nome, bolaoLoaded.NomeCampeonato),
                            userLoaded);


                    //Validando as posições
                    for (int a = 0; a < classificacao.Count; a++)
                        classificacao[a].Posicao = a + 1;

                    entry.ClassificacaoTimes.Add(classificacao);
                }

            }

            res.Regras = _regraService.GetRegrasBolao(bolao);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento dos dados do relatório inicial do bolão [" + bolao.Nome + "]"));
            }


            return res;
        }

        public Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Entities.ValueObjects.Reports.BolaoIniciarVO data)
        {

            if (IsSaveLog)
                CheckStart();

            Stream res = _output.Generate(fileName, compressedFileName, extension, folderProfiles, folderTimes, data);

            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Relatório gerado."));
            }

            return res;
        
        }

        #endregion
    }
}
