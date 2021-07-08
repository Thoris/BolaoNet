using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BolaoNet.MVC.ViewModels.Admin
{
    /// <summary>
    /// View Model de Role.
    /// </summary>
    public class RoleViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        [DisplayName("Role Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Role Name é obrigatório.")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DisplayName("Descrição")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public IList<UserProfileViewModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the available users.
        /// </summary>
        /// <value>
        /// The available users.
        /// </value>
        public IList<UserProfileViewModel> AvailableUsers { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected user.
        /// </summary>
        /// <value>
        /// The name of the selected user.
        /// </value>
        public string SelectedUserName { get; set; }

        #endregion
    }
}
