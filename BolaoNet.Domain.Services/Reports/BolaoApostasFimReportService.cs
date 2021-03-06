﻿using BolaoNet.Domain.Interfaces.Services.Logging;
using BolaoNet.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Reports
{
    public class BolaoApostasFimReportService : BaseAuditService<Domain.Entities.Boloes.Bolao>,
        Interfaces.Services.Reports.IBolaoApostasFimReportService
    {
        #region Variables

        private string _userName;
        private Interfaces.Services.Boloes.IBolaoMembroService _bolaoMembro;
        private Interfaces.Services.Boloes.IBolaoService _bolao;
        private Interfaces.Services.Boloes.IApostaExtraUsuarioService _apostaExtraUsuarios;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuario;
        private Interfaces.Services.Users.IUserService _user;
        private Interfaces.Services.Boloes.IBolaoRegraService _regraService;
        private Interfaces.Services.Reports.FormatReport.IBolaoApostasFimFormatReportService _output;
        private Interfaces.Services.Boloes.IBolaoMembroClassificacaoService _bolaoMembroClassificacaoService;
        private Interfaces.Services.Boloes.IBolaoPremioService _bolaoPremioApp;
        private Interfaces.Services.Campeonatos.IJogoService _jogoService;
        private Interfaces.Services.Campeonatos.ICampeonatoService _campeonato;
        private Interfaces.Services.Campeonatos.ICampeonatoGrupoService _campeonatoGrupo;
        private Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService _bolaoCampeonatoClassificacaoUsuarioService;
        private ILogging _logging;

        #endregion

        #region Constructors/Destructors
        public BolaoApostasFimReportService(string userName, ILogging logging, Interfaces.Services.Boloes.IBolaoMembroService bolaoMembro, Interfaces.Services.Boloes.IBolaoService bolao, Interfaces.Services.Boloes.IApostaExtraUsuarioService apostaExtraUsuarios, Interfaces.Services.Boloes.IJogoUsuarioService jogoUsuario, Interfaces.Services.Users.IUserService user, Interfaces.Services.Boloes.IBolaoRegraService regraService, Interfaces.Services.Boloes.IBolaoMembroClassificacaoService bolaoMembroClassificacaoService, Interfaces.Services.Boloes.IBolaoPremioService bolaoPremioApp, Interfaces.Services.Campeonatos.IJogoService jogoService, Interfaces.Services.Campeonatos.ICampeonatoService campeonato, Interfaces.Services.Campeonatos.ICampeonatoGrupoService campeonatoGrupo, Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService bolaoCampeonatoClassificacaoUsuarioService, Interfaces.Services.Reports.FormatReport.IBolaoApostasFimFormatReportService output)
        {
            _bolaoMembro = bolaoMembro;
            _bolao = bolao;
            _userName = userName;
            _apostaExtraUsuarios = apostaExtraUsuarios;
            _jogoUsuario = jogoUsuario;
            _user = user;
            _output = output;
            _regraService = regraService;
            _bolaoMembroClassificacaoService = bolaoMembroClassificacaoService;
            _bolaoPremioApp = bolaoPremioApp;
            _logging = logging;
            _jogoService = jogoService;
            _campeonato = campeonato;
            _bolaoCampeonatoClassificacaoUsuarioService = bolaoCampeonatoClassificacaoUsuarioService;
            _campeonatoGrupo = campeonatoGrupo;
        }

        #endregion

        #region IBolaoApostasFimReportService members

        public Entities.ValueObjects.Reports.BolaoFinalVO GetData(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (string.IsNullOrEmpty (bolao.NomeCampeonato))
                throw new ArgumentException("bolao.NomeCampeonato");

            if (IsSaveLog)
                CheckStart();

            Entities.ValueObjects.Reports.BolaoFinalVO res = new Entities.ValueObjects.Reports.BolaoFinalVO();

            IList<Domain.Entities.Boloes.BolaoMembro> membros = _bolaoMembro.GetListUsersInBolao(bolao);
            Domain.Entities.Campeonatos.Campeonato campeonato = _campeonato.Load(new Entities.Campeonatos.Campeonato(bolao.NomeCampeonato));
            res.TipoCampeonato = (Entities.Campeonatos.Campeonato.Tipos)(campeonato.TipoCampeonato == null ? 0 : campeonato.TipoCampeonato);


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

            res.Classificacao =
                _bolaoMembroClassificacaoService.LoadClassificacao(bolao, null);
            
            res.Premios = _bolaoPremioApp.GetPremiosBolao(bolao);

            res.Jogos = _jogoService.GetJogosByCampeonato(new Entities.Campeonatos.Campeonato(bolao.NomeCampeonato));
            
            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento dos dados do relatório fim do bolão [" + bolao.Nome + "]"));
            }

            return res;
        }

        public System.IO.Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Entities.ValueObjects.Reports.BolaoFinalVO data)
        {
            
            if (IsSaveLog)
                CheckStart();

            System.IO.Stream res =_output.Generate(fileName, compressedFileName, extension, folderProfiles, folderTimes, data);    
  
            
            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Relatório gerado."));
            }

            return res;
        }

        #endregion
    }
}
