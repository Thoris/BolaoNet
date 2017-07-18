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
    public class PdfBolaoApostasFimReport :
        Domain.Interfaces.Services.Reports.FormatReport.IBolaoApostasFimFormatReportService
    {
        #region Constructors/Destructors

        public PdfBolaoApostasFimReport()
        {

        }

        #endregion

        #region Methods

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

        #region IBolaoApostasFimFormatReportService members

        public Stream Generate(string fileName, string compressedFileName, string extension, string folderProfiles, string folderTimes, Domain.Entities.ValueObjects.Reports.BolaoFinalVO data)
        {
            Document document = new Document(PageSize.A4);

            MemoryStream fs = new MemoryStream();


            PdfWriter writer = PdfWriter.GetInstance(document, fs);


            document.Open();

            for (int c = 0; c < data.Membros.Count; c++)
            {

                document.NewPage();

//                CreatePage(false, false, 0, 0, writer, extension, "", folderProfiles, folderTimes,
//                    new Domain.Entities.Users.User(data.Membros[c].UserName), data.Membros[c].JogosUsuarios, data.Membros[c].ApostasExtras);
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
