using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Helpers
{
    public class ColorPontosHelper
    {
        #region Methods

        public static string GetColorPontos(int ? pontos)
        {
            if (pontos == null)
                return "black";

            switch(pontos)
            {
                case 0:
                    return "red";
                case 1:
                case 2:
                    return "darkcyan";                    
                case 3:
                case 6:
                    return "gray";
                case 4:
                case 8:
                    return "blue";
                case 10:
                case 20:
                    return "green";

                default:
                    return "black";

            }
        }

        #endregion
    }
}