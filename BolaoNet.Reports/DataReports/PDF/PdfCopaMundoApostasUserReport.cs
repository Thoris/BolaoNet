using BolaoNet.Reports.Entidades;
using BolaoNet.Reports.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.DataReports.PDF
{
    public class PdfCopaMundoApostasUserReport : BasePdfCopaMundoReport, IApostasUserReport
    {
        #region Constructors/Destructors
        
        public PdfCopaMundoApostasUserReport(string imageTimesFolder, string imageUsersFolder, string outputFile, string imageExtension)
            : base(imageTimesFolder, imageUsersFolder, outputFile, imageExtension)
        {

        }

        #endregion

        #region IApostasUserReport members
        public Stream CreatePageUserApostas(Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, Entities.Users.User user, IList<Entities.Campeonatos.Jogo> jogos, IList<Entities.Boloes.JogoUsuario> jogosUsuarios, IList<Entities.Boloes.ApostaExtra> apostasExtras, IList<Entities.Boloes.ApostaExtraUsuario> apostasUsuarios)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (user == null)
                throw new ArgumentException("user");
            if (jogos == null)
                throw new ArgumentException("jogos");
            if (jogos.Count == 0)
                throw new ArgumentException("jogos.Count");
            if (jogosUsuarios == null)
                throw new ArgumentException("jogosUsuarios");
            if (jogosUsuarios.Count == 0)
                throw new ArgumentException("jogosUsuarios.Count");


            IList<EntityJogoUsuario> jogosList = base.MergeJogoJogoUsuario(jogos, jogosUsuarios);
            IList<EntityApostasExtras> apostasList = base.MergeApostasApostasUsuario(apostasExtras, apostasUsuarios);


            Document document = new Document(PageSize.A4);


            PdfWriter writer = PdfWriter.GetInstance(document, _outputStream);

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
            document.Header = header;


            document.Open();

            document.NewPage();

            //Criando a página com a lista dos dados
            CreatePage(false, false, 0, 0, writer, _imageTimesFolder, user, jogosList, apostasList);

            document.Close();

            return _outputStream;

        }
        #endregion
    }
    //{
    //    #region Constants

    //    private const string NoPictureFile = "no-file";

    //    #endregion

    //    #region Variables

    //    private string _imageTimesFolder;
    //    private string _imageUsersFolder;
    //    private string _outputFile;
    //    private string _imageExtension;
    //    private Stream _outputStream = null;

    //    #endregion

    //    #region Constructors/Destructors

    //    public PdfCopaMundoApostasUserReport(string imageTimesFolder, string imageUsersFolder, string outputFile, string imageExtension)
    //    {
    //        _imageTimesFolder = imageTimesFolder;
    //        _imageUsersFolder = imageUsersFolder;
    //        _outputFile = outputFile;
    //        _imageExtension = imageExtension;


    //        _outputStream = new FileStream(outputFile, FileMode.Create);
    //    }

    //    #endregion

    //    #region IApostasUserReport members

    //    public Stream CreatePageUserApostas(Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, Entities.Users.User user, IList<Entities.Campeonatos.Jogo> jogos, IList<Entities.Boloes.JogoUsuario> jogosUsuarios, IList<Entities.Boloes.ApostaExtra> apostasExtras, IList<Entities.Boloes.ApostaExtraUsuario> apostasUsuarios)
    //    {
    //        if (bolao == null)
    //            throw new ArgumentException("bolao");
    //        if (campeonato == null)
    //            throw new ArgumentException("campeonato");
    //        if (user == null)
    //            throw new ArgumentException("user");
    //        if (jogos == null)
    //            throw new ArgumentException("jogos");
    //        if (jogos.Count == 0)
    //            throw new ArgumentException("jogos.Count");
    //        if (jogosUsuarios == null)
    //            throw new ArgumentException("jogosUsuarios");
    //        if (jogosUsuarios.Count == 0)
    //            throw new ArgumentException("jogosUsuarios.Count");


    //        IList<EntityJogoUsuario> jogosList = base.MergeJogoJogoUsuario(jogos, jogosUsuarios);
    //        IList<EntityApostasExtras> apostasList = base.MergeApostasApostasUsuario(apostasExtras, apostasUsuarios);


    //        Document document = new Document(PageSize.A4);


    //        PdfWriter writer = PdfWriter.GetInstance(document, _outputStream);

    //        // we Add a Footer that will show up on PAGE 1
    //        HeaderFooter footer = new HeaderFooter(new Phrase("Página: "), true);
    //        footer.Border = Rectangle.NO_BORDER;
    //        document.Footer = footer;

    //        // we Add a Header that will show up on PAGE 2
    //        HeaderFooter header = new HeaderFooter(new Phrase(bolao.Nome), false);
    //        document.Header = header;


    //        document.Open();

    //        document.NewPage();

    //        //Criando a página com a lista dos dados
    //        CreatePage(false, false, 0, 0, writer, _imageTimesFolder, user, jogosList, apostasList);

    //        document.Close();

    //        return _outputStream;

    //    }

    //    public void CreatePage(bool showOnlyPartidaValida, bool fim, int posicao, int pontos, PdfWriter writer, string imagePath, Entities.Users.User user, IList<EntityJogoUsuario> list, IList<EntityApostasExtras> listExtra)
    //    {
    //        List<EntityJogoUsuario>[] grupo = new List<EntityJogoUsuario>[8];
    //        grupo[0] = new List<EntityJogoUsuario>();         //A
    //        grupo[1] = new List<EntityJogoUsuario>();         //B
    //        grupo[2] = new List<EntityJogoUsuario>();         //C
    //        grupo[3] = new List<EntityJogoUsuario>();         //D
    //        grupo[4] = new List<EntityJogoUsuario>();         //E
    //        grupo[5] = new List<EntityJogoUsuario>();         //F
    //        grupo[6] = new List<EntityJogoUsuario>();         //G
    //        grupo[7] = new List<EntityJogoUsuario>();         //H

    //        List<EntityJogoUsuario> oitavas = new List<EntityJogoUsuario>();
    //        List<EntityJogoUsuario> quartas = new List<EntityJogoUsuario>();
    //        List<EntityJogoUsuario> semiFinais = new List<EntityJogoUsuario>();
    //        List<EntityJogoUsuario> finais = new List<EntityJogoUsuario>();

    //        //Para cada jogo do campeonato
    //        foreach (EntityJogoUsuario jogo in list)
    //        {
    //            switch (jogo.Jogo.NomeFase.ToLower())
    //            {
    //                case "classificatória":

    //                    if (string.Compare(jogo.Jogo.NomeGrupo, "A", true) == 0)
    //                        grupo[0].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "B", true) == 0)
    //                        grupo[1].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "C", true) == 0)
    //                        grupo[2].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "D", true) == 0)
    //                        grupo[3].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "E", true) == 0)
    //                        grupo[4].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "F", true) == 0)
    //                        grupo[5].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "G", true) == 0)
    //                        grupo[6].Add(jogo);
    //                    else if (string.Compare(jogo.Jogo.NomeGrupo, "H", true) == 0)
    //                        grupo[7].Add(jogo);


    //                    break;
    //                case "oitavas de final":
    //                    oitavas.Add(jogo);
    //                    break;
    //                case "quartas de final":
    //                    quartas.Add(jogo);
    //                    break;
    //                case "semi finais":
    //                    semiFinais.Add(jogo);
    //                    break;
    //                case "final":
    //                    finais.Add(jogo);
    //                    break;
    //            }//end switch fase


    //        }//end foreach



    //        if (user != null)
    //        {
    //            PdfPTable table = CreateUserData(_imageUsersFolder, user);
    //            table.TotalWidth = 100;
    //            table.WriteSelectedRows(0, -1, 33, 795, writer.DirectContent);
    //        }

    //        PdfPTable tableExtra = CreateApostasExtras(fim, _imageTimesFolder, listExtra);
    //        tableExtra.TotalWidth = 200;
    //        tableExtra.WriteSelectedRows(0, -1, 360, 780, writer.DirectContent);


    //        if (fim)
    //        {
    //            PdfPTable tablePosition = new PdfPTable(1);
    //            tablePosition.TotalWidth = 100;

    //            PdfPCell cellTitPosition = new PdfPCell(new Phrase("Posição", new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
    //            cellTitPosition.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellTitPosition.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellTitPosition.BackgroundColor = Color.LIGHT_GRAY;

    //            PdfPCell cellPosition = new PdfPCell(new Phrase(posicao.ToString(), new Font(Font.HELVETICA, 20f, Font.BOLD, Color.BLACK)));
    //            cellPosition.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellPosition.VerticalAlignment = Element.ALIGN_MIDDLE;


    //            PdfPCell cellTitPontos = new PdfPCell(new Phrase("Pontos", new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
    //            cellTitPontos.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellTitPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellTitPontos.BackgroundColor = Color.LIGHT_GRAY;

    //            PdfPCell cellPontos = new PdfPCell(new Phrase(pontos.ToString(), new Font(Font.HELVETICA, 20f, Font.BOLD, Color.BLACK)));
    //            cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;

    //            tablePosition.AddCell(cellTitPosition);
    //            tablePosition.AddCell(cellPosition);
    //            tablePosition.AddCell(cellTitPontos);
    //            tablePosition.AddCell(cellPontos);

    //            tablePosition.WriteSelectedRows(0, -1, 200, 780, writer.DirectContent);
    //        }

    //        CreateGrupos(showOnlyPartidaValida, fim, writer, _imageTimesFolder, grupo);
    //        CreateEliminatorias(showOnlyPartidaValida, fim, writer, _imageTimesFolder, oitavas, quartas, semiFinais, finais);
    //    }
    //    private PdfPTable CreateUserData(string imageFolder, Entities.Users.User user)
    //    {
    //        //float[] relative = new float[] { 30, 70 };

    //        PdfPTable table = new PdfPTable(1);


    //        Image imgUser = null;

    //        //Buscando a imagem do usuário
    //        string fileImage = System.IO.Path.Combine(imageFolder, user.UserName + "." + _imageExtension);

    //        //Se existir a imagem do usuário
    //        if (System.IO.File.Exists(fileImage))
    //            imgUser = Image.GetInstance(fileImage);
    //        else
    //        {
    //            string noFileName = System.IO.Path.Combine(imageFolder, NoPictureFile + "." + _imageExtension);
    //            if (System.IO.File.Exists(noFileName))
    //                imgUser = Image.GetInstance(noFileName);
    //            else
    //            {
                    
    //                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(160, 120);
    //                imgUser = Image.GetInstance(bmp, Color.BLACK);
    //            }
    //        }

    //        PdfPCell cellUserName = new PdfPCell(new Phrase(user.UserName, new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
    //        cellUserName.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellUserName.VerticalAlignment = Element.ALIGN_MIDDLE;

    //        PdfPCell cellImage = new PdfPCell();
    //        cellImage.AddElement(imgUser);


    //        table.AddCell(imgUser);
    //        table.AddCell(cellUserName);

    //        PdfPCell cellFullName = new PdfPCell(new Phrase(user.FullName, new Font(Font.HELVETICA, 9f, Font.NORMAL, Color.BLACK)));
    //        table.AddCell(cellFullName);


    //        return table;
    //    }
    //    private PdfPTable CreateApostasExtras(bool fim, string imageTimesFolder, IList<EntityApostasExtras> apostasExtras)
    //    {
    //        float[] relative = new float[] { 60, 10, 30 };

    //        if (fim)
    //            relative = new float[] { 60, 10, 30, 10 };

    //        PdfPTable table = new PdfPTable(relative);



    //        PdfPCell tit1 = new PdfPCell(new Phrase("Posição", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //        tit1.BackgroundColor = Color.LIGHT_GRAY;
    //        tit1.HorizontalAlignment = Element.ALIGN_LEFT;
    //        tit1.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        table.AddCell(tit1);

    //        PdfPCell tit2 = new PdfPCell(new Phrase("", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //        tit2.BackgroundColor = Color.LIGHT_GRAY;
    //        tit2.HorizontalAlignment = Element.ALIGN_LEFT;
    //        tit2.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        table.AddCell(tit2);

    //        PdfPCell tit3 = new PdfPCell(new Phrase("Time", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //        tit3.BackgroundColor = Color.LIGHT_GRAY;
    //        tit3.HorizontalAlignment = Element.ALIGN_LEFT;
    //        tit3.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        table.AddCell(tit3);

    //        if (fim)
    //        {
    //            PdfPCell tit4 = new PdfPCell(new Phrase("Pt", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //            tit4.BackgroundColor = Color.LIGHT_GRAY;
    //            tit4.HorizontalAlignment = Element.ALIGN_LEFT;
    //            tit4.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            table.AddCell(tit4);
    //        }


    //        //Para cada aposta extra
    //        foreach (EntityApostasExtras aposta in apostasExtras)
    //        {
    //            PdfPCell cellTitle = new PdfPCell(new Phrase(aposta.ApostaExtra.Titulo, new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //            //cellTitle.Border = 0;
    //            //cellTitle.BorderWidth = 0;
    //            cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;


    //            PdfPCell cellTime = new PdfPCell(new Phrase(aposta.ApostaExtraUsuario.NomeTime, new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //            //cellTime.Border = 0;
    //            //cellTime.BorderWidth = 0;
    //            cellTime.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellTime.VerticalAlignment = Element.ALIGN_MIDDLE;


    //            PdfPCell cellImageTime = new PdfPCell();
    //            string timeFileImage = System.IO.Path.Combine(imageTimesFolder, aposta.ApostaExtraUsuario.NomeTime + "." + _imageExtension);
    //            if (System.IO.File.Exists(timeFileImage))
    //            {
    //                Image imgTime = Image.GetInstance(timeFileImage);
    //                cellImageTime.AddElement(imgTime);

    //            }
    //            //cellImageTime.Border = 0;
    //            //cellImageTime.BorderWidth = 0;
    //            //cellImageTime.HorizontalAlignment = Element.ALIGN_CENTER;
    //            //cellImageTime.VerticalAlignment = Element.ALIGN_MIDDLE;




    //            table.AddCell(cellTitle);
    //            table.AddCell(cellImageTime);
    //            table.AddCell(cellTime);

    //            if (fim)
    //            {

    //                PdfPCell cellPontos = new PdfPCell(new Phrase(aposta.ApostaExtraUsuario.Pontos.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //                cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
    //                cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
    //                table.AddCell(cellPontos);
    //            }



    //        }//end foreach aposta extra


    //        return table;
    //    }

    //    private void CreateGrupos(bool showOnlyPartidaValida, bool fim, PdfWriter writer, string imagePath, IList<EntityJogoUsuario>[] list)
    //    {
    //        PdfPTable grupoA = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo A", imagePath, list[0]);
    //        PdfPTable grupoB = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo B", imagePath, list[1]);
    //        PdfPTable grupoC = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo C", imagePath, list[2]);
    //        PdfPTable grupoD = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo D", imagePath, list[3]);
    //        PdfPTable grupoE = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo E", imagePath, list[4]);
    //        PdfPTable grupoF = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo F", imagePath, list[5]);
    //        PdfPTable grupoG = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo G", imagePath, list[6]);
    //        PdfPTable grupoH = CreateGrupoJogos(showOnlyPartidaValida, fim, "Grupo H", imagePath, list[7]);


    //        int width = 123;
    //        int spaceLeft = 20;

    //        if (fim)
    //        {
    //            width = 140;
    //            spaceLeft = 6;
    //        }

    //        grupoA.TotalWidth = width;
    //        grupoA.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), 660, writer.DirectContent);

    //        grupoB.TotalWidth = width;
    //        grupoB.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), 660, writer.DirectContent);

    //        grupoC.TotalWidth = width;
    //        grupoC.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), 660, writer.DirectContent);

    //        grupoD.TotalWidth = width;
    //        grupoD.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 3), 660, writer.DirectContent);

    //        grupoE.TotalWidth = width;
    //        grupoE.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 0), 470, writer.DirectContent);

    //        grupoF.TotalWidth = width;
    //        grupoF.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 1), 470, writer.DirectContent);

    //        grupoG.TotalWidth = width;
    //        grupoG.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 2), 470, writer.DirectContent);

    //        grupoH.TotalWidth = width;
    //        grupoH.WriteSelectedRows(0, -1, spaceLeft + ((width + spaceLeft) * 3), 470, writer.DirectContent);
    //    }
    //    private PdfPTable CreateGrupoJogos(bool showOnlyPartidaValida, bool fim, string title, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable pjogos = new PdfPTable(1);


    //        pjogos.AddCell(new Phrase(title, new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
    //        pjogos.DefaultCell.Border = 0;
    //        pjogos.DefaultCell.Padding = 0;

    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, imagePath, list[0]));
    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.WHITE, imagePath, list[1]));
    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, imagePath, list[2]));
    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.WHITE, imagePath, list[3]));
    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, imagePath, list[4]));
    //        pjogos.AddCell(CreateJogoInGroupFormat(showOnlyPartidaValida, fim, Color.WHITE, imagePath, list[5]));


    //        return pjogos;
    //    }
    //    private PdfPTable CreateJogoInGroupFormat(bool showOnlyPartidaValida, bool fim, Color backColor, string imagePath, EntityJogoUsuario jogo)
    //    {
    //        //Criando a table contendo todas as informações do jogo
    //        PdfPTable pjogoFull = new PdfPTable(1);
    //        pjogoFull.DefaultCell.Border = 0;
    //        pjogoFull.DefaultCell.BorderWidth = 0;

    //        pjogoFull.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //        pjogoFull.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        pjogoFull.DefaultCell.BackgroundColor = backColor;

    //        pjogoFull.DefaultCell.Padding = 0;

    //        //Definindo o tamanho para cada campo
    //        float[] relative = { 3f, 5, 2f, 1f, 2f, 5, 3f};

    //        if (fim)
    //        {
    //            relative = new float[] { 3f, 5, 2f, 1f, 2f, 5, 3f, 2f};
    //        }

    //        //Criando a tabela contendo os dados da partida
    //        PdfPTable pjogo = new PdfPTable(relative);



    //        //Criando a imagem do time de casa
    //        PdfPCell cellImageTimeCasa = new PdfPCell();
    //        //string time1FileImage = System.IO.Path.Combine(imagePath, jogo.Jogo.NomeTime1 + ".gif");
    //        string time1FileImage = System.IO.Path.Combine(imagePath, jogo.Jogo.NomeTime1 + "." + _imageExtension);
    //        if (System.IO.File.Exists(time1FileImage))
    //        {
    //            Image imgTimeCasa = Image.GetInstance(time1FileImage);
    //            cellImageTimeCasa.AddElement(imgTimeCasa);
    //        }
    //        cellImageTimeCasa.HorizontalAlignment = Element.ALIGN_LEFT;
    //        cellImageTimeCasa.VerticalAlignment = Element.ALIGN_MIDDLE;
                
    //        cellImageTimeCasa.BorderWidth = 0;



    //        //Criando a descrição do time de fora
    //        PdfPCell cellTimeCasa = new PdfPCell(new Phrase(jogo.Jogo.NomeTime1, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //        cellTimeCasa.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellTimeCasa.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        cellTimeCasa.BorderWidth = 0;


    //        PdfPCell cellResultCasa = new PdfPCell();                
    //        if (fim)
    //        {
    //            PdfPTable table = new PdfPTable(1);
    //            PdfPCell cellAposta1 = new PdfPCell(new Phrase(jogo.JogoUsuario.ApostaTime1.ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
    //            cellAposta1.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellAposta1.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellAposta1.BackgroundColor = Color.YELLOW;
    //            cellAposta1.BorderWidth = 0;
                
    //            PdfPCell cellResult1 = new PdfPCell(new Phrase(jogo.Jogo.GolsTime1.ToString (), new Font(Font.HELVETICA, 4f, Font.NORMAL, Color.BLACK)));
    //            cellResult1.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellResult1.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellResult1.BorderWidth = 0;
                

    //            table.AddCell(cellAposta1);
    //            table.AddCell(cellResult1);
    //            cellResultCasa.BorderWidth = 0;
    //            cellResultCasa.AddElement(table);
    //        }
    //        else
    //        {

    //            if ((showOnlyPartidaValida && jogo.Jogo.PartidaValida) || !showOnlyPartidaValida)
    //            {
    //                //Criando o resultado do time de casa
    //                cellResultCasa = new PdfPCell(new Phrase(jogo.JogoUsuario.ApostaTime1.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //            }
    //            else
    //            {
    //                //Criando o resultado do time de casa
    //                cellResultCasa = new PdfPCell(new Phrase(" ", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));                
    //            }
    //                cellResultCasa.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellResultCasa.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellResultCasa.BorderWidth = 0;
    //            cellResultCasa.BackgroundColor = Color.YELLOW;
    //        }


    //        //Criando a divisão entre os times
    //        PdfPCell cellVersus = new PdfPCell();
    //        cellVersus.AddElement(new Phrase("x", new Font(Font.HELVETICA, 7f, Font.NORMAL, Color.BLACK)));
    //        cellVersus.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellVersus.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        cellVersus.BorderWidth = 0;


    //        PdfPCell cellResultFora = new PdfPCell();                
    //        if (fim)
    //        {
    //            PdfPTable table = new PdfPTable(1);
    //            PdfPCell cellAposta2 = new PdfPCell(new Phrase(jogo.JogoUsuario.ApostaTime2.ToString(), new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
    //            cellAposta2.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellAposta2.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellAposta2.BackgroundColor = Color.YELLOW;
    //            cellAposta2.BorderWidth = 0;

    //            PdfPCell cellResult2 = new PdfPCell(new Phrase(jogo.Jogo.GolsTime2.ToString(), new Font(Font.HELVETICA, 4f, Font.NORMAL, Color.BLACK)));
    //            cellResult2.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellResult2.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellResult2.BorderWidth = 0;


    //            table.AddCell(cellAposta2);
    //            table.AddCell(cellResult2);
    //            cellResultFora.BorderWidth = 0;
    //            cellResultFora.AddElement(table);
    //        }
    //        else
    //        {
    //            if ((showOnlyPartidaValida && jogo.Jogo.PartidaValida) || !showOnlyPartidaValida)
    //            {
    //                //Criando o resultado do time de fora
    //                cellResultFora = new PdfPCell(new Phrase(jogo.JogoUsuario.ApostaTime2.ToString(), new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
    //            }
    //            else
    //            {
    //                //Criando o resultado do time de fora
    //                cellResultFora = new PdfPCell(new Phrase(" ", new Font(Font.HELVETICA, 7f, Font.BOLD, Color.BLACK)));
                
    //            }
    //                cellResultFora.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellResultFora.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellResultFora.BorderWidth = 0;
    //            cellResultFora.BackgroundColor = Color.YELLOW;
    //        }

    //        //Criando o nome do time que está fora
    //        PdfPCell cellTimeFora = new PdfPCell(new Phrase(jogo.Jogo.NomeTime2, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //        cellTimeFora.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellTimeFora.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        cellTimeFora.BorderWidth = 0;


    //        //Criando a imagem do time de fora
    //        PdfPCell cellImageTimeFora = new PdfPCell();
    //        string time2FileImage = System.IO.Path.Combine(imagePath, jogo.Jogo.NomeTime2 + "." + _imageExtension);
    //        if (System.IO.File.Exists(time2FileImage))
    //        {
    //            Image imgTimeFora = Image.GetInstance(time2FileImage);
    //            cellImageTimeFora.AddElement(imgTimeFora);
    //        }
    //        cellImageTimeFora.BorderWidth = 0;
    //        cellImageTimeFora.HorizontalAlignment = Element.ALIGN_RIGHT;
    //        cellImageTimeFora.VerticalAlignment = Element.ALIGN_MIDDLE;
            

    //        //Adicioando os campos na tabela
    //        pjogo.AddCell(cellImageTimeCasa);
    //        pjogo.AddCell(cellTimeCasa);
    //        pjogo.AddCell(cellResultCasa);
    //        pjogo.AddCell(cellVersus);
    //        pjogo.AddCell(cellResultFora);
    //        pjogo.AddCell(cellTimeFora);
    //        pjogo.AddCell(cellImageTimeFora);

    //        if (fim)
    //        {
    //            //Criando o nome do time que está fora
    //            PdfPCell cellPontos = new PdfPCell(new Phrase(jogo.JogoUsuario.Pontos.ToString(), new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //            cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellPontos.BorderWidth = 0;

    //            if (jogo.Jogo.PartidaValida)
    //            {
    //                if (jogo.JogoUsuario.Pontos == 0)
    //                    cellPontos.BackgroundColor = Color.RED;
                    
    //            }
    //            else
    //            {
    //                cellPontos.BackgroundColor = Color.YELLOW;
    //            }
    //            //cellPontos.BackgroundColor = Color.RED;
    //            pjogo.AddCell(cellPontos);
    //        }



    //        //Adicionando no grupo principal os dados do jogo
    //        pjogoFull.AddCell(pjogo);

    //        string footer = jogo.Jogo.DataJogo.ToString("dd/MM - HH:mm") + " - " + jogo.Jogo.NomeEstadio;

    //        //Adicionando o local do jogo
    //        PdfPCell dateJogo = new PdfPCell(new Phrase(footer, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //        dateJogo.Padding = 0;
    //        dateJogo.BorderWidth = 0;
    //        dateJogo.HorizontalAlignment = Element.ALIGN_CENTER;
    //        dateJogo.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        dateJogo.BackgroundColor = backColor;
    //        dateJogo.PaddingBottom = 2;

    //        //Adicionando o local do jogo na tabela principal
    //        pjogoFull.AddCell(dateJogo);

    //        return pjogoFull;
    //    }

    //    private void CreateEliminatorias(bool showOnlyPartidaValida, bool fim, PdfWriter writer, string imagePath, IList<EntityJogoUsuario> oitavas, IList<EntityJogoUsuario> quartas, IList<EntityJogoUsuario> semiFinais, IList<EntityJogoUsuario> finais)
    //    {
    //        float[] relative = new float[] { 10, 0.5f, 9, 0.5f, 9, 0.5f, 9, 0.5f, 9, 0.5f, 9, 0.5f, 10 };
    //        PdfPTable table = new PdfPTable(relative);
    //        table.DefaultCell.BorderWidth = 0;
    //        table.DefaultCell.Padding = 0;



    //        table.AddCell(CreateOitavasLeft(showOnlyPartidaValida, fim, imagePath, oitavas));
    //        table.AddCell("");
    //        table.AddCell(CreateQuartasLeft(showOnlyPartidaValida, fim, imagePath, quartas));
    //        table.AddCell("");
    //        table.AddCell(CreateSemiFinaisLeft(showOnlyPartidaValida, fim, imagePath, semiFinais));
    //        table.AddCell("");
    //        table.AddCell(CreateFinais(showOnlyPartidaValida, fim, imagePath, finais));
    //        table.AddCell("");
    //        table.AddCell(CreateSemiFinaisRight(showOnlyPartidaValida, fim, imagePath, semiFinais));
    //        table.AddCell("");
    //        table.AddCell(CreateQuartasRight(showOnlyPartidaValida, fim, imagePath, quartas));
    //        table.AddCell("");
    //        table.AddCell(CreateOitavasRight(showOnlyPartidaValida, fim, imagePath, oitavas));

    //        table.TotalWidth = 580;

    //        table.WriteSelectedRows(0, -1, 5, 280, writer.DirectContent);


    //        int oitavasLeft = 45;
    //        int oitavasRight = 541;

    //        PdfContentByte cb = writer.DirectContent;
    //        cb.MoveTo(oitavasLeft, 247);
    //        cb.LineTo(oitavasLeft, 223);
    //        cb.Stroke();

    //        cb.MoveTo(oitavasLeft, 133);
    //        cb.LineTo(oitavasLeft, 109);
    //        cb.Stroke();


    //        cb.MoveTo(oitavasRight, 247);
    //        cb.LineTo(oitavasRight, 223);
    //        cb.Stroke();

    //        cb.MoveTo(oitavasRight, 133);
    //        cb.LineTo(oitavasRight, 109);
    //        cb.Stroke();

    //        cb.MoveTo(oitavasLeft, 233);
    //        cb.LineTo(oitavasLeft + 49, 233);
    //        cb.Stroke();


    //        cb.MoveTo(oitavasLeft, 121);
    //        cb.LineTo(oitavasLeft + 49, 121);
    //        cb.Stroke();


    //        cb.MoveTo(oitavasRight, 233);
    //        cb.LineTo(oitavasRight - 45, 233);
    //        cb.Stroke();


    //        cb.MoveTo(oitavasRight, 121);
    //        cb.LineTo(oitavasRight - 45, 121);
    //        cb.Stroke();


    //        //   |
    //        cb.MoveTo(130, 223);
    //        cb.LineTo(130, 139);
    //        cb.Stroke();
    //        //   |
    //        cb.MoveTo(460, 223);
    //        cb.LineTo(460, 139);
    //        cb.Stroke();

    //        // -
    //        cb.MoveTo(130, 180);
    //        cb.LineTo(180 - 4, 180);
    //        cb.Stroke();
    //        // -
    //        cb.MoveTo(460, 180);
    //        cb.LineTo(410 + 3, 180);
    //        cb.Stroke();



    //        cb.MoveTo(280, 211);
    //        cb.LineTo(280, 180);
    //        cb.Stroke();



    //        cb.MoveTo(310, 211);
    //        cb.LineTo(310, 180);
    //        cb.Stroke();



    //        cb.MoveTo(280, 180);
    //        cb.LineTo(247 + 6, 180);
    //        cb.Stroke();


    //        cb.MoveTo(310, 180);
    //        cb.LineTo(343 - 6, 180);
    //        cb.Stroke();

    //    }
    //    private PdfPTable CreateTimeEliminatoriaFormat(bool showOnlyPartidaValida, bool fim, bool showTitle, string imagePath, bool timeCasa, EntityJogoUsuario jogo)
    //    {
    //        float[] relative = null;

    //        if (showTitle)
    //        {
    //            relative = new float[] { 20, 20, 40, 20 };

    //            if (fim)
    //                relative = new float[] { 20, 20, 40, 20, 10, 20 };
    //        }
    //        else
    //        {
    //            relative = new float[] { 20, 60, 20 };

    //            if (fim)
    //                relative = new float[] { 20, 60, 20, 10, 20 };

    //        }


    //        PdfPTable time = new PdfPTable(relative);
    //        time.DefaultCell.Padding = 0;

    //        if (showTitle)
    //        {
    //            PdfPCell cellDescription = new PdfPCell(new Phrase((timeCasa ? jogo.Jogo.DescricaoTime1 : jogo.Jogo.DescricaoTime2),
    //                new Font(Font.HELVETICA, 5f, Font.BOLD, Color.BLACK)));
    //            cellDescription.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellDescription.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellDescription.BorderWidth = 0;
    //            time.AddCell(cellDescription);
    //        }

    //        //Criando a imagem do time 
    //        PdfPCell cellImageTime = new PdfPCell();
    //        string timeFileImage = System.IO.Path.Combine(imagePath, (timeCasa ? jogo.JogoUsuario.NomeTimeResult1 : jogo.JogoUsuario.NomeTimeResult2) + "." + _imageExtension);
    //        if (System.IO.File.Exists(timeFileImage))
    //        {
    //            Image imgTime = Image.GetInstance(timeFileImage);
    //            cellImageTime.AddElement(imgTime);
    //        }
    //        cellImageTime.BorderWidth = 0;

    //        //Criando a descrição do time de fora

    //        string strTimeCasa = timeCasa ? jogo.JogoUsuario.NomeTimeResult1 : jogo.JogoUsuario.NomeTimeResult2;
    //        if (string.IsNullOrEmpty(strTimeCasa))
    //            strTimeCasa = " ? ";

    //        //PdfPCell cellTime = new PdfPCell(new Phrase((timeCasa ? jogo.Time1.Nome : jogo.Time2.Nome),
    //        PdfPCell cellTime = new PdfPCell(new Phrase((strTimeCasa), new Font(Font.HELVETICA, 4.5f, Font.NORMAL, Color.BLACK)));
    //        cellTime.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellTime.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        cellTime.BorderWidth = 0;

    //        //Criando o resultado do time 
    //        PdfPCell cellResult = new PdfPCell();

    //        if ((showOnlyPartidaValida && jogo.Jogo.PartidaValida) || !showOnlyPartidaValida)
    //        {
    //            cellResult.AddElement(new Phrase((timeCasa ? jogo.JogoUsuario.ApostaTime1.ToString() : jogo.JogoUsuario.ApostaTime2.ToString()),
    //                //cellResult = new PdfPCell(new Phrase((timeCasa ? jogo.ApostaTime1.ToString() : jogo.ApostaTime2.ToString()),
    //                new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));
    //        }
    //        else
    //        {
    //            cellResult.AddElement(new Phrase((""),
    //                //cellResult = new PdfPCell(new Phrase((timeCasa ? jogo.ApostaTime1.ToString() : jogo.ApostaTime2.ToString()),
    //            new Font(Font.HELVETICA, 6f, Font.BOLD, Color.BLACK)));

    //        }

    //        cellResult.HorizontalAlignment = Element.ALIGN_CENTER;
    //        cellResult.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        cellResult.BorderWidth = 0;
    //        cellResult.BackgroundColor = Color.YELLOW;

    //        time.AddCell(cellImageTime);
    //        time.AddCell(cellTime);
    //        time.AddCell(cellResult);

    //        if (fim)
    //        {
    //            PdfPCell cellGols = new PdfPCell(new Phrase((timeCasa ? jogo.Jogo.GolsTime1.ToString() : jogo.Jogo.GolsTime2.ToString()),
    //                new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //            cellGols.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellGols.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellGols.BorderWidth = 0;
    //            time.AddCell(cellGols);



    //            PdfPCell cellPontos = new PdfPCell(new Phrase((timeCasa ? jogo.JogoUsuario.Pontos.ToString() : ""),
    //                new Font(Font.HELVETICA, 8f, Font.BOLD, Color.BLACK)));
    //            cellPontos.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cellPontos.VerticalAlignment = Element.ALIGN_MIDDLE;
    //            cellPontos.BorderWidth = 0;

    //            if (jogo.Jogo.PartidaValida)
    //            {
    //                if (jogo.JogoUsuario.Pontos == 0 && timeCasa)
    //                    cellPontos.BackgroundColor = Color.RED;

    //            }
    //            else if (timeCasa)
    //            {
    //                cellPontos.BackgroundColor = Color.YELLOW;
    //            }

    //            time.AddCell(cellPontos);
    //        }

    //        return time;
    //    }
    //    private PdfPTable CreateJogoInEliminatoriaFormat(bool showOnlyPartidaValida, bool fim, Color backColor, bool showTitle, string imagePath, EntityJogoUsuario jogo)
    //    {
    //        PdfPTable jogoTable = new PdfPTable(1);
    //        jogoTable.DefaultCell.Padding = 0;
    //        //jogoTable.DefaultCell.BorderWidth = 0;
    //        jogoTable.DefaultCell.BackgroundColor = backColor;



    //        jogoTable.AddCell(CreateTimeEliminatoriaFormat(showOnlyPartidaValida, fim, showTitle, imagePath, true, jogo));
    //        jogoTable.AddCell(CreateTimeEliminatoriaFormat(showOnlyPartidaValida, fim, showTitle, imagePath, false, jogo));


    //        string dateDescription = jogo.Jogo.DataJogo.ToString("dd/MM - HH:mm") + " - " + jogo.Jogo.NomeEstadio;

    //        //Adicionando o local do jogo
    //        PdfPCell dateJogo = new PdfPCell(new Phrase(dateDescription, new Font(Font.HELVETICA, 5f, Font.NORMAL, Color.BLACK)));
    //        dateJogo.Padding = 0;
    //        dateJogo.BorderWidth = 0;
    //        dateJogo.HorizontalAlignment = Element.ALIGN_CENTER;
    //        dateJogo.VerticalAlignment = Element.ALIGN_MIDDLE;
    //        dateJogo.BackgroundColor = backColor;
    //        dateJogo.PaddingBottom = 2;

    //        //Adicionando o local do jogo na tabela principal
    //        jogoTable.AddCell(dateJogo);



    //        return jogoTable;
    //    }

    //    private PdfPTable CreateOitavasLeft(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true, imagePath, GetJogoByLabel(49, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true, imagePath, GetJogoByLabel(50, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true, imagePath, GetJogoByLabel(53, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true, imagePath, GetJogoByLabel(54, list)));


    //        return fase;
    //    }
    //    private PdfPTable CreateQuartasLeft(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false, imagePath, GetJogoByLabel(57, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, false, imagePath, GetJogoByLabel(58, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");


    //        return fase;
    //    }
    //    private PdfPTable CreateSemiFinaisLeft(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false, imagePath, GetJogoByLabel(61, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");


    //        return fase;
    //    }
    //    private PdfPTable CreateOitavasRight(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true, imagePath, GetJogoByLabel(52, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true, imagePath, GetJogoByLabel(51, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, true, imagePath, GetJogoByLabel(55, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, true, imagePath, GetJogoByLabel(56, list)));


    //        return fase;
    //    }
    //    private PdfPTable CreateQuartasRight(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false, imagePath, GetJogoByLabel(59, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, false, imagePath, GetJogoByLabel(60, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");


    //        return fase;
    //    }
    //    private PdfPTable CreateSemiFinaisRight(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;


    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false, imagePath, GetJogoByLabel(62, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");


    //        return fase;
    //    }
    //    private PdfPTable CreateFinais(bool showOnlyPartidaValida, bool fim, string imagePath, IList<EntityJogoUsuario> list)
    //    {
    //        PdfPTable fase = new PdfPTable(1);
    //        fase.DefaultCell.Padding = 0;
    //        fase.DefaultCell.BorderWidth = 0;

    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");


    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.LIGHT_GRAY, false, imagePath, GetJogoByLabel(64, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        fase.AddCell(CreateJogoInEliminatoriaFormat(showOnlyPartidaValida, fim, Color.WHITE, false, imagePath, GetJogoByLabel(63, list)));
    //        fase.AddCell(" ");
    //        fase.AddCell(" ");

    //        return fase;
    //    }
    //    private EntityJogoUsuario GetJogoByLabel(int jogoId, IList<EntityJogoUsuario> list)
    //    {
    //        for (int c = 0; c < list.Count; c++)
    //        {
    //            //Se encontrou o titulo do jogo
    //            if (list[c].Jogo.JogoId == jogoId)
    //            {
    //                EntityJogoUsuario jogoResult = list[c];
    //                list.RemoveAt(c);
    //                return jogoResult;

    //            }//ednif titulo

    //        }//end for jogo

    //        return new EntityJogoUsuario(new Entities.Campeonatos.Jogo(), new Entities.Boloes.JogoUsuario());
    //    }

    //    public void Close()
    //    {
    //        _outputStream.Close();
    //    }
    //    #endregion

    //}
}
