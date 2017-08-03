using BolaoNet.MVC.Tests.IoC;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.Tests
{
    public class Execution
    {
        #region Methods

        public void Execute()
        {
            Domain.Services.Encrypt.EncryptDecrypt t = new Domain.Services.Encrypt.EncryptDecrypt();
            string res = t.EncryptText("usuario0x0", "thoris01");

            string d = t.DecryptText(res, "thoris01");

            new HappyWay().TestGeneratePdfMembro();



           

            //new HappyWay().TestFullCycle();
        }

        #endregion
    }
}
