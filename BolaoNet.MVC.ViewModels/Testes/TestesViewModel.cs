using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Testes
{
    public class TestesViewModel
    {
        #region Properties

        public bool ? ResultTestConnection { get; set; }
        public DateTime? ResultCurrentDateTime { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ResultDescription { get; set; }
        
        #endregion
    }
}
