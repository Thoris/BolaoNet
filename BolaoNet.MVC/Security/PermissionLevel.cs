using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Security
{
    [Flags]
    public enum PermissionLevel
    {
        Administrador,
        Apostador,
        Convidado,
        GerenciadorAvisos,
        GerenciadorBolao,
        GerenciadorCriterios,
        GerenciadorDadosBasicos,
        GerenciadorEnquetes,
        GerenciadorMensagens,
        GerenciadorPagamentos,
        GerenciadorPontuacao,
        GerenciadorPublicidade,
        GerenciadorResultados,
        VisitanteBolao,
        VisitanteCampeonato,
    }
}