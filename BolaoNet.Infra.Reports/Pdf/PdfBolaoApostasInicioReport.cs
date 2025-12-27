using ICSharpCode.SharpZipLib.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Reports.Pdf
{
    public class PdfBolaoApostasInicioReport :
        Domain.Interfaces.Services.Reports.FormatReport.IBolaoApostasInicioFormatReportService
    {
        #region Constants

        private const int FlagImageWidth = 40;
        private const int FlagImageHeight = 27;
        private const int UserImageWidth = 80;
        private const int UserImageHeight = 80;

        #endregion

        #region Constructors/Destructors

        public PdfBolaoApostasInicioReport()
        {

        }

        #endregion

        #region Methods

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
            List<Domain.Entities.ValueObjects.JogoUsuarioVO>[] grupo = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>[12];
            grupo[0] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //A
            grupo[1] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //B
            grupo[2] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //C
            grupo[3] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //D
            grupo[4] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //E
            grupo[5] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //F
            grupo[6] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //G
            grupo[7] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //H
            grupo[8] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //I
            grupo[9] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //J
            grupo[10] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //K
            grupo[11] = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();         //L

            List<Domain.Entities.ValueObjects.JogoUsuarioVO> dezesseis = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
            List<Domain.Entities.ValueObjects.JogoUsuarioVO> oitavas = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
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
                        else if (string.Compare(jogo.NomeGrupo, "D", true) == 0)
                            grupo[3].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "E", true) == 0)
                            grupo[4].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "F", true) == 0)
                            grupo[5].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "G", true) == 0)
                            grupo[6].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "H", true) == 0)
                            grupo[7].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "I", true) == 0)
                            grupo[8].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "J", true) == 0)
                            grupo[9].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "K", true) == 0)
                            grupo[10].Add(jogo);
                        else if (string.Compare(jogo.NomeGrupo, "L", true) == 0)
                            grupo[11].Add(jogo);
                        break;

                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseDezesseisAvosFinal:
                        dezesseis.Add(jogo);
                        break;
                    //case "oitavas de final":
                    case Domain.Entities.Campeonatos.CampeonatoFase.FaseOitavasFinal:
                        oitavas.Add(jogo);
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
                table.TotalWidth = 265;
                table.WriteSelectedRows(0, -1, 20, 830, writer.DirectContent);
            }

            PdfPTable tableExtra = CreateApostasExtras(fim, imageTimesPath, imageExtension, listExtra);
            tableExtra.TotalWidth = 212;
            tableExtra.WriteSelectedRows(0, -1, 360, 828, writer.DirectContent);

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

                tablePosition.WriteSelectedRows(0, -1, 200, 770, writer.DirectContent);
            }

            CreateGrupos(showOnlyPartidaValida, fim, writer, imageTimesPath, imageExtension, grupo);
            CreateEliminatorias(showOnlyPartidaValida, fim, writer, imageTimesPath, imageExtension, dezesseis, oitavas, quartas, semiFinais, finais);

        }

        private PdfPTable CreateUserData(string imageFolder, string imageExtension, string noPictureFile, Domain.Entities.Users.User user)
        {
            float[] relative = new float[] { 25, 75 };

            PdfPTable table = new PdfPTable(relative);


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

            var login = new Phrase("login: " + user.UserName, new Font(Font.HELVETICA, 10f, Font.NORMAL, Color.BLACK));
            var name = new Phrase(user.FullName, new Font(Font.HELVETICA, 12f, Font.NORMAL, Color.BLACK));
            PdfPCell cellUserName = new PdfPCell();
            cellUserName.AddElement(login);
            cellUserName.AddElement(name);
            cellUserName.HorizontalAlignment = Element.ALIGN_CENTER;
            cellUserName.VerticalAlignment = Element.ALIGN_MIDDLE;

            PdfPCell cellImage = new PdfPCell();
            cellImage.AddElement(imgUser);


            table.AddCell(imgUser);
            table.AddCell(cellUserName);

            //PdfPCell cellFullName = new PdfPCell(new Phrase(user.FullName, new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
            //table.AddCell(cellFullName);


            return table;
        }

        private PdfPTable CreateApostasExtras(bool fim, string imageTimesFolder, string imageExtension, IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> apostasExtras)
        {
            float[] relative = new float[] { 45, 10, 60 };

            if (fim)
                relative = new float[] { 60, 10, 30, 10 };

            PdfPTable table = new PdfPTable(relative);

            PdfPCell tit1 = new PdfPCell(new Phrase("Posição", new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
            tit1.BackgroundColor = Color.LIGHT_GRAY;
            tit1.HorizontalAlignment = Element.ALIGN_LEFT;
            tit1.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit1);

            PdfPCell tit2 = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
            tit2.BackgroundColor = Color.LIGHT_GRAY;
            tit2.HorizontalAlignment = Element.ALIGN_LEFT;
            tit2.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit2);

            PdfPCell tit3 = new PdfPCell(new Phrase("Time", new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
            tit3.BackgroundColor = Color.LIGHT_GRAY;
            tit3.HorizontalAlignment = Element.ALIGN_LEFT;
            tit3.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(tit3);

            if (fim)
            {
                PdfPCell tit4 = new PdfPCell(new Phrase("Pt", new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
                tit4.BackgroundColor = Color.LIGHT_GRAY;
                tit4.HorizontalAlignment = Element.ALIGN_LEFT;
                tit4.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(tit4);
            }


            //Para cada aposta extra
            foreach (Domain.Entities.ValueObjects.ApostaExtraUsuarioVO aposta in apostasExtras)
            {
                PdfPCell cellTitle = new PdfPCell(new Phrase(aposta.Titulo, new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
                //cellTitle.Border = 0;
                //cellTitle.BorderWidth = 0;
                cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;


                PdfPCell cellTime = new PdfPCell(new Phrase(aposta.NomeTime, new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
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
            PdfPTable grupoD = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo D", imagePath, list[3]);
            PdfPTable grupoE = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo E", imagePath, list[4]);
            PdfPTable grupoF = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo F", imagePath, list[5]);
            PdfPTable grupoG = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo G", imagePath, list[6]);
            PdfPTable grupoH = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo H", imagePath, list[7]);
            PdfPTable grupoI = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo I", imagePath, list[8]);
            PdfPTable grupoJ = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo J", imagePath, list[9]);
            PdfPTable grupoK = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo K", imagePath, list[10]);
            PdfPTable grupoL = CreateGrupoJogos(showOnlyPartidaValida, fim, imageExtension, "Grupo L", imagePath, list[11]);

            int width = 123;
            int spaceLeft = 20;

            if (fim)
            {
                width = 140;
                spaceLeft = 6;
            }

            int espacamento = 140;

            //int height = 720;
            int height = 760;
            grupoA.TotalWidth = width;
            grupoA.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), height, writer.DirectContent);

            grupoB.TotalWidth = width;
            grupoB.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), height, writer.DirectContent);

            grupoC.TotalWidth = width;
            grupoC.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), height, writer.DirectContent);

            grupoD.TotalWidth = width;
            grupoD.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 3), height, writer.DirectContent);

            height = height - espacamento;
            grupoE.TotalWidth = width;
            grupoE.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), height, writer.DirectContent);

            grupoF.TotalWidth = width;
            grupoF.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), height, writer.DirectContent);

            grupoG.TotalWidth = width;
            grupoG.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), height, writer.DirectContent);

            grupoH.TotalWidth = width;
            grupoH.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 3), height, writer.DirectContent);

            height = height - espacamento;
            grupoI.TotalWidth = width;
            grupoI.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), height, writer.DirectContent);

            grupoJ.TotalWidth = width;
            grupoJ.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), height, writer.DirectContent);

            grupoK.TotalWidth = width;
            grupoK.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), height, writer.DirectContent);

            grupoL.TotalWidth = width;
            grupoL.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 3), height, writer.DirectContent);
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
            //PdfPCell cellImageTimeCasa = new PdfPCell(); 
            //string time1FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime1 + "." + imageExtension);
            //if (System.IO.File.Exists(time1FileImage))
            //{
            //    Image imgTimeCasa = Image.GetInstance(time1FileImage);
            //    cellImageTimeCasa.AddElement(imgTimeCasa);
            //}

            PdfPCell cellImageTimeCasa = new PdfPCell();
            string time1FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime1 + "." + imageExtension);
            if (System.IO.File.Exists(time1FileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(time1FileImage);
                img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                Image imgTime = Image.GetInstance(img, Color.WHITE);
                cellImageTimeCasa.AddElement(imgTime);
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
            //PdfPCell cellImageTimeFora = new PdfPCell();
            //string time2FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime2 + "." + imageExtension);
            //if (System.IO.File.Exists(time2FileImage))
            //{
            //    Image imgTimeFora = Image.GetInstance(time2FileImage);
            //    cellImageTimeFora.AddElement(imgTimeFora);
            //}


            PdfPCell cellImageTimeFora = new PdfPCell();
            string time2FileImage = System.IO.Path.Combine(imagePath, jogo.NomeTime2 + "." + imageExtension);
            if (System.IO.File.Exists(time2FileImage))
            {
                System.Drawing.Image img = System.Drawing.Bitmap.FromFile(time2FileImage);
                img = ImageManagement.ResizeImage(img, FlagImageWidth, FlagImageHeight);
                Image imgTime = Image.GetInstance(img, Color.WHITE);
                cellImageTimeFora.AddElement(imgTime);
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

        private void CreateEliminatorias(bool showOnlyPartidaValida, bool fim, PdfWriter writer, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> dezesseis, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> oitavas, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> quartas, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> semiFinais, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> finais)
        {
            float[] relative = new float[] { 9, 0.2f, 9, 0.2f, 9, 0.2f, 9, 0.2f, 9, 0.2f, 9, 0.2f, 9, 0.2f, 9, 0.2f, 9 };
            PdfPTable table = new PdfPTable(relative);
            table.DefaultCell.BorderWidth = 0;
            table.DefaultCell.Padding = 0;

            table.AddCell(CreateDezesseisLeft(showOnlyPartidaValida, fim, imagePath, imageExtension, dezesseis));
            table.AddCell("");
            table.AddCell(CreateOitavasLeft(showOnlyPartidaValida, fim, imagePath, imageExtension, oitavas));
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
            table.AddCell(CreateOitavasRight(showOnlyPartidaValida, fim, imagePath, imageExtension, oitavas));
            table.AddCell("");
            table.AddCell(CreateDezesseisRight(showOnlyPartidaValida, fim, imagePath, imageExtension, dezesseis));

            table.TotalWidth = 553;
            table.SpacingAfter = 10;
            table.WriteSelectedRows(0, -1, 20, 320 + 10, writer.DirectContent);

            int sizeJogo = 26;
            int pos = 320;
            PdfContentByte cb = writer.DirectContent;

            #region Bloco de 16 avos
            //int dezesseisLeft = 68;
            //int dezesseisRight = 525;
            //int sizeSpaceDezesseis = 12;
            //int sizeLineDezesseis = 14;

            ////Bloco 1
            //
            //cb.MoveTo(dezesseisLeft, pos - sizeJogo);
            //cb.LineTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo);
            //cb.LineTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis/2);
            //cb.LineTo(dezesseisLeft + sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisRight - sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            ////Bloco 2
            //pos = pos - (sizeJogo + sizeSpaceDezesseis) * 2;
            //cb.MoveTo(dezesseisLeft, pos - sizeJogo);
            //cb.LineTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo);
            //cb.LineTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisLeft + sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisRight - sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            ////Bloco 3
            //pos = pos - (sizeJogo + sizeSpaceDezesseis) * 2;
            //cb.MoveTo(dezesseisLeft, pos - sizeJogo);
            //cb.LineTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo);
            //cb.LineTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisLeft + sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisRight - sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            ////Bloco 4
            //pos = pos - (sizeJogo + sizeSpaceDezesseis) * 2;
            //cb.MoveTo(dezesseisLeft, pos - sizeJogo);
            //cb.LineTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo);
            //cb.LineTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis);
            //cb.Stroke();

            //cb.MoveTo(dezesseisLeft, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisLeft + sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();

            //cb.MoveTo(dezesseisRight, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.LineTo(dezesseisRight - sizeLineDezesseis, pos - sizeJogo - sizeSpaceDezesseis / 2);
            //cb.Stroke();
            #endregion

            #region Bloco de oitavas

            int oitavasLeft = 129;
            int oitavasRight = 464;
            int sizeSpaceOitavas = 48;
            int sizeLineOitavas = 14;

            //Bloco 1
            pos = 311 - 26;
            cb.MoveTo(oitavasLeft, pos);
            cb.LineTo(oitavasLeft, pos - sizeSpaceOitavas);
            cb.Stroke();

            cb.MoveTo(oitavasRight, pos);
            cb.LineTo(oitavasRight, pos - sizeSpaceOitavas);
            cb.Stroke();

            cb.MoveTo(oitavasLeft, pos - sizeSpaceOitavas / 2);
            cb.LineTo(oitavasLeft + sizeLineOitavas, pos - sizeSpaceOitavas / 2);
            cb.Stroke();

            cb.MoveTo(oitavasRight, pos - sizeSpaceOitavas / 2);
            cb.LineTo(oitavasRight - sizeLineOitavas, pos - sizeSpaceOitavas / 2);
            cb.Stroke();

            //Bloco 2
            //pos = pos - (sizeJogo + sizeSpaceOitavas) * 2;
            pos = 149 - 26;
            cb.MoveTo(oitavasLeft, pos);
            cb.LineTo(oitavasLeft, pos - sizeSpaceOitavas);
            cb.Stroke();

            cb.MoveTo(oitavasRight, pos);
            cb.LineTo(oitavasRight, pos - sizeSpaceOitavas);
            cb.Stroke();

            cb.MoveTo(oitavasLeft, pos - sizeSpaceOitavas / 2);
            cb.LineTo(oitavasLeft + sizeLineOitavas, pos - sizeSpaceOitavas / 2);
            cb.Stroke();

            cb.MoveTo(oitavasRight, pos - sizeSpaceOitavas / 2);
            cb.LineTo(oitavasRight - sizeLineOitavas, pos - sizeSpaceOitavas / 2);
            cb.Stroke();

            #endregion

            #region Bloco de quartas

            int quartasLeft = 191;
            int quartasRight = 402;
            int sizeSpaceQuartas = 120;
            int sizeLineQuartas = 14;

            //Bloco 1
            pos = 263;
            cb.MoveTo(quartasLeft, pos - sizeJogo);
            cb.LineTo(quartasLeft, pos - sizeJogo - sizeSpaceQuartas);
            cb.Stroke();

            cb.MoveTo(quartasRight, pos - sizeJogo);
            cb.LineTo(quartasRight, pos - sizeJogo - sizeSpaceQuartas);
            cb.Stroke();

            cb.MoveTo(quartasLeft, pos - sizeJogo - sizeSpaceQuartas / 2);
            cb.LineTo(quartasLeft + sizeLineQuartas, pos - sizeJogo - sizeSpaceQuartas / 2);
            cb.Stroke();

            cb.MoveTo(quartasRight, pos - sizeJogo - sizeSpaceQuartas / 2);
            cb.LineTo(quartasRight - sizeLineQuartas, pos - sizeJogo - sizeSpaceQuartas / 2);
            cb.Stroke();

            #endregion


            #region Bloco de semifinais

            int semiLeft = 279;
            int semiRight = 314;
            int sizeSpaceSemi = 120;
            int sizeLineSemi = 14;

            //Bloco 1
            pos = 263;
            cb.MoveTo(semiLeft, pos - sizeJogo);
            cb.LineTo(semiLeft, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.Stroke();

            cb.MoveTo(semiRight, pos - sizeJogo);
            cb.LineTo(semiRight, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.Stroke();

            cb.MoveTo(semiLeft, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.LineTo(semiLeft - sizeLineSemi, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.Stroke();

            cb.MoveTo(semiRight, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.LineTo(semiRight + sizeLineSemi, pos - sizeJogo - sizeSpaceSemi / 2);
            cb.Stroke();

            #endregion

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

            string dateDescription = jogo.DataJogo.ToString("dd/MM HH") + "h " + jogo.NomeEstadio;

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

        private PdfPTable CreateDezesseisLeft(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(73, list)));
            //fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(74, list)));
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(75, list)));
            //fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(76, list)));
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(77, list)));
            //fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(78, list)));
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(79, list)));
            //fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(80, list)));
            fase.AddCell(" ");
            return fase;
        }

        private PdfPTable CreateOitavasLeft(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(89, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(90, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(91, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(92, list)));

            fase.AddCell(" ");

            return fase;
        }

        private PdfPTable CreateQuartasLeft(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(97, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(98, list)));
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
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(101, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");

            return fase;
        }

        private PdfPTable CreateDezesseisRight(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(81, list)));
            //fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(82, list)));
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(83, list)));
            //fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(84, list)));
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(85, list)));
            //fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(86, list)));
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(87, list)));
            //fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true,
                imagePath, imageExtension, GetJogoByLabel(88, list)));

            fase.AddCell(" ");
            return fase;
        }

        private PdfPTable CreateOitavasRight(bool showOnlyPartidaValida, bool fim, string imagePath, string imageExtension, IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list)
        {
            PdfPTable fase = new PdfPTable(1);
            fase.DefaultCell.Padding = 0;
            fase.DefaultCell.BorderWidth = 0;

            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(93, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(94, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(95, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(96, list)));

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
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(99, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(100, list)));
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
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(102, list)));
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
            fase.AddCell(" ");
            fase.AddCell(" ");


            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(104, list)));
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");
            fase.AddCell(" ");

            fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false,
                imagePath, imageExtension, GetJogoByLabel(103, list)));
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
            switch (data.TipoCampeonato)
            {
                case Domain.Entities.Campeonatos.Campeonato.Tipos.CopaAmerica:
                    return new CopaAmerica.PdfBolaoCopaAmericaApostasInicioReport().Generate(fileName, compressedFileName, extension, folderProfiles, folderTimes, data);
                case Domain.Entities.Campeonatos.Campeonato.Tipos.Outros:
                    break;
            }

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
