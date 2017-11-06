using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Users
{
    public class WebCamCapture
    {
        #region Properties

        /// <summary>
        /// Propriedade que configura/retorna a largura da camera.
        /// </summary>
        public int CameraWidth { get; set; }
        /// <summary>
        /// Propriedade que configura/retorna a altura da camera.
        /// </summary>
        public int CameraHeight { get; set; }        
        public string ImageData { get; set; }

        #endregion    
    }
}
