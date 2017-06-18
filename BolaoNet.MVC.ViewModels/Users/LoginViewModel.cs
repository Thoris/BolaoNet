using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class LoginViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        
        #endregion
    }
}
