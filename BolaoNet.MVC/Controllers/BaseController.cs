using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Properties

        protected Helpers.PersistenceProviders.PersistenceProvider Persist { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseController ()
        {

            this.Persist = new Helpers.PersistenceProviders.PersistenceProvider(this);

        }
        #endregion
    }
}