using BolaoNet.MVC.Helpers;
using System;
using System.Collections.Generic;
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

        private const string TempUploadedFolder = "/Content/img/database/Temp/Uploaded/";
        private const string TempCropImageFolder = "/Content/img/database/Temp/Crop/";
        private const string FolderProfileImage = "/Content/img/database/profiles/";

        #endregion

        #region Constructors/Destructors

        public AccountHomeProfileImageController()
        {            
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


            string file = Server.MapPath(FolderProfileImage + "/" + base.UserLogged.UserName + ".gif");
            if (System.IO.File.Exists (file))
                System.IO.File.Delete (file);
            

            //Storing the data into the file
            System.IO.File.WriteAllBytes(file, data);


            return RedirectToAction("Index", "AccountHome", new { area="Users" });
            
        }
        //[HttpPost]
        //public ActionResult Upload(ViewModels.Users.AccountHomeProfileImage model)
        //{
        //    if (model.AttachedFile != null && model.AttachedFile.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(model.AttachedFile.FileName);
                
        //        string fullServerFile = Path.Combine(Server.MapPath(TempUploadedFolder), 
        //            string.Format ("{0}.gif", model.UserName));

        //        var path = fullServerFile;
                
        //        model.AttachedFile.SaveAs(path);

        //        model.TempUploadedFile = (TempUploadedFolder) + "/" + 
        //            string.Format ("{0}.gif", model.UserName);
        //    }

        //    model.UserName = base.UserLogged.UserName;

        //    return View("Index", model);
        //}
        
        //[HttpPost]
        //public virtual ActionResult CropImage(string imagePath, int? cropPointX, int? cropPointY, int? imageCropWidth, int? imageCropHeight)
        //{
        //    if (string.IsNullOrEmpty(imagePath)
        //        || !cropPointX.HasValue
        //        || !cropPointY.HasValue
        //        || !imageCropWidth.HasValue
        //        || !imageCropHeight.HasValue)
        //    {
        //        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        //    }

        //    byte[] imageBytes = System.IO.File.ReadAllBytes(Server.MapPath(imagePath));
        //    byte[] croppedImage = ImageHelper.CropImage(imageBytes, cropPointX.Value, cropPointY.Value, imageCropWidth.Value, imageCropHeight.Value);

        //    //string tempFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.TempFolderName"]);

        //    string tempFolderName = Server.MapPath("~" + TempCropImageFolder);

        //    string fileName = Path.GetFileName(imagePath);

        //    try
        //    {
        //        FileHelper.SaveFile(croppedImage, Path.Combine(tempFolderName, fileName));
        //    }
        //    //catch (Exception ex)
        //    catch
        //    {
        //        //Log an error     
        //        return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
        //    }

        //    //string photoPath = string.Concat("/", ConfigurationManager.AppSettings["Image.TempFolderName"], "/", fileName);
        //    string photoPath = string.Concat(TempCropImageFolder, "/", fileName);
        //    return Json(new { photoPath = photoPath }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult Salvar(ViewModels.Users.AccountHomeProfileImage model)
        //{
        //    string photoPath = Server.MapPath(string.Concat(TempCropImageFolder, "/", base.UserLogged.UserName + ".gif"));
        //    string targetPath = Server.MapPath (string.Concat(FolderProfileImage, "/", base.UserLogged.UserName + ".gif"));
        //    string tempUploadPath = Server.MapPath(string.Concat(TempUploadedFolder, "/", base.UserLogged.UserName + ".gif"));

        //    if (System.IO.File.Exists(targetPath))
        //        System.IO.File.Delete(targetPath);


        //    System.IO.File.Copy(photoPath, targetPath);

        //    if (System.IO.File.Exists(photoPath))
        //        System.IO.File.Delete(photoPath);

        //    if (System.IO.File.Exists(tempUploadPath))
        //        System.IO.File.Delete(tempUploadPath);

        //    return RedirectToAction("Index", "AccountHome", new { area = "Users" });
        //}
        #endregion
    }
}