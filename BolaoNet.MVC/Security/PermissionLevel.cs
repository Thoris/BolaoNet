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
     
    public class PermissionLevelDesc
    {
        public static readonly string[] Levels = new string[]
        {            
            "Administrador",
            "Apostador",
            "Convidado",
            "Gerenciador de Avisos",
            "Gerenciador de Bolão",
            "Gerenciador de Critérios",
            "Gerenciador de Dados Básicos",
            "Gerenciador de Enquetes",
            "Gerenciador de Mensagens",
            "Gerenciador de Pagamentos",
            "Gerenciador de Pontuação",
            "Gerenciador de Publicidade",
            "Gerenciador de Resultados",
            "Visitante de Bolão",
            "Visitante de Campeonato"
        };
     

        public static string GetDescription(PermissionLevel level)
        {
            return Levels[(int)level];
        }
    }
}