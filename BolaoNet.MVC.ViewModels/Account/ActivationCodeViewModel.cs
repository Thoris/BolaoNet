using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Account
{
    public class ActivationCodeViewModel
    {
        #region Properties

        [Required(AllowEmptyStrings = false, ErrorMessage = "Login do usuário obrigatório.")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "O campo Login deve ter entre 4 à 25 caracteres.")]
        [DisplayName("Login")]        
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Código de ativação do usuário obrigatório.")]
        [DisplayName("Código de Ativação")]
        public string ActivateKey { get; set; }

        #endregion
    }
}
