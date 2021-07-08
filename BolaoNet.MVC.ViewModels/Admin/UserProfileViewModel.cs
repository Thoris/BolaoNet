using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BolaoNet.MVC.ViewModels.Admin
{
    /// <summary>
    /// View Model de profile de usuários.
    /// </summary>
    public class UserProfileViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [DisplayName("Login")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Login é obrigatório.")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome Completo é obrigatório.")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "O campo Nome completo deve ter entre 10 à 250 caracteres.")]
        [DisplayName("Nome Completo")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the male.
        /// </summary>
        /// <value>
        /// The male.
        /// </value>
        [DisplayName("Sexo")]
        public bool? Male { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        [DataType(DataType.Date, ErrorMessage = "O campo precisa ser uma data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Nascimento")]
        public Nullable<DateTime> BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [DataType(DataType.PhoneNumber, ErrorMessage = "Formato de telefone inválido")]
        [Phone(ErrorMessage = "O telefone de entrada não é válido.")]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email de entrada não é válido")]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        [DisplayName("Celular")]
        public string CellPhone { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [DisplayName("Cidade")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [DisplayName("País")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [DisplayName("Estado")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [DisplayName("Rua")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        /// <value>
        /// The street number.
        /// </value>
        [DisplayName("Num.")]
        public int? StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [DisplayName("CEP")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected role.
        /// </summary>
        /// <value>
        /// The name of the selected role.
        /// </value>
        public string SelectedRoleName { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public IList<ViewModels.Admin.RoleViewModel> Roles { get; set; }

        /// <summary>
        /// Gets or sets the available roles.
        /// </summary>
        /// <value>
        /// The available roles.
        /// </value>
        public IList<ViewModels.Admin.RoleViewModel> AvailableRoles { get; set; }


        #endregion
    }
}
