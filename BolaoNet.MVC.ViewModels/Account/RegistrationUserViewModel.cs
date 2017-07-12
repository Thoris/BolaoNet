using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BolaoNet.MVC.ViewModels.Account
{
    public class RegistrationUserViewModel
    {
        #region Properties

        [Required(AllowEmptyStrings=false, ErrorMessage = "Login do usuário obrigatório.")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "O campo Login deve ter entre 4 à 25 caracteres.")]
        [DisplayName("Login *")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome Completo é obrigatório.")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "O campo Nome completo deve ter entre 10 à 250 caracteres.")]
        [DisplayName("Nome Completo *")]
        public string FullName { get; set; }

        [DisplayName("Sexo")]        
        public bool ? Male { get; set; }

        [DataType(DataType.Date, ErrorMessage="O campo precisa ser uma data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Nascimento")]
        public Nullable<DateTime> BirthDate { get; set; }
        
        [DataType(DataType.PhoneNumber, ErrorMessage="Formato de telefone inválido")]
        [Phone(ErrorMessage="O telefone de entrada não é válido.")]
        [DisplayName("Telefone")]     
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email de entrada não é válido")]
        [DisplayName("Email *")]        
        public string Email { get; set; }

        [Required(ErrorMessage = "A confirmação do Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "A confirmação do Email não é válida")]
        [DisplayName("Confirmação de Email *")]        
        public string ConfirmacaoEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage="O campo senha não é um formato válido")]
        [DisplayName("Senha *")]        
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo confirmação da senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo confirmação da senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo confirmação da senha não é um formato válido")]
        [DisplayName("Confirmação da Senha *")]        
        public string ConfirmPassword { get; set; }

        //[RegularExpression("True", ErrorMessage = "É necessário concordar com os termos para prosseguir.")]
        [DisplayName("Concordo com os termos")]
        public bool ConcordoTermos { get; set; }
        
        [DisplayName("Quero receber emails")]
        public bool ReceiveEmails { get; set; }

        #endregion

    }
}
