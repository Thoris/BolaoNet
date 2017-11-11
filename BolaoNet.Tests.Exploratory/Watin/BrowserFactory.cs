using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace BolaoNet.Tests.Exploratory.Watin
{
    public class BrowserFactory
    {
        #region Methods

        private Browser CreateBrowserIE()
        {
            return new IE();
        } 
        private Browser CreateBrowserFireFox()
        {
            return new FireFox();
        }
        public Browser CreateBrowser()
        {
            return CreateBrowserIE();
        }


        #endregion
    }
}
