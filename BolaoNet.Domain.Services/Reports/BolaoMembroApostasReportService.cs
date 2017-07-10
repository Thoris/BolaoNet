using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Reports
{
    public class BolaoMembroApostasReportService : 
        Interfaces.Services.Reports.IBolaoMembroApostasReportService
    {
        #region Variables

        private string _userName;
        private Interfaces.Services.Boloes.IBolaoService _bolao;
        private Interfaces.Services.Boloes.IApostaExtraUsuarioService _apostaExtraUsuarios;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuario;
        private Interfaces.Services.Users.IUserService _user;
        private Interfaces.Services.Reports.FormatReport.IBolaoMembroApostasFormatReportService _output;

        #endregion

        #region Constructors/Destructors

        public BolaoMembroApostasReportService(string userName, ILogging logging, Interfaces.Services.Boloes.IBolaoService bolao, Interfaces.Services.Boloes.IApostaExtraUsuarioService apostaExtraUsuarios, Interfaces.Services.Boloes.IJogoUsuarioService jogoUsuario, Interfaces.Services.Users.IUserService user, Interfaces.Services.Reports.FormatReport.IBolaoMembroApostasFormatReportService output)
        {
            _bolao = bolao;
            _userName = userName;
            _apostaExtraUsuarios = apostaExtraUsuarios;
            _jogoUsuario = jogoUsuario;
            _user = user;
            _output = output;
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

            Entities.ValueObjects.Reports.BolaoMembroApostasVO res = new Entities.ValueObjects.Reports.BolaoMembroApostasVO();


            Domain.Entities.Users.User userLoaded = _user.Load(user);
            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolao.Load(bolao);

            res.Email = userLoaded.Email;
            res.UserName = userLoaded.UserName;
            res.FullName = userLoaded.FullName;
            res.ApostasExtras = _apostaExtraUsuarios.GetApostasUser(bolaoLoaded, user);
            res.JogosUsuarios = _jogoUsuario.GetJogosUser(bolaoLoaded, user, new Entities.ValueObjects.FilterJogosVO());

            return res;

        }
        public Stream Generate(string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data)
        {
            return _output.Generate(extension, folderProfiles, folderTimes, data);
        }

        #endregion
    
    }
}
