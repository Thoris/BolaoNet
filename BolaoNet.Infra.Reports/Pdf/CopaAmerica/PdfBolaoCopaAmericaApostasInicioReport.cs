﻿using ICSharpCode.SharpZipLib.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Reports.Pdf.CopaAmerica
{
    public class PdfBolaoCopaAmericaApostasInicioReport
    {
        #region Constants

        private const int FlagImageWidth = 40;
        private const int FlagImageHeight = 27;
        private const int UserImageWidth = 160;
        private const int UserImageHeight = 120;

        #endregion

        #region Constructors/Destructors

        public PdfBolaoCopaAmericaApostasInicioReport()
        {

        }

        #endregion

        #region Methods

        private PdfPTable CreateClassificacao(PdfWriter writer, string imageTimesFolder, string imageExtension, IList<IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>> classificacaoTimes)
        {
            PdfPTable table = new PdfPTable(3);

            //float[] relative = { 3f, 1, 3f };

            int width = 270;
            int spaceLeft = 20;
            float distY = 90;

            //int width = 350;
            //int spaceLeft = 50;
            //float distY = 120;


            IList<PdfPTable> grupos = new List<PdfPTable>();
            string[] nomeGrupos = { "A", "B", "C" };


            for (int c = classificacaoTimes.Count - 1; c >= 0; c--)
            {
                if (classificacaoTimes[c].Count == 0)
                    classificacaoTimes.RemoveAt(c);
            }


            for (int c = 0; c < classificacaoTimes.Count; c++)
            {
                if (classificacaoTimes[c].Count > 0)
                    grupos.Add(CreateGrupoClassificacao(nomeGrupos[c], imageTimesFolder, imageExtension, classificacaoTimes[c]));
            }

            int i = 0;
            int posY = 470;

            if (grupos != null && grupos.Count == 3)
            {

                grupos[i].TotalWidth = width;
                grupos[i++].WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), posY - (distY * 0), writer.DirectContent);

                grupos[i].TotalWidth = width;
                grupos[i++].WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), posY - (distY * 0), writer.DirectContent);

                grupos[i].TotalWidth = width;
                grupos[i++].WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), posY - (distY * 1), writer.DirectContent);
            }

            PdfPTable legendas = new PdfPTable(1);

            //pos
            //bandeira
            //time
            //J
            //PT
            //V
            //E
            //D
            //GP
            //GC
            //S
            //%

            width = 550;
            PdfPCell cellTitle = new PdfPCell(new Phrase(
                "Pos = Posição no grupo; J = Jogos realizados; PT = Pontos somados; V = Vitórias; E = Empates; D = Derrotas; GP = Gols Pró; GC = Gols Contra; S = Saldo de Gols; % = Percentual de aproveitamento ",
                new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
            cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellPos.BackgroundColor = Color.YELLOW;
            cellTitle.BorderWidth = 1;
            legendas.AddCell(cellTitle);

            legendas.TotalWidth = width;
            legendas.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), 280, writer.DirectContent);

            return table;
        }
        private PdfPTable CreateGrupoClassificacao(string nomeGrupo, string imageTimesFolder, string imageExtension, IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> classificacaoTimes)
        {
            float[] relative = new float[] { 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 2 };


            //PdfPTable table = new PdfPTable(12);
            PdfPTable table = new PdfPTable(relative);



            PdfPCell cellTitle = new PdfPCell(new Phrase("Grupo: " + nomeGrupo, new Font(Font.HELVETICA, 10f, Font.BOLD, Color.BLACK)));
            cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellPos.BackgroundColor = Color.YELLOW;
            cellTitle.BorderWidth = 1;
            cellTitle.Colspan = 12;
            table.AddCell(cellTitle);



            PdfPCell cellPosHeader = new PdfPCell(new Phrase("Pos", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellPosHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellPosHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellPosHeader.BackgroundColor = Color.YELLOW;
            cellPosHeader.BorderWidth = 0;

            PdfPCell cellBandeiraHeader = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellBandeiraHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellBandeiraHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellBandeiraHeader.BackgroundColor = Color.YELLOW;
            cellBandeiraHeader.BorderWidth = 0;

            PdfPCell cellTimeHeader = new PdfPCell(new Phrase("Time", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellTimeHeader.HorizontalAlignment = Element.ALIGN_LEFT;
            cellTimeHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellTimeHeader.BackgroundColor = Color.YELLOW;
            cellTimeHeader.BorderWidth = 0;

            PdfPCell cellJogosHeader = new PdfPCell(new Phrase("J", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellJogosHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellJogosHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellJogosHeader.BackgroundColor = Color.YELLOW;
            cellJogosHeader.BorderWidth = 0;

            PdfPCell cellPontosHeader = new PdfPCell(new Phrase("P", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellPontosHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellPontosHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellPontosHeader.BackgroundColor = Color.YELLOW;
            cellPontosHeader.BorderWidth = 0;

            PdfPCell cellVitoriasHeader = new PdfPCell(new Phrase("V", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellVitoriasHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellVitoriasHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellVitoriasHeader.BackgroundColor = Color.YELLOW;
            cellVitoriasHeader.BorderWidth = 0;

            PdfPCell cellEmpatesHeader = new PdfPCell(new Phrase("E", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellEmpatesHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellEmpatesHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellEmpatesHeader.BackgroundColor = Color.YELLOW;
            cellEmpatesHeader.BorderWidth = 0;

            PdfPCell cellDerrotasHeader = new PdfPCell(new Phrase("D", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellDerrotasHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellDerrotasHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellDerrotasHeader.BackgroundColor = Color.YELLOW;
            cellDerrotasHeader.BorderWidth = 0;

            PdfPCell cellGPHeader = new PdfPCell(new Phrase("GP", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellGPHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellGPHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellGPHeader.BackgroundColor = Color.YELLOW;
            cellGPHeader.BorderWidth = 0;

            PdfPCell cellGCHeader = new PdfPCell(new Phrase("GC", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellGCHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellGCHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellGCHeader.BackgroundColor = Color.YELLOW;
            cellGCHeader.BorderWidth = 0;

            PdfPCell cellSaldoHeader = new PdfPCell(new Phrase("S", new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellSaldoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellSaldoHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellSaldoHeader.BackgroundColor = Color.YELLOW;
            cellSaldoHeader.BorderWidth = 0;

            PdfPCell cellPercHeader = new PdfPCell(new Phrase("%".ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            cellPercHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            cellPercHeader.VerticalAlignment = Element.ALIGN_MIDDLE;
            //cellPercHeader.BackgroundColor = Color.YELLOW;
            cellPercHeader.BorderWidth = 0;



            table.AddCell(cellPosHeader);
            table.AddCell(cellBandeiraHeader);
            table.AddCell(cellTimeHeader);
            table.AddCell(cellJogosHeader);
            table.AddCell(cellPontosHeader);
            table.AddCell(cellVitoriasHeader);
            table.AddCell(cellEmpatesHeader);
            table.AddCell(cellDerrotasHeader);
            table.AddCell(cellGPHeader);
            table.AddCell(cellGCHeader);
            table.AddCell(cellSaldoHeader);
            table.AddCell(cellPercHeader);




            for (int c = 0; c < classificacaoTimes.Count; c++)
            {
                float size = 8f;
                PdfPCell cellPos = new PdfPCell(new Phrase(classificacaoTimes[c].Posicao.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellPos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPos.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellPos.BackgroundColor = Color.YELLOW;
                cellPos.BorderWidth = 0;

                //PdfPCell cellBandeira = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                //cellBandeira.HorizontalAlignment = Element.ALIGN_CENTER;
                //cellBandeira.VerticalAlignment = Element.ALIGN_MIDDLE;
                ////cellBandeira.BackgroundColor = Color.YELLOW;
                //cellBandeira.BorderWidth = 0;



                PdfPCell cellBandeira = new PdfPCell();
                string timeFileImage = System.IO.Path.Combine(imageTimesFolder, classificacaoTimes[c].NomeTime + "." + imageExtension);
                if (System.IO.File.Exists(timeFileImage))
                {
                    System.Drawing.Image img = System.Drawing.Bitmap.FromFile(timeFileImage);
                    img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                    Image imgTime = Image.GetInstance(img, Color.WHITE);
                    //Image imgTime = Image.GetInstance(timeFileImage);
                    cellBandeira.AddElement(imgTime);
                    cellBandeira.BorderWidth = 0;
                }



                PdfPCell cellTime = new PdfPCell(new Phrase(classificacaoTimes[c].NomeTime.ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
                cellTime.HorizontalAlignment = Element.ALIGN_LEFT;
                cellTime.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellTime.BackgroundColor = Color.YELLOW;
                cellTime.BorderWidth = 0;

                int totalJogos = (classificacaoTimes[c].TotalDerrotas ?? 0) +
                    (classificacaoTimes[c].TotalEmpates ?? 0) + (classificacaoTimes[c].TotalVitorias ?? 0);
                PdfPCell cellJogos = new PdfPCell(new Phrase(
                    (totalJogos).ToString(),
                    new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellJogos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellJogos.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellJogos.BackgroundColor = Color.YELLOW;
                cellJogos.BorderWidth = 0;

                PdfPCell cellPontos = new PdfPCell(new Phrase(classificacaoTimes[c].TotalPontos.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellPontos.BackgroundColor = Color.YELLOW;
                cellPontos.BorderWidth = 0;

                PdfPCell cellVitorias = new PdfPCell(new Phrase(classificacaoTimes[c].TotalVitorias.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellVitorias.HorizontalAlignment = Element.ALIGN_CENTER;
                cellVitorias.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellVitorias.BackgroundColor = Color.YELLOW;
                cellVitorias.BorderWidth = 0;

                PdfPCell cellEmpates = new PdfPCell(new Phrase(classificacaoTimes[c].TotalEmpates.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellEmpates.HorizontalAlignment = Element.ALIGN_CENTER;
                cellEmpates.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellEmpates.BackgroundColor = Color.YELLOW;
                cellEmpates.BorderWidth = 0;

                PdfPCell cellDerrotas = new PdfPCell(new Phrase(classificacaoTimes[c].TotalDerrotas.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellDerrotas.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDerrotas.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellDerrotas.BackgroundColor = Color.YELLOW;
                cellDerrotas.BorderWidth = 0;

                PdfPCell cellGP = new PdfPCell(new Phrase(classificacaoTimes[c].TotalGolsPro.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellGP.HorizontalAlignment = Element.ALIGN_CENTER;
                cellGP.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellGP.BackgroundColor = Color.YELLOW;
                cellGP.BorderWidth = 0;

                PdfPCell cellGC = new PdfPCell(new Phrase(classificacaoTimes[c].TotalGolsContra.ToString(), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellGC.HorizontalAlignment = Element.ALIGN_CENTER;
                cellGC.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellGC.BackgroundColor = Color.YELLOW;
                cellGC.BorderWidth = 0;

                PdfPCell cellSaldo = new PdfPCell(new Phrase((classificacaoTimes[c].TotalGolsPro - classificacaoTimes[c].TotalGolsContra).ToString(),
                    new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellSaldo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellSaldo.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellSaldo.BackgroundColor = Color.YELLOW;
                cellSaldo.BorderWidth = 0;


                int totalPontos = totalJogos * 3;
                double perc = (double)(classificacaoTimes[c].TotalPontos ?? 0) / (double)totalPontos * (double)100;
                PdfPCell cellPerc = new PdfPCell(new Phrase(perc.ToString("0.0"), new Font(Font.HELVETICA, size, Font.BOLD, Color.BLACK)));
                cellPerc.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPerc.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cellPerc.BackgroundColor = Color.YELLOW;
                cellPerc.BorderWidth = 0;


                //pos
                //bandeira
                //time
                //J
                //PT
                //V
                //E
                //D
                //GP
                //GC
                //S
                //%

                table.AddCell(cellPos);
                table.AddCell(cellBandeira);
                table.AddCell(cellTime);
                table.AddCell(cellJogos);
                table.AddCell(cellPontos);
                table.AddCell(cellVitorias);
                table.AddCell(cellEmpates);
                table.AddCell(cellDerrotas);
                table.AddCell(cellGP);
                table.AddCell(cellGC);
                table.AddCell(cellSaldo);
                table.AddCell(cellPerc);


            }

            return table;
        }
        

        private void CreateRegrasPage( PdfWriter writer, Domain.Entities.Boloes.Bolao bolao, IList<Domain.Entities.Boloes.BolaoRegra> regras)
        {

            PdfPTable tableTitle = new PdfPTable(1);

            PdfPCell cellTitleBolao = new PdfPCell(
                new Phrase(bolao.Nome, new Font(Font.HELVETICA, 18f, Font.BOLD, Color.BLACK)));
            cellTitleBolao.BorderWidth = 0;

            tableTitle.AddCell(cellTitleBolao);
            tableTitle.TotalWidth = 300;            
            tableTitle.WriteSelectedRows(0, -1, 30, 800, writer.DirectContent);



            PdfPTable table = new PdfPTable(1);



            int spaceLeft = 40;
            int width = 520;

            for (int c = 0; c < regras.Count; c++)
            {
                PdfPCell cellTitle = new PdfPCell(new Phrase(regras[c].Descricao,
                    new Font(Font.HELVETICA, 9f, Font.BOLD, Color.BLACK)));
                cellTitle.HorizontalAlignment = Element.ALIGN_LEFT;
                cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTitle.BorderWidth = 0;
                table.AddCell(cellTitle);
            }

            table.TotalWidth = width;
            table.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), 700, writer.DirectContent);


        }

        public void CreatePage(bool showOnlyPartidaValida, bool fim, int posicao, int pontos, PdfWriter writer, string imageExtension, string noPictureFile, string imageUserPath, string imageTimesPath, Domain.Entities.Users.User user, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list, IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> listExtra)
        {
            List<Domain.Entities.ValueObjects.JogoUsuarioVO>[] grupo = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>[8];
            grupo[0] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //A
            grupo[1] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //B
            grupo[2] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //C

            List<Domain.Entities.ValueObjects.JogoUsuarioVO> quartas = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
            List<Domain.Entities.ValueObjects.JogoUsuarioVO> semiFinais = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
            List<Domain.Entities.ValueObjects.JogoUsuarioVO> finais = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();

            //Para cada jogo do campeonato
            foreach (Domain.Entities.ValueObjects.JogoUsuarioVO jogo in list)
            {
                switch (jogo.NomeFase)
                {
                    //case "classificatória":
                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria:

                        if (string.Compare(jogo.NomeGrupo, "A", true) == 0)
                            grupo[0].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "B", true) == 0)
                            grupo[1].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "C", true) == 0)
                            grupo[2].Add(jogo);

                        break;
                    
                    //case "quartas de final":
                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseQuartasFinal:
                        quartas.Add(jogo);
                        break;
                    //case "semi finais":
                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseSemiFinal:
                        semiFinais.Add(jogo);
                        break;
                    //case "final":
                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseFinal:
                        finais.Add(jogo);
                        break;
                }//end switch fase


            }//end foreach



            if (user != null)
            {
                PdfPTable table = CreateUserData(imageUserPath, imageExtension, noPictureFile, user);
                table.TotalWidth = 100;
                table.WriteSelectedRows(0, -1, 33, 795, writer.DirectContent);
            }

            PdfPTable tableExtra = CreateApostasExtras(fim, imageTimesPath, imageExtension, listExtra);
            tableExtra.TotalWidth = 200;
            tableExtra.WriteSelectedRows(0, -1, 360, 780, writer.DirectContent);


            if (fim)
            {
                PdfPTable tablePosition = new PdfPTable(1);
                tablePosition.TotalWidth = 100;

                PdfPCell cellTitPosition = new PdfPCell(new Phrase("Posição", new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
                cellTitPosition.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTitPosition.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTitPosition.BackgroundColor = Color.LIGHT_GRAY;

                PdfPCell cellPosition = new PdfPCell(new Phrase(posicao.ToString(), new Font(Font.HELVETICA, 20f, Font.BOLD, Color.BLACK)));
                cellPosition.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPosition.VerticalAlignment = Element.ALIGN_MIDDLE;


                PdfPCell cellTitPontos = new PdfPCell(new Phrase("Pontos", new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
                cellTitPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTitPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTitPontos.BackgroundColor = Color.LIGHT_GRAY;

                PdfPCell cellPontos = new PdfPCell(new Phrase(pontos.ToString(), new Font(Font.HELVETICA, 20f, Font.BOLD, Color.BLACK)));
                cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;

                tablePosition.AddCell(cellTitPosition);
                tablePosition.AddCell(cellPosition);
                tablePosition.AddCell(cellTitPontos);
                tablePosition.AddCell(cellPontos);

                tablePosition.WriteSelectedRows(0, -1, 200, 780, writer.DirectContent);
            }

            CreateGrupos(showOnlyPartidaValida, fim, writer, imageTimesPath, imageExtension, grupo);
            CreateEliminatorias(showOnlyPartidaValida, fim, writer, imageTimesPath, imageExtension, quartas, semiFinais, finais);



        }
        private PdfPTable CreateUserData(string imageFolder, string imageExtension, string noPictureFile, Domain.Entities.Users.User user)
        {
            //float[] relative = new float[] { 30, 70 };

            PdfPTable table = new PdfPTable(1);


            Image imgUser = null;

            //Buscando a imagem do usuário
            string fileImage = System.IO.Path.Combine(imageFolder, user.UserName + "." + imageExtension);

            //Se existir a imagem do usuário
            if (System.IO.File.Exists(fileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(fileImage);
                img = ImageManagement.ResizeImage(img, UserImageWidth, UserImageHeight);
                imgUser = Image.GetInstance(img, Color.WHITE);
                //imgUser = Image.GetInstance(imgUsr);
            }
            else
            {
                string noFileName = System.IO.Path.Combine(imageFolder, noPictureFile + "." + imageExtension);
                if (System.IO.File.Exists(noFileName))
                {
                    System.Drawing.Image img = System.Drawing.Bitmap.FromFile(noFileName);
                    img = ImageManagement.ResizeImage(img, UserImageWidth, UserImageHeight);
                    imgUser = Image.GetInstance(img, Color.WHITE);

                    //imgUser = Image.GetInstance(noFileName);
                }
                else
                {

                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(UserImageWidth, UserImageHeight);
                    imgUser = Image.GetInstance(bmp, Color.BLACK);
                }
            }

            PdfPCell cellUserName = new PdfPCell(new Phrase(user.UserName, new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
            cellUserName.HorizontalAlignment = Element.ALIGN_CENTER;
            cellUserName.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell cellImage = new PdfPCell();
            cellImage.AddElement(imgUser);


            table.AddCell(imgUser);
            table.AddCell(cellUserName);

            PdfPCell cellFullName = new PdfPCell(new Phrase(user.FullName, new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
            table.AddCell(cellFullName);


            return table;
        }
        private PdfPTable CreateApostasExtras(bool fim, string imageTimesFolder, string imageExtension, IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> apostasExtras)
        {
            float[] relative = new float[] { 60, 10, 30 };

            if (fim)
                relative = new float[] { 60, 10, 30, 10 };

            PdfPTable table = new PdfPTable(relative);



            PdfPCell tit1 = new PdfPCell(new Phrase("Posição", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
            tit1.BackgroundColor = Color.LIGHT_GRAY;
            tit1.HorizontalAlignment = Element.ALIGN_LEFT;
            tit1.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit1);

            PdfPCell tit2 = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
            tit2.BackgroundColor = Color.LIGHT_GRAY;
            tit2.HorizontalAlignment = Element.ALIGN_LEFT;
            tit2.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit2);

            PdfPCell tit3 = new PdfPCell(new Phrase("Time", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
            tit3.BackgroundColor = Color.LIGHT_GRAY;
            tit3.HorizontalAlignment = Element.ALIGN_LEFT;
            tit3.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit3);

            if (fim)
            {
                PdfPCell tit4 = new PdfPCell(new Phrase("Pt", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                tit4.BackgroundColor = Color.LIGHT_GRAY;
                tit4.HorizontalAlignment = Element.ALIGN_LEFT;
                tit4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(tit4);
            }


            //Para cada aposta extra
            foreach (Domain.Entities.ValueObjects.ApostaExtraUsuarioVO aposta in apostasExtras)
            {
                PdfPCell cellTitle = new PdfPCell(new Phrase(aposta.Titulo, new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                //cellTitle.Border = 0;
                //cellTitle.BorderWidth = 0;
                cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;


                PdfPCell cellTime = new PdfPCell(new Phrase(aposta.NomeTime, new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                //cellTime.Border = 0;
                //cellTime.BorderWidth = 0;
                cellTime.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTime.VerticalAlignment = Element.ALIGN_MIDDLE;


                PdfPCell cellImageTime = new PdfPCell();
                string timeFileImage = System.IO.Path.Combine(imageTimesFolder, aposta.NomeTime + "." + imageExtension);
                if (System.IO.File.Exists(timeFileImage))
                {
                    System.Drawing.Image img = System.Drawing.Bitmap.FromFile(timeFileImage);
                    img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                    Image imgTime = Image.GetInstance(img, Color.WHITE);
                    //Image imgTime = Image.GetInstance(timeFileImage);
                    cellImageTime.AddElement(imgTime);

                }
                //cellImageTime.Border = 0;
                //cellImageTime.BorderWidth = 0;
                //cellImageTime.HorizontalAlignment = Element.ALIGN_CENTER;
                //cellImageTime.VerticalAlignment = Element.ALIGN_MIDDLE;




                table.AddCell(cellTitle);
                table.AddCell(cellImageTime);
                table.AddCell(cellTime);

                if (fim)
                {

                    PdfPCell cellPontos = new PdfPCell(new Phrase(aposta.TotalPontos.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                    cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cellPontos);
                }



            }//end foreach aposta extra


            return table;
        }

        private void CreateGrupos(bool showOnlyPartidaValida, bool fim, PdfWriter writer, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO>[] list)
        {
            PdfPTable grupoA = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo A", imagePath, list[0]);
            PdfPTable grupoB = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo B", imagePath, list[1]);
            PdfPTable grupoC = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo C", imagePath, list[2]);
            

            //int width = 123;
            //int spaceLeft = 20;
            int width = 140;
            int spaceLeft = 40;

            if (fim)
            {
                width = 140;
                spaceLeft = 6;
            }

            grupoA.TotalWidth = width;
            grupoA.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), 650, writer.DirectContent);

            grupoB.TotalWidth = width;
            grupoB.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), 650, writer.DirectContent);

            grupoC.TotalWidth = width;
            grupoC.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), 650, writer.DirectContent);


        }
        private PdfPTable CreateGrupoJogos(bool showOnlyPartidaValida, bool fim, string imageExtension, string title, string imagePath, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable pjogos = new PdfPTable(1);


            pjogos.AddCell(new Phrase(title, new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
            pjogos.DefaultCell.Border = 0;
            pjogos.DefaultCell.Padding = 0;

            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.LIGHT_GRAY, imagePath, list[0]));
            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.WHITE, imagePath, list[1]));
            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.LIGHT_GRAY, imagePath, list[2]));
            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.WHITE, imagePath, list[3]));
            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.LIGHT_GRAY, imagePath, list[4]));
            pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, imageExtension, Color.WHITE, imagePath, list[5]));


            return pjogos;
        }
        private PdfPTable CreateJogoInGroupFormat(bool showOnlyPartidaValida, bool fim, string imageExtension, Color backColor, string imagePath, Domain.Entities.ValueObjects.JogoUsuarioVO jogo)
        {
            //Criando a table contendo todas as informações do jogo
            PdfPTable pjogoFull = new PdfPTable(1);
            pjogoFull.DefaultCell.Border = 0;
            pjogoFull.DefaultCell.BorderWidth = 0;

            pjogoFull.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pjogoFull.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pjogoFull.DefaultCell.BackgroundColor = backColor;

            pjogoFull.DefaultCell.Padding = 0;

            //Definindo o tamanho para cada campo
            float[] relative = { 3f, 5, 2f, 1f, 2f, 5, 3f };

            if (fim)
            {
                relative = new float[] { 3f, 5, 2f, 1f, 2f, 5, 3f, 2f };
            }

            //Criando a tabela contendo os dados da partida
            PdfPTable pjogo = new PdfPTable(relative);



            //Criando a imagem do time de casa
            PdfPCell cellImageTimeCasa = new PdfPCell();
            //string time1FileImage = System.IO.Path.Combine(imagePath, jogo.Jogo.NomeTime1 + ".gif");
            string time1FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime1 + "." + imageExtension);
            if (System.IO.File.Exists(time1FileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(time1FileImage);
                img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                Image imgTimeCasa = Image.GetInstance(img, Color.WHITE);
                //Image imgTimeCasa = Image.GetInstance(time1FileImage);
                cellImageTimeCasa.AddElement(imgTimeCasa);
            }
            cellImageTimeCasa.HorizontalAlignment = Element.ALIGN_LEFT;
            cellImageTimeCasa.VerticalAlignment = Element.ALIGN_MIDDLE;

            cellImageTimeCasa.BorderWidth = 0;



            //Criando a descrição do time de fora
            PdfPCell cellTimeCasa = new PdfPCell(new Phrase(jogo.NomeTime1, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
            cellTimeCasa.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTimeCasa.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTimeCasa.BorderWidth = 0;


            PdfPCell cellResultCasa = new PdfPCell();
            if (fim)
            {
                PdfPTable table = new PdfPTable(1);
                PdfPCell cellAposta1 = new PdfPCell(new Phrase(jogo.ApostaTime1.ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
                cellAposta1.HorizontalAlignment = Element.ALIGN_CENTER;
                cellAposta1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellAposta1.BackgroundColor = Color.YELLOW;
                cellAposta1.BorderWidth = 0;

                PdfPCell cellResult1 = new PdfPCell(new Phrase(jogo.GolsTime1.ToString(), new Font(Font.HELVETICA, 4f, Font.NORMAL, Color.BLACK)));
                cellResult1.HorizontalAlignment = Element.ALIGN_CENTER;
                cellResult1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellResult1.BorderWidth = 0;


                table.AddCell(cellAposta1);
                table.AddCell(cellResult1);
                cellResultCasa.BorderWidth = 0;
                cellResultCasa.AddElement(table);
            }
            else
            {

                if ((showOnlyPartidaValida && jogo.PartidaValida) || !showOnlyPartidaValida)
                {
                    //Criando o resultado do time de casa
                    cellResultCasa = new PdfPCell(new Phrase(jogo.ApostaTime1.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                }
                else
                {
                    //Criando o resultado do time de casa
                    cellResultCasa = new PdfPCell(new Phrase(" ", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                }
                cellResultCasa.HorizontalAlignment = Element.ALIGN_CENTER;
                cellResultCasa.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellResultCasa.BorderWidth = 0;
                cellResultCasa.BackgroundColor = Color.YELLOW;
            }


            //Criando a divisão entre os times
            PdfPCell cellVersus = new PdfPCell();
            cellVersus.AddElement(new Phrase("x", new Font(Font.HELVETICA, 7f, Font.NORMAL, Color.BLACK)));
            cellVersus.HorizontalAlignment = Element.ALIGN_CENTER;
            cellVersus.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellVersus.BorderWidth = 0;


            PdfPCell cellResultFora = new PdfPCell();
            if (fim)
            {
                PdfPTable table = new PdfPTable(1);
                PdfPCell cellAposta2 = new PdfPCell(new Phrase(jogo.ApostaTime2.ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
                cellAposta2.HorizontalAlignment = Element.ALIGN_CENTER;
                cellAposta2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellAposta2.BackgroundColor = Color.YELLOW;
                cellAposta2.BorderWidth = 0;

                PdfPCell cellResult2 = new PdfPCell(new Phrase(jogo.GolsTime2.ToString(), new Font(Font.HELVETICA, 4f, Font.NORMAL, Color.BLACK)));
                cellResult2.HorizontalAlignment = Element.ALIGN_CENTER;
                cellResult2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellResult2.BorderWidth = 0;


                table.AddCell(cellAposta2);
                table.AddCell(cellResult2);
                cellResultFora.BorderWidth = 0;
                cellResultFora.AddElement(table);
            }
            else
            {
                if ((showOnlyPartidaValida && jogo.PartidaValida) || !showOnlyPartidaValida)
                {
                    //Criando o resultado do time de fora
                    cellResultFora = new PdfPCell(new Phrase(jogo.ApostaTime2.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                }
                else
                {
                    //Criando o resultado do time de fora
                    cellResultFora = new PdfPCell(new Phrase(" ", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));

                }
                cellResultFora.HorizontalAlignment = Element.ALIGN_CENTER;
                cellResultFora.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellResultFora.BorderWidth = 0;
                cellResultFora.BackgroundColor = Color.YELLOW;
            }

            //Criando o nome do time que está fora
            PdfPCell cellTimeFora = new PdfPCell(new Phrase(jogo.NomeTime2, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
            cellTimeFora.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTimeFora.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTimeFora.BorderWidth = 0;


            //Criando a imagem do time de fora
            PdfPCell cellImageTimeFora = new PdfPCell();
            string time2FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime2 + "." + imageExtension);
            if (System.IO.File.Exists(time2FileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(time2FileImage);
                img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                Image imgTimeFora = Image.GetInstance(img, Color.WHITE);
                //Image imgTimeFora = Image.GetInstance(time2FileImage);
                cellImageTimeFora.AddElement(imgTimeFora);
            }
            cellImageTimeFora.BorderWidth = 0;
            cellImageTimeFora.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellImageTimeFora.VerticalAlignment = Element.ALIGN_MIDDLE;


            //Adicioando os campos na tabela
            pjogo.AddCell(cellImageTimeCasa);
            pjogo.AddCell(cellTimeCasa);
            pjogo.AddCell(cellResultCasa);
            pjogo.AddCell(cellVersus);
            pjogo.AddCell(cellResultFora);
            pjogo.AddCell(cellTimeFora);
            pjogo.AddCell(cellImageTimeFora);

            if (fim)
            {
                //Criando o nome do time que está fora
                PdfPCell cellPontos = new PdfPCell(new Phrase(jogo.Pontos.ToString(), new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
                cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPontos.BorderWidth = 0;

                if (jogo.PartidaValida)
                {
                    if (jogo.Pontos == 0)
                        cellPontos.BackgroundColor = Color.RED;

                }
                else
                {
                    cellPontos.BackgroundColor = Color.YELLOW;
                }
                //cellPontos.BackgroundColor = Color.RED;
                pjogo.AddCell(cellPontos);
            }



            //Adicionando no grupo principal os dados do jogo
            pjogoFull.AddCell(pjogo);

            string footer = jogo.DataJogo.ToString("dd/MM - HH:mm") + " - " + jogo.NomeEstadio;

            //Adicionando o local do jogo
            PdfPCell dateJogo = new PdfPCell(new Phrase(footer, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
            dateJogo.Padding = 0;
            dateJogo.BorderWidth = 0;
            dateJogo.HorizontalAlignment = Element.ALIGN_CENTER;
            dateJogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            dateJogo.BackgroundColor = backColor;
            dateJogo.PaddingBottom = 2;

            //Adicionando o local do jogo na tabela principal
            pjogoFull.AddCell(dateJogo);

            return pjogoFull;
        }

        private void CreateEliminatorias(bool showOnlyPartidaValida, bool fim, PdfWriter writer, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> quartas, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> semiFinais, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> finais)
        {
            float[] relative = new float[] { 0.01f, 0.5f, 12, 0.5f, 12, 0.5f, 13, 0.5f, 12, 0.5f, 12, 0.5f, 0.01f };
            PdfPTable table = new PdfPTable(relative);
            table.DefaultCell.BorderWidth = 0;
            table.DefaultCell.Padding = 0;



            table.AddCell("");
            table.AddCell("");
            table.AddCell(CreateQuartasLeft(showOnlyPartidaValida, fim, imagePath, imageExtension, quartas));
            table.AddCell("");
            table.AddCell(CreateSemiFinaisLeft(showOnlyPartidaValida, fim, imagePath, imageExtension, semiFinais));
            table.AddCell("");
            table.AddCell(CreateFinais(showOnlyPartidaValida, fim, imagePath, imageExtension, finais));
            table.AddCell("");
            table.AddCell(CreateSemiFinaisRight(showOnlyPartidaValida, fim, imagePath, imageExtension, semiFinais));
            table.AddCell("");
            table.AddCell(CreateQuartasRight(showOnlyPartidaValida, fim, imagePath, imageExtension, quartas));
            table.AddCell("");
            table.AddCell("");

            //table.TotalWidth = 580;
            table.TotalWidth = 540;
            table.SpacingAfter = 10;

            //table.WriteSelectedRows(0, -1, 5, 280, writer.DirectContent);
            //table.WriteSelectedRows(0, -1, 25, 280, writer.DirectContent);
            table.WriteSelectedRows(0, -1, 25, 280, writer.DirectContent);


            int oitavasLeft = 65;
            int oitavasRight = 531;

            PdfContentByte cb = writer.DirectContent;
            
            


            ////   |
            //cb.MoveTo(145, 208);
            //cb.LineTo(145, 125);
            //cb.Stroke();
            ////   |
            //cb.MoveTo(445, 208);
            //cb.LineTo(445, 125);
            //cb.Stroke();

            //// -
            //cb.MoveTo(145, 167);
            //cb.LineTo(180 + 4, 167);
            //cb.Stroke();
            //// -
            //cb.MoveTo(445, 167);
            //cb.LineTo(407, 167);
            //cb.Stroke();


            //cb.MoveTo(280, 209);
            //cb.LineTo(280, 180);
            //cb.Stroke();


            //cb.MoveTo(310, 209);
            //cb.LineTo(310, 180);
            //cb.Stroke();

            //cb.MoveTo(280, 180);
            //cb.LineTo(247 + 8, 180);
            //cb.Stroke();

            //cb.MoveTo(310, 180);
            //cb.LineTo(343 - 8, 180);
            //cb.Stroke();




            //   |

            //cb.MoveTo(145, 208);
            //cb.LineTo(145, 125);
            cb.MoveTo(80, 208 - 5);
            cb.LineTo(80, 125 + 5);
            cb.Stroke();

            //   |

            //cb.MoveTo(445, 208);
            //cb.LineTo(445, 125);
            cb.MoveTo(520, 208 - 5);
            cb.LineTo(520, 125 + 5);
            cb.Stroke();

            // -

            //cb.MoveTo(145, 167);
            cb.MoveTo(80, 167);
            cb.LineTo(130, 167);
            cb.Stroke();
            // -

            //cb.MoveTo(445, 167);
            cb.MoveTo(520, 167);
            cb.LineTo(460, 167);
            cb.Stroke();

            cb.MoveTo(280, 195);
            cb.LineTo(280, 160);
            cb.Stroke();

            cb.MoveTo(310, 195);
            cb.LineTo(310, 160);
            cb.Stroke();

            cb.MoveTo(280, 160);
            cb.LineTo(237, 160);
            cb.Stroke();

            cb.MoveTo(310, 160);
            cb.LineTo(353, 160);
            cb.Stroke();

        }
        
        private PdfPTable CreateTimeEliminatoriaFormat(bool showOnlyPartidaValida, bool fim, bool showTitle, string imageExtension, string imagePath, bool timeCasa, Domain.Entities.ValueObjects.JogoUsuarioVO jogo)
        {
            float[] relative = null;

            if (showTitle)
            {
                relative = new float[] { 20, 20, 40, 20 };

                if (fim)
                    relative = new float[] { 20, 20, 40, 20, 10, 20 };
            }
            else
            {
                relative = new float[] { 20, 60, 20 };

                if (fim)
                    relative = new float[] { 20, 60, 20, 10, 20 };

            }


            PdfPTable time = new PdfPTable(relative);
            time.DefaultCell.Padding = 0;

            if (showTitle)
            {
                PdfPCell cellDescription = new PdfPCell(new Phrase((timeCasa ? jogo.DescricaoTime1 : jogo.DescricaoTime2),
                    new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
                cellDescription.HorizontalAlignment = Element.ALIGN_CENTER;
                cellDescription.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellDescription.BorderWidth = 0;
                time.AddCell(cellDescription);
            }

            //Criando a imagem do time 
            PdfPCell cellImageTime = new PdfPCell();
            string timeFileImage = System.IO.Path.Combine(imagePath, (timeCasa ? jogo.NomeTimeResult1 : jogo.NomeTimeResult2) + "." + imageExtension);
            if (System.IO.File.Exists(timeFileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(timeFileImage);
                img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                Image imgTime = Image.GetInstance(img, Color.WHITE);
                //Image imgTime = Image.GetInstance(timeFileImage);
                cellImageTime.AddElement(imgTime);
            }
            cellImageTime.BorderWidth = 0;

            //Criando a descrição do time de fora

            string strTimeCasa = timeCasa ? jogo.NomeTimeResult1 : jogo.NomeTimeResult2;
            if (string.IsNullOrEmpty(strTimeCasa))
                strTimeCasa = " ? ";

            //PdfPCell cellTime = new PdfPCell(new Phrase((timeCasa ? jogo.Time1.Nome : jogo.Time2.Nome),
            PdfPCell cellTime = new PdfPCell(new Phrase((strTimeCasa), new Font(Font.HELVETICA, 4.5f, Font.NORMAL, Color.BLACK)));
            cellTime.HorizontalAlignment = Element.ALIGN_CENTER;
            cellTime.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellTime.BorderWidth = 0;

            //Criando o resultado do time 
            PdfPCell cellResult = new PdfPCell();

            if ((showOnlyPartidaValida && jogo.PartidaValida) || !showOnlyPartidaValida)
            {
                cellResult.AddElement(new Phrase((timeCasa ? jogo.ApostaTime1.ToString() : jogo.ApostaTime2.ToString()),
                    //cellResult = new PdfPCell(new Phrase((timeCasa ? jogo.ApostaTime1.ToString() : jogo.ApostaTime2.ToString()),
                    new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
            }
            else
            {
                cellResult.AddElement(new Phrase((""),
                    //cellResult = new PdfPCell(new Phrase((timeCasa ? jogo.ApostaTime1.ToString() : jogo.ApostaTime2.ToString()),
                new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));

            }

            cellResult.HorizontalAlignment = Element.ALIGN_CENTER;
            cellResult.VerticalAlignment = Element.ALIGN_MIDDLE;
            cellResult.BorderWidth = 0;
            cellResult.BackgroundColor = Color.YELLOW;

            time.AddCell(cellImageTime);
            time.AddCell(cellTime);
            time.AddCell(cellResult);

            if (fim)
            {
                PdfPCell cellGols = new PdfPCell(new Phrase((timeCasa ? jogo.GolsTime1.ToString() : jogo.GolsTime2.ToString()),
                    new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
                cellGols.HorizontalAlignment = Element.ALIGN_CENTER;
                cellGols.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellGols.BorderWidth = 0;
                time.AddCell(cellGols);



                PdfPCell cellPontos = new PdfPCell(new Phrase((timeCasa ? jogo.Pontos.ToString() : ""),
                    new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
                cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
                cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellPontos.BorderWidth = 0;

                if (jogo.PartidaValida)
                {
                    if (jogo.Pontos == 0 && timeCasa)
                        cellPontos.BackgroundColor = Color.RED;

                }
                else if (timeCasa)
                {
                    cellPontos.BackgroundColor = Color.YELLOW;
                }

                time.AddCell(cellPontos);
            }

            return time;
        }
        private PdfPTable CreateJogoInEliminatoriaFormat(bool showOnlyPartidaValida, bool fim, Color backColor, bool showTitle, string imagePath, string imageExtension, Domain.Entities.ValueObjects.JogoUsuarioVO jogo)
        {
            PdfPTable jogoTable = new PdfPTable(1);
            jogoTable.DefaultCell.Padding = 0;
            //jogoTable.DefaultCell.BorderWidth = 0;
            jogoTable.DefaultCell.BackgroundColor = backColor;



            jogoTable.AddCell(CreateTimeEliminatoriaFormat(showOnlyPartidaValida, fim, showTitle, imageExtension, imagePath, true, jogo));
            jogoTable.AddCell(CreateTimeEliminatoriaFormat(showOnlyPartidaValida, fim, showTitle, imageExtension, imagePath, false, jogo));


            string dateDescription = jogo.DataJogo.ToString("dd/MM - HH:mm") + " - " + jogo.NomeEstadio;

            //Adicionando o local do jogo
            PdfPCell dateJogo = new PdfPCell(new Phrase(dateDescription, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
            dateJogo.Padding = 0;
            dateJogo.BorderWidth = 0;
            dateJogo.HorizontalAlignment = Element.ALIGN_CENTER;
            dateJogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            dateJogo.BackgroundColor = backColor;
            dateJogo.PaddingBottom = 2;

            //Adicionando o local do jogo na tabela principal
            jogoTable.AddCell(dateJogo);



            return jogoTable;
        }

        private PdfPTable CreateQuartasLeft(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;
            
            fase.AddCell(" ");

            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(19, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true,
                imagePath, imageExtension, GetJogoByLabel(20, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");


            return fase;
        }
        private PdfPTable CreateSemiFinaisLeft(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;
            
            fase.AddCell(" ");

            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(23, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");


            return fase;
        }
        private PdfPTable CreateQuartasRight(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(" ");


            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(21, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true,
                imagePath, imageExtension, GetJogoByLabel(22, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");


            return fase;
        }
        private PdfPTable CreateSemiFinaisRight(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(" ");

            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(24, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");


            return fase;
        }
        private PdfPTable CreateFinais(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");


            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(26, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, false,
                imagePath, imageExtension, GetJogoByLabel(25, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");

            return fase;
        }
        private Domain.Entities.ValueObjects.JogoUsuarioVO GetJogoByLabel(int jogoId, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            for (int c = 0; c < list.Count; c++)
            {
                //Se encontrou o titulo do jogo
                if (list[c].JogoId == jogoId)
                {
                    Domain.Entities.ValueObjects.JogoUsuarioVO jogoResult = list[c];
                    list.RemoveAt(c);
                    return jogoResult;

                }//ednif titulo

            }//end for jogo

            return new Domain.Entities.ValueObjects.JogoUsuarioVO();
        }

        private void CompressFile(string sourceFile, string targetFile)
        {
            // Zip up the files - From SharpZipLib Demo Code
            using (ZipOutputStream s = new ZipOutputStream(File.Create(targetFile)))
            {
                s.SetLevel(9); // 0-9, 9 being the highest compression

                byte[] buffer = new byte[4096];


                ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));

                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(sourceFile))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);

                        s.Write(buffer, 0, sourceBytes);

                    } while (sourceBytes > 0);
                }

                s.Finish();
                s.Close();
            }
        }

        #endregion

        #region IBolaoApostasInicioFormatReportService members

        public Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoIniciarVO data)
        {
            Document document = new Document(PageSize.A4);

            MemoryStream fs = new MemoryStream();


            PdfWriter writer = PdfWriter.GetInstance(document, fs);


            document.Open();
            document.NewPage();


            CreateRegrasPage(writer, data.Bolao, data.Regras);


            for (int c = 0; c < data.Membros.Count; c++)
            {

                document.NewPage();

                Domain.Entities.Users.User user = new Domain.Entities.Users.User(data.Membros[c].UserName);
                user.FullName = data.Membros[c].FullName;
                user.Email = data.Membros[c].Email;

                CreatePage(false, false, 0, 0, writer, extension, "", folderProfiles, folderTimes,
                    user, data.Membros[c].JogosUsuarios, data.Membros[c].ApostasExtras);


                CreateClassificacao(writer, folderTimes, extension, data.Membros[c].ClassificacaoTimes);
            }
            document.Close();
            
            byte[] output = fs.ToArray();
            MemoryStream res = new MemoryStream(output);
            
            fs.Close();

            using (var fileStream = System.IO.File.Create(fileName))
            {
                res.Seek(0, SeekOrigin.Begin);
                res.CopyTo(fileStream);
            }


            CompressFile(fileName, compressedFileName);

            return res;
        }


        #endregion
    }
}
