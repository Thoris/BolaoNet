using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Account
{
    public class RegistrationUserViewModel
    {
        #region Properties

        [DisplayName("Login *")]
        public string UserName { get; set; }

        [DisplayName("Nome Completo *")]
        public string FullName { get; set; }

        [DisplayName("Sexo")]        
        public int Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Nascimento")]
        public Nullable<DateTime> BirthDate { get; set; }

        [DisplayName("Telefone")]        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email *")]        
        public string Email { get; set; }

        [DisplayName("Confirmação de Email *")]        
        public string ConfirmacaoEmail { get; set; }

        [DisplayName("Senha *")]        
        public string Password { get; set; }

        [DisplayName("Confirmação da Senha *")]        
        public string ConfirmPassword { get; set; }
        
        public bool ConcordoTermos { get; set; }
        
        public bool ReceiveEmails { get; set; }

        #endregion
    }
}
