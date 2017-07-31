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


            new HappyWay().TestGeneratePdfMembro();



           

            //new HappyWay().TestFullCycle();
        }

        #endregion
    }
}
