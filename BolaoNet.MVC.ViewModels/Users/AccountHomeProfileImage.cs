using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class AccountHomeProfileImage
    {
        #region Properties

        public string UserName { get; set; }
        public string TempCropFile { get; set; }
        public string TempUploadedFile { get; set; }
        public HttpPostedFileBase AttachedFile { get; set; }
        public string ImageData { get; set; }

        #endregion
    }
}
