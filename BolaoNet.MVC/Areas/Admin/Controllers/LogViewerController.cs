﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class LogViewerController : Controller
    {
        #region Actions
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}