//#define WRITE_BINARY
#define COMPRESS_FILE

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    public class FileStructureManager
    {
        #region Constants

        private const string Folder = ".\\Structure";

        #endregion

        #region Constructors/Destructors

        public FileStructureManager()
        {

        }

        #endregion

        #region Methods

        public IList<JogoIdAgrupamento> CheckPossibilidades(string indexFile, string path, List<MembroClassificacao> classificacao, string userName, bool ultimo, params int [] posicoes)
        {
            IList<JogoIdAgrupamento> list = new List<JogoIdAgrupamento>();

            int id = GetIndexUserName(indexFile, userName);

            if (id == -1)
                return null;

#if (COMPRESS_FILE)
            string[] files = System.IO.Directory.GetFiles(path, "*.zip");

#else
            string[] files = System.IO.Directory.GetFiles(path, "*.txt");
#endif
            for (int c = 0; c < files.Length; c++)
            {
                string fullFile = files[c];

                int countUserName = 0;

#if (COMPRESS_FILE)
                FileInfo info = new FileInfo(fullFile);
                string newFile = System.IO.Path.Combine(info.DirectoryName, info.Name.Replace(".zip", ""));
                ExtractZipFile(files[c], null, info.DirectoryName);
                fullFile = newFile;
#endif


#if(WRITE_BINARY)
                FileStream fsReader = new FileStream(fullFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(fsReader);                                          
#else
                StreamReader reader = new StreamReader(fullFile);
#endif


#if(WRITE_BINARY)
                while (reader.PeekChar() >= 0)
#else
                while (reader.Peek() >= 0)
#endif
                {

#if(WRITE_BINARY)
                    string line = "";

                    string x = " ";
                    while (reader.PeekChar() >= 0 && !x.Contains('\n'))
                    {
                        x = reader.ReadString();
                        line += x;
                    }
#else
                    string line = reader.ReadLine();
#endif

                    if (string.IsNullOrEmpty(line))
                        continue;
                     

                    //TODO: Realizar tratamento para análise de jogo


                }//end while 

                //writer.WriteLine();

                reader.Close();
#if(WRITE_BINARY)
                fsReader.Close();
#endif

#if (COMPRESS_FILE)
                System.IO.File.Delete(fullFile);
#endif
            }//end for files
             

            return list;
        }

        public int GetIndexUserName (string indexFile, string userName)
        {
            int res = -1;

            StreamReader reader = new StreamReader(indexFile);

            while(reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrEmpty (line))
                    continue;

                string[] data = line.Split(new char[] { '=' });

                if (string.Compare( data [1], userName, true) == 0)
                {
                    res = int.Parse(data[0]);
                    break;
                }
            }

            reader.Close();

            return res;
        }

        private IList<JogoIdAgrupamento> ReadAgrupamento(string line)
        {
            IList<JogoIdAgrupamento> list = new List<JogoIdAgrupamento>();

            string data = line.Substring(1);

            string[] jogos = data.Split(new char[] { ';' },  StringSplitOptions.RemoveEmptyEntries);

            for (int c=0; c < jogos.Length; c++)
            {
                string[] aposta = jogos[c].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                string[] resultado = aposta[1].Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

                JogoIdAgrupamento id = new JogoIdAgrupamento();
                id.Gols1 = int.Parse(resultado[0]);
                id.Gols2 = int.Parse(resultado[1]);
                id.JogoId = int.Parse(aposta[0]);

                list.Add(id);
            }

            return list;
        }

        public void SaveFile(string file, JogoPossibilidadeAgrupamento entry)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

#if(WRITE_BINARY)
            FileStream fs = new FileStream(file, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
#else
            StreamWriter writer = new StreamWriter(file);
#endif

            writer.Write("*");
            for (int i = 0; entry.Jogos != null && i < entry.Jogos.Count; i++)
            {
                writer.Write(entry.Jogos[i].JogoId + "=" +
                    entry.Jogos[i].Gols1 + "x" + entry.Jogos[i].Gols2);
                 
            }
            writer.Write("\n");

            for (int i = 0; i < entry.Pontuacao.Count; i++)
            {
                //writer.WriteLine("-" + entry.Pontuacao[i].UserName + "=" + entry.Pontuacao[i].Pontos);
                //writer.WriteLine("-" + i + "=" + entry.Pontuacao[i].Pontos);
                writer.Write(entry.Pontuacao[i].Pontos + "\n");
            }


            writer.Close();
            
#if(WRITE_BINARY)
            fs.Close();
#endif

#if (COMPRESS_FILE)

            CompressFile(file, file + ".zip");
            System.IO.File.Delete(file);

#endif


        }

        public void SaveIndex(string file, JogoPossibilidadeAgrupamento entry)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            for (int c=0; c < entry.Pontuacao.Count; c++)
            {
                writer.WriteLine(c + "=" + entry.Pontuacao[c].UserName);
            }

            writer.Close();
        }
        
        public void ReadAppendSave(string file, string folderBase, JogoPossibilidadeAgrupamento entry)
        {

#if (COMPRESS_FILE)
            string[] files = System.IO.Directory.GetFiles(folderBase, "*.zip");

            if (System.IO.File.Exists(file + ".zip"))
                return;
#else
            string[] files = System.IO.Directory.GetFiles(folderBase, "*.txt");
#endif
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

#if(WRITE_BINARY)
            FileStream fsWriter = new FileStream(file, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fsWriter);
#else
            StreamWriter writer = new StreamWriter(file);
#endif

            for (int c = 0; c < files.Length; c++ )
            {
                string fullFile = files[c];

                int countUserName = 0;

#if (COMPRESS_FILE)
                FileInfo info = new FileInfo(fullFile);
                string newFile = System.IO.Path.Combine(info.DirectoryName, info.Name.Replace(".zip", ""));
                ExtractZipFile(files[c], null, info.DirectoryName);
                fullFile = newFile;
#endif


#if(WRITE_BINARY)
                FileStream fsReader = new FileStream(fullFile, FileMode.Open);
                BinaryReader reader = new BinaryReader(fsReader);                                          
#else
                StreamReader reader = new StreamReader(fullFile);                                   
#endif


#if(WRITE_BINARY)
                while (reader.PeekChar() >= 0)
#else
                while (reader.Peek() >= 0)
#endif
                {

#if(WRITE_BINARY)
                    string line = "";

                    string x = " ";
                    while (reader.PeekChar() >= 0 && !x.Contains('\n'))
                    {
                        x = reader.ReadString();
                        line += x;
                    }
#else
                    string line = reader.ReadLine();
#endif

                    if (string.IsNullOrEmpty(line))
                        continue;

                    //Se é o jogo
                    if (line.StartsWith("*"))
                    {
                        writer.Write(line);
                        writer.Write(";" + entry.JogoId + "=" + entry.GolsTime1 + "x" + entry.GolsTime2 + "\n");
                        countUserName = 0;

                    }
                    //Se é pontuação
                    else // if (line.StartsWith("-"))
                    {
                        //string[] data = line.Split(new char[] { '=' });

                        //int pontos = int.Parse (data[1]);
                        int pontos = int.Parse(line);
                        
                        int pontosUserName = entry.Pontuacao[countUserName].Pontos;
                        countUserName++;

                        int total =  pontos + pontosUserName;

                        //writer.WriteLine(data[0] + "=" + total);
                        writer.Write(total + "\n");
                        
                    }

                }//end while 

                //writer.WriteLine();

                reader.Close();
#if(WRITE_BINARY)
                fsReader.Close();
#endif

#if (COMPRESS_FILE)
                System.IO.File.Delete(fullFile);
#endif
            }//end for files


            writer.Close();

#if (COMPRESS_FILE)
            CompressFile(file, file + ".zip");
            System.IO.File.Delete(file);
#endif


#if(WRITE_BINARY)
            fsWriter.Close();
#endif
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

        private void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;		// AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;			// Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];		// 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }
         
        #endregion
    }
}
