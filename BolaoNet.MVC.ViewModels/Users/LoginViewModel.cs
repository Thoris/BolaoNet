﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class LoginViewModel
    {
        #region Properties

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        
        #endregion
    }
}
