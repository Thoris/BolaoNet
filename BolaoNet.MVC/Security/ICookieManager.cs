using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Security
{
    public interface ICookieManager
    {
        void SaveAuthentication(HttpResponseBase response, UserModelState model, bool rememberMe, int expiration = 10);
        void SetContextAuthentication(HttpRequest request);
        void ClearContext();

    }
}