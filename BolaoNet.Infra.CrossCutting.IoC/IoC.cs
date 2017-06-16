using BolaoNet.Infra.CrossCutting.IoC.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC
{
    public class IoC
    {
        #region Properties

        public IKernel Kernel { get; private set; }

        #endregion

        #region Constructors/Destructors

        public IoC()
        {
            Kernel = GetNinjectModules();
            //ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        #endregion

        #region Methods

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule(),
                new ApplicationNinjectModule());

        }

        #endregion
    }
}
