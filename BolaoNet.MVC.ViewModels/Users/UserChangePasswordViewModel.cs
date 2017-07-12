using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class UserChangePasswordViewModel
    {
        #region Properties

        [DisplayName("Usuário")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo senha não é um formato válido")]
        [DisplayName("Senha *")] 
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nova senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo nova senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo nova senha não é um formato válido")]
        [DisplayName("Nova Senha *")] 
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo confirmação da senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo confirmação da senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo confirmação da senha não é um formato válido")]
        [DisplayName("Confirmação da Senha *")]  
        public string ConfirmPassword { get; set; }


        #endregion
    }
}
