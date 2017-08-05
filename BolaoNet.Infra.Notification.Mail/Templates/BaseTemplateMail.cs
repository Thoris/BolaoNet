using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public abstract class BaseTemplateMail
    {
        #region Properties

        protected string CurrentUserName { get; set; }
        protected string Folder { get; set; }
        protected IList<TagValue> Tags { get; set; }
        protected string TemplateHtmlFile { get; set; }
        protected string Title { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseTemplateMail(string currentUserName, string folder, string templateHtmlFile, string title)
        {
            this.Title = title;
            this.CurrentUserName = currentUserName;
            this.Folder = folder;
            this.TemplateHtmlFile = templateHtmlFile;
            this.Tags = new List<TagValue>();


            string signature = System.Configuration.ConfigurationManager.AppSettings["SIGNATURE"];
            string url = System.Configuration.ConfigurationManager.AppSettings["URL"];


            this.Tags.Add(new TagValue("SIGNATURE", signature));
            this.Tags.Add(new TagValue("URL", url));
            
        }

        #endregion

        #region Methods

        protected string ReadFile(string folder, string templateFile)
        {
            string file = null;

            string physicalPath = "";
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Request == null)
                physicalPath = ".\\";
            else
                physicalPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;

            string fullFile = System.IO.Path.Combine(physicalPath + folder, templateFile);

            System.IO.StreamReader reader = new System.IO.StreamReader(fullFile);

            file = reader.ReadToEnd();

            reader.Close();

            return file;
        }
        protected string SetVariables(string source, IList<TagValue> values)
        {
            string result = source;

            for (int c = 0; c < values.Count; c++ )
            {
                result = result.Replace("[%" + values[c].Tag + "%]", values[c].Value);
            }

            return result;
        }
        public virtual string LoadBody()
        {
            string file = ReadFile(Folder, TemplateHtmlFile);

            file = SetVariables(file, Tags);

            return file;
        }
        public string LoadTitle()
        {
            return this.Title;
        }

        #endregion
    }
}
