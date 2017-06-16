using BolaoNet.Application.Interfaces.Boloes;
using BolaoNet.Application.Interfaces.Campeonatos;
using BolaoNet.Application.Interfaces.Facade;
using BolaoNet.Application.Interfaces.Facade.Campeonatos;
using BolaoNet.Application.Interfaces.Users;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests
{
    public class AllTests
    {
        #region Methods

        public void Execute()
        {
            Ninject.StandardKernel kernel = (StandardKernel)NinjectCommon.CreateKernel();
            

            CopaDoMundoTests.CopaDoMundo2014Tests.BolaoCopaMundo2014UserApostasAppTests test;


            IUserApp userApp = kernel.Get<IUserApp>();


            test = new CopaDoMundoTests.CopaDoMundo2014Tests.BolaoCopaMundo2014UserApostasAppTests(
                kernel.Get<IUserApp>(),
                kernel.Get<IJogoUsuarioApp>(),
                kernel.Get<IJogoApp>(),
                kernel.Get<IBolaoApp>(),
                kernel.Get<IBolaoMembroApp>(),
                kernel.Get<ICampeonatoApp>(),
                kernel.Get<IUserFacadeApp>(),
                kernel.Get<IApostaExtraApp>(),
                kernel.Get<ICopaMundo2014FacadeApp>()
                );
            

                
            test.TestCreateBolaoCopaDoMundo2014();
        }

        #endregion
    }
}
