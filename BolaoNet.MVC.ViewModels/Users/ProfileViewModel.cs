using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class ProfileViewModel
    {
        #region Properties

        public string Login { get; set; }
        public string NomeCompleto { get; set; }
        public int Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ConfirmacaoEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        #endregion
    }
}
