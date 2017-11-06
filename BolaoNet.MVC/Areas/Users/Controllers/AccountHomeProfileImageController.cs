using BolaoNet.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    public class AccountHomeProfileImageController : BaseUserAreaController
    {
        #region Constants

        //private const string TempUploadedFolder = "/Content/img/database/Temp/Uploaded/";
        //private const string TempCropImageFolder = "/Content/img/database/Temp/Crop/";
        private const string FolderProfileImage = "/Content/img/database/profiles/";

        #endregion

        #region Constructors/Destructors

        public AccountHomeProfileImageController(
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp)
            : base (bolaoApp, bolaoMembroApp)
        {            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion

        #region Actions
       
        [HttpGet]
        public ActionResult Index(ViewModels.Users.AccountHomeProfileImage model)
        {
            model.UserName = base.UserLogged.UserName;
            

            return View(model);
        }
        [HttpPost]
        public ActionResult Salvar(ViewModels.Users.AccountHomeProfileImage model)
        {

            string source = model.ImageData;

            // remove extra chars at the beginning
            source = source.Substring(source.IndexOf(",") + 1);
            byte[] data = Convert.FromBase64String(source);


            string fileTemp = Server.MapPath(FolderProfileImage + "/" + base.UserLogged.UserName + "_.gif");
            if (System.IO.File.Exists(fileTemp))
                System.IO.File.Delete(fileTemp);
            

            //Storing the data into the file
            System.IO.File.WriteAllBytes(fileTemp, data);

            System.Drawing.Image img = System.Drawing.Bitmap.FromFile(fileTemp);

            
            string fileProfile = Server.MapPath(FolderProfileImage + "/" + base.UserLogged.UserName + ".gif");
            if (System.IO.File.Exists(fileProfile))
                System.IO.File.Delete(fileProfile);


            Bitmap resultProfile = ResizeImage(img, 100, 100);
            resultProfile.Save(fileProfile);


            string fileSmall = Server.MapPath(FolderProfileImage + "/" + base.UserLogged.UserName + "_profile.gif");
            if (System.IO.File.Exists(fileSmall))
                System.IO.File.Delete(fileSmall);

            Bitmap resultSmall = ResizeImage(img, 50, 50);
            resultSmall.Save(fileSmall);


            resultSmall.Dispose();
            resultProfile.Dispose();
            img.Dispose();
            

            System.IO.File.Delete(fileTemp);



            base.ShowMessage("Foto do perfil alterado com sucesso.");

            return RedirectToAction("Index", "AccountHome", new { area="Users" });
            
        }
        
        [HttpPost]
        public ActionResult LoadWebCam(ViewModels.Users.AccountHomeProfileImage model)
        {
            return View();
        }
         
        #endregion
    }
}