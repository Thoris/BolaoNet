using BolaoNet.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Controllers
{
    /// <summary>
    /// Class que possui controle de autorização às funcionalidades de gerenciamento das entidades.
    /// </summary>
    [Authentication]
    public class AuthorizationController : AuthenticationController
    {
    }
}