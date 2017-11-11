using BolaoNet.Tests.Exploratory.Watin.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.Constraints;

namespace BolaoNet.Tests.Exploratory.Watin.Pages
{
    public class BasePage : WatiN.Core.Page
    {

        #region Properties

        private string _controllerName;
        protected string SiteBase
        {
            get
            {
                string data = ConfigurationManager.AppSettings["WebTestPortal"];

                if (string.IsNullOrEmpty(data))
                {
                    return Constants.SiteUrl;
                }

                return data;
            }
        }
        public virtual string ControllerSite
        {
            get
            {
                return SiteBase + _controllerName;
            }
        }
        
        #endregion
         
        #region Constructors/Destructors

        public BasePage(string controllerName)
        {
            _controllerName = controllerName;
        }

        #endregion

        #region Methods

        public virtual bool IsValidPage()
        {
            return true;
        }

        //public Element FindElementContaining(IElementsContainer ie, string text)
        //{
        //    Element matchingElement = null;

        //    foreach (Element element in ie.Elements)
        //    {
        //        if (element.Text == null) continue;

        //        if (!element.Text.ToLower().Contains(text.ToLower())) continue;

        //        // If the element found has more inner html than the one we've already matched, it can't be the immediate parent!
        //        if (matchingElement != null && element.InnerHtml.Length > matchingElement.InnerHtml.Length) continue;

        //        matchingElement = element;
        //    }

        //    return matchingElement;
        //}

        #endregion
    }
}
