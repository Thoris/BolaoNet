using BolaoNet.Application.Interfaces.Campeonatos;
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
            //Domain.Services.Encrypt.EncryptDecrypt t = new Domain.Services.Encrypt.EncryptDecrypt();
            //string res = t.EncryptText("usuario0x0", "thoris01");

            //string d = t.DecryptText(res, "thoris01");

            //new HappyWay().TestGeneratePdfMembro();

            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();
            ICampeonatoApp campeonatoApp = kernel.Get<ICampeonatoApp>();

            campeonatoApp.GetRecords(new Domain.Entities.Campeonatos.Campeonato("Copa do Mundo 2014"), Domain.Interfaces.Services.Campeonatos.RecordTipoPesquisa.RecordQtdJogosSemGanhar);

           

            //new HappyWay().TestFullCycle();
        }

        #endregion
    }
}
