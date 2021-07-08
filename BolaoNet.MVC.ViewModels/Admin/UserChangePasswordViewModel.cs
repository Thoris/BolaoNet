using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BolaoNet.MVC.ViewModels.Admin
{
    /// <summary>
    /// View Model de alteração de senha do usuário.
    /// </summary>
    public class UserChangePasswordViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DisplayName("Usuário")]
        public string UserName { get; set; }

        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nova senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo nova senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo nova senha não é um formato válido")]
        [DisplayName("Nova Senha *")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo confirmação da senha é obrigatório.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "O campo confirmação da senha deve ter entre 5 à 250 caracteres.")]
        [DataType(DataType.Password, ErrorMessage = "O campo confirmação da senha não é um formato válido")]
        [DisplayName("Confirmação da Senha *")]
        public string ConfirmPassword { get; set; }


        #endregion
    }
}
