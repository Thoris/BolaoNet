using BolaoNet.Domain.Entities.ValueObjects.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail.Templates
{
    public class ClassificacaoTemplateMail : BaseTemplateMail, ITemplateMail
    {
        #region Constants

        private const string TemplateHtmlFile = "Classificacao.htm";
        private const string Title = "Classificacao";

        #endregion

        #region Variables

        #endregion

        #region Constructors/Destructors

        public ClassificacaoTemplateMail(string currentUserName, string folder, IList<ClassificacaoObject> classificacao, IList<PremioObject> premios, IList<JogoObject> jogos)
            : base(currentUserName, folder, TemplateHtmlFile, Title)
        {
            string c = @"
                <table>
                    <thead>
                        <tr>
                            <td>Pos</td>
                            <td></td>
                            <td>Membro</td>
                            <td></td>
                            <td>Nome</td>
                            <td>PT</td>
                            <td>E</td>
                            <td>VDE</td>
                            <td>GT1</td>
                            <td>GT2</td>
                            <td>C</td>
                            <td>EX</td>
                        </tr>
                    </thead>
                    <tbody>";

            for (int i = 0; i < classificacao.Count; i++)
            {
                c += @"
                    <tr>
                        <td>";
                
                if (classificacao[i].BackColorName != null)
                {
                    c += "<i style=\"color:" + classificacao[i].ForeColorName + "\" aria-hidden=\"true\"></i>";
                    c += "<strong style=\"color:" + classificacao[i].BackColorName + "\">" + classificacao[i].Posicao + "</strong>";
                }
                else
                {
                    if (classificacao[i].Posicao == classificacao[classificacao.Count - 1].Posicao)
                    {
                        c += "<i style=\"color:black\" aria-hidden=\"true\"></i>";
                        c += "<strong style=\"color:black\">" + classificacao[i].Posicao + "</strong>";
                    }
                    else
                    {
                        c += "<strong>" + classificacao[i].Posicao + "</strong>";
                    }
                }
                c += @"
                        </td>
                        <td>
                ";


                //                <td>
                //                    @if (Model.Classificacao[c].Posicao == Model.Classificacao[c].LastPosicao)
                //                    {
                //                        @Html.Raw("<span class=\"glyphicon glyphicon-stop black\">&nbsp;&nbsp;</span>");
                //                    }
                //                    else if (Model.Classificacao[c].Posicao < Model.Classificacao[c].LastPosicao)
                //                    {
                //                        @Html.Raw("<span class=\"glyphicon glyphicon-arrow-up blue\">&nbsp;" + (Model.Classificacao[c].LastPosicao - Model.Classificacao[c].Posicao) + "</span>");

                //                    }
                //                    else
                //                    {
                //                        @*<span class="glyphicon glyphicon-arrow-down ">*@
                //                        @Html.Raw("<span style=\"color:red\" class=\"glyphicon glyphicon-arrow-down \">&nbsp;" + (Model.Classificacao[c].Posicao - Model.Classificacao[c].LastPosicao) + "</span>");
                //                    }

                //                </td>
                //                <td>@Model.Classificacao[c].UserName</td>
                //                <td>
                //                    <img class="img-username" src="/Content/img/database/profiles/@(Model.Classificacao[c].UserName).gif?time=@(DateTime.Now)" />
                //                </td>

                c += @"
                        </td>
                        <td>" + classificacao[i].UserName + @"</td>
                        <td></td>
                        <td>" + classificacao[i].FullName + @"</td>
                        <td><strong>" + classificacao[i].TotalPontos + @"</strong></td>
                        <td>" + classificacao[i].TotalEmpate + @"</td>
                        <td>" + classificacao[i].TotalVDE + @"</td>
                        <td>" + classificacao[i].TotalGolsTime1 + @"</td>
                        <td>" + classificacao[i].TotalGolsTime2 + @"</td>
                        <td>" + classificacao[i].TotalPlacarCheio + @"</td>
                        <td>" + classificacao[i].TotalApostaExtra + @"</td>                            
                    </tr>
                ";
            }

            c += @"
                    </tbody>
                </table>
            ";


            base.Tags.Add(new TagValue("CLASSIFICACAO", c));

            c = @"
                <table>
                    <thread>
                        <tr>
                            <th>JogoId</th>
                            <td>Data</td> 
                            <td>Time 1</td>
                            <td></td>
                            <td>Gols 1</td>
                            <td></td>
                            <td>Gols 2</td>
                            <td></td>
                            <td>Time 2</td>
                            <td>Jogo Válido</td>
                        </tr>
                    </thread>
                    <tbody>
             ";

            for (int i = 0; i < jogos.Count; i++)
            {
                c += @"
                    <tr>
                        <th>" + jogos[i].JogoId + @"</th>
                        <td>" + jogos[i].DataJogo.ToString("dd/MM/yy HH:mm") + @"</td>
                        <td>" + jogos[i].NomeTime1 + @"</td>
                        <td>" + "" + @"</td>
                        <td>" + jogos[i].GolsTime1 + @"</td>
                        <td>" + "x" + @"</td>
                        <td>" + jogos[i].GolsTime2 + @"</td>
                        <td>" + "" + @"</td>
                        <td>" + jogos[i].NomeTime2 + @"</td>
                        <td>" + jogos[i].IsValido + @"</td>
                    </tr>
                ";
            }

            c += @"
                    </tbody>
                </table>
            ";

            base.Tags.Add(new TagValue("JOGOS", c));

        }

        #endregion
    }
}
