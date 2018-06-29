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


        public void SaveJogoPossibilidades(string file, JogoInfo info)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            for (int c=0; c < info.Possibilidades.Count; c++)
            {
                writer.WriteLine(info.JogoId + "=" + info.Possibilidades[c].GolsTime1 + "x" + info.Possibilidades[c].GolsTime2);

                for (int i = 0; i < info.Possibilidades[c].Pontuacao.Count; i++)
                {
                    writer.WriteLine(info.Possibilidades[c].Pontuacao[i].Pontos);
                }
            }

            writer.Close();
        }

        public IList<ExtraJogoTime> GetPossibilidadeTimes(List<ApostaExtraInfo> extras, List<JogoInfo> jogos)
        {
            IList<ExtraJogoTime> res = new List<ExtraJogoTime>();
            IList<string> times = new List<string>();

            for (int c=0; c < extras.Count; c++)
            {
                for (int i = 0; i < extras[c].Possibilidades.Count; i++)
                {
                    string time = extras[c].Possibilidades[i].NomeTime;

                    if (!times.Contains(time))
                        times.Add(time);
                }
            }

            for (int c = 0; c < times.Count; c++ )
            {
                IList<ExtraJogoTime> temp = GetPossibilidadeTimes(extras, jogos, times[c]);

                for (int i = 0; i < temp.Count; i++)
                {
                    res.Add(temp[i]);
                }      
            }

            for (int c = 0; c < extras.Count; c++ )
            {
                for (int i = 0; i < extras[c].Possibilidades.Count; i++)
                {
                    bool found = false;

                    for (int x =0; x < res.Count; x++)
                    {
                        if (string.Compare(extras[c].Possibilidades[i].NomeTime, res[x].NomeTime, true) == 0 && 
                            extras[c].Posicao == res[x].Posicao)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        extras[c].Possibilidades.RemoveAt(i);
                        i--;
                    }
                }
            }


            return res;
        }

        public IList<ExtraJogoTime> GetPossibilidadeTimes(List<ApostaExtraInfo> extras, List<JogoInfo> jogos, string nomeTime)
        {


            IList<ExtraJogoTime> res = new List<ExtraJogoTime>();
            
            int idFinal = 64;
            int idTerceiro = 63;
            int id;
            //61[Brasil|Argentina]57|True|58|True
            //62[Alemanha|Espanha]59|True|60|True
            //63[-|-]61|False|62|False
            //64[-|-]61|True|62|True


            //Final - Time 1
            if (!string.IsNullOrEmpty(jogos[idFinal - 1].NomeTime1))
            {
                if (string.Compare(jogos[idFinal - 1].NomeTime1, nomeTime, true) == 0)
                {
                    #region Final
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);
                    #endregion
                }
            }
            else
            {
                id = 61;
                if (string.Compare(jogos[id-1].NomeTime1, nomeTime, true) == 0)
                {
                    #region Campeão e Vice
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });                    
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    //----------------------------------
                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    #endregion

                    #region Terceiro e Quarto
                    
                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);



                    //----------------------------------

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao =3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    #endregion
                }

                if (string.Compare(jogos[id - 1].NomeTime2, nomeTime, true) == 0)
                {
                    #region Campeão e Vice
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    //----------------------------------
                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    #endregion

                    #region Terceiro e Quarto

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);



                    //----------------------------------

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    #endregion
                }
            }




            //Final - Time 2
            if (!string.IsNullOrEmpty(jogos[idFinal - 1].NomeTime2))
            {
                if (string.Compare(jogos[idFinal - 1].NomeTime2, nomeTime, true) == 0)
                {
                    #region Final
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);
                    #endregion
                }
            }
            else
            {
                id = 62;
                if (string.Compare(jogos[id - 1].NomeTime1, nomeTime, true) == 0)
                {
                    #region Campeão e Vice
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    //----------------------------------
                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    #endregion

                    #region Terceiro e Quarto

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);



                    //----------------------------------

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    #endregion
                }

                if (string.Compare(jogos[id - 1].NomeTime2, nomeTime, true) == 0)
                {
                    #region Campeão e Vice
                    ExtraJogoTime entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime2 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    //----------------------------------
                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 1;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 2;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idFinal });
                    res.Add(entry);

                    #endregion

                    #region Terceiro e Quarto

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id, GanhadorTime1 = true });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);



                    //----------------------------------

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime2 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 3;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro, GanhadorTime1 = true });
                    res.Add(entry);

                    entry = new ExtraJogoTime();
                    entry.Posicao = 4;
                    entry.NomeTime = nomeTime;
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = id });
                    entry.Possibilidades.Add(new ExtraJogoTimePossibilidade() { JogoId = idTerceiro });
                    res.Add(entry);

                    #endregion
                }
            }

            res = res.OrderBy(x => x.Posicao).ToList();



            return res;
        }
         
        public List<ApostaPontos> CalculoJogoMultiplo(List<ApostaPontos> membros, List<JogoInfo> list, List<CriterioPontosTimes> criterioTimes, JogoPossibilidadeAgrupamento jogos, List<string> extras)
        { 
            List<ApostaPontos> pontos = new List<ApostaPontos>();

            List<JogoInfo> jogosSimulacao = new List<JogoInfo>();

            for (int c = 0; c < membros.Count; c++ )
            {
                ApostaPontos pt = membros[c].Clone();
                pt.Pontos = 0;
                pontos.Add(pt);
            }
             

            List<JogoInfo> listJogos = new List<JogoInfo>();

            //Calculo apenas a partir da semifinal
            for (int c = 0; c < 4; c ++ )
            {
                listJogos.Add(list[list.Count - 1 - c].Clone());
            }

            for (int c = 0; c < jogos.Jogos.Count; c++ )
            {
                for (int i = 0; i < listJogos.Count; i ++)
                {
                    if (jogos.Jogos[c].JogoId == listJogos[i].JogoId)
                    {
                        listJogos[i].GolsTime1 = jogos.Jogos[c].Gols1;
                        listJogos[i].GolsTime2 = jogos.Jogos[c].Gols2;
                        jogosSimulacao.Add(listJogos[i]);
                         
                        break;
                    }
                }
            }

            ApplyNomeTime(listJogos, extras[0], 64, true);
            ApplyNomeTime(listJogos, extras[1], 64, false);
            ApplyNomeTime(listJogos, extras[2], 63, true);
            ApplyNomeTime(listJogos, extras[3], 63, false);

            return pontos;
        }


        private List<string> ApplyNomeTime(List<JogoInfo> list, string nomeTime, int jogoId, bool ganhador)
        {
            List<string> res = new List<string>();

            for (int c = 0; c < list.Count; c++)
            {
                if (jogoId == list[c].JogoId)
                {
                    if (list[c].IsValid)
                        break;

                    if (ganhador)
                    {
                        if (list[c].GolsTime1 > list[c].GolsTime2)
                        {
                            if (string.IsNullOrEmpty(list[c].NomeTime1))
                            {
                                list[c].NomeTime1 = nomeTime;
                                res.AddRange(ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime1, list[c].PendenteTime1Ganhador));
                            }
                        }
                        else if (list[c].GolsTime1 < list[c].GolsTime2)
                        {
                            if (string.IsNullOrEmpty(list[c].NomeTime2))
                            {
                                list[c].NomeTime2 = nomeTime;
                                res.AddRange(ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime2, list[c].PendenteTime2Ganhador));
                            }
                        }
                    }
                    else
                    {
                        if (list[c].GolsTime1 < list[c].GolsTime2)
                        {
                            if (string.IsNullOrEmpty(list[c].NomeTime1))
                            {
                                list[c].NomeTime1 = nomeTime;
                                res.AddRange(ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime1, list[c].PendenteTime1Ganhador));
                            }
                        }
                        else if (list[c].GolsTime1 > list[c].GolsTime2)
                        {
                            if (string.IsNullOrEmpty(list[c].NomeTime2))
                            {
                                list[c].NomeTime2 = nomeTime;
                                res.AddRange(ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime2, list[c].PendenteTime2Ganhador));
                            }
                        }
                    }

                    if (list[c].GolsTime1 == list[c].GolsTime2)
                    {
                        if (!string.IsNullOrEmpty(list[c].NomeTime1))
                            res.Add(list[c].NomeTime1);
                        if (!string.IsNullOrEmpty(list[c].NomeTime2))
                            res.Add(list[c].NomeTime2);

                       
                        List<string> temp1 = ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime1, list[c].PendenteTime1Ganhador);
                        if (string.IsNullOrEmpty(list[c].NomeTime1))
                        {
                            for (int i = 0; i < temp1.Count; i++)
                            {
                                if (string.Compare(temp1[i], nomeTime, true) == 0)
                                {
                                    list[c].NomeTime1 = nomeTime;
                                    return new List<string>();
                                }
                            }
                        }

                        List<string> temp2 = ApplyNomeTime(list, nomeTime, list[c].PendenteIdTime2, list[c].PendenteTime2Ganhador);
                        if (string.IsNullOrEmpty(list[c].NomeTime1))
                        {
                            for (int i = 0; i < temp2.Count; i++)
                            {
                                if (string.Compare(temp2[i], nomeTime, true) == 0)
                                {
                                    list[c].NomeTime2 = nomeTime;
                                    return new List<string>();
                                }
                            }
                        }
                    }

                    break;
                }
            }

            return res;
        }

        private List<string> GetTimePontosExtras(List<JogoInfo> jogos, JogoPossibilidadeAgrupamento jogo, int jogoId, bool ganhador)
        {
             List<string> res = new List<string>();

            int index = -1;
            for (int c = 0; c < jogos.Count; c++ )
            {
                if (jogos[c].JogoId == jogoId)
                {
                    index = c;
                    break;
                }
            }

            if (index == -1)
                return null;

            List<string> listTime1 = new List<string>();
            List<string> listTime2 = new List<string>();

            #region Time 1
            //Se não existe nenhum time na posição 1
            if (string.IsNullOrEmpty(jogos[index].NomeTime1))
            {
                #region Não encontrou o Time - Busca por recursividade

                int idTime1 = jogos[index].PendenteIdTime1;
                bool ganhadorTime1 = jogos[index].PendenteTime1Ganhador;

                //Busca-se a dependência do jogo
                List<string> temp = GetTimePontosExtras(jogos, jogo, idTime1, ganhadorTime1);

                if (temp == null)
                    return res;
                else
                {                    
                    for (int c=0; c < temp.Count; c++)
                    {
                        //res.AddRange(temp);
                        //res.Add(temp[c]);
                        listTime1.Add(temp[c]);
                    }
                }
                #endregion
            }
            else
            {
                #region Encontrou o time
                listTime1.Add(jogos[index].NomeTime1);

                //int gols1 = 0;
                //int gols2 = 0;

                //for (int c = 0; c < jogo.Jogos.Count; c++)
                //{
                //    if (jogo.Jogos[c].JogoId == jogoId)
                //    {
                //        gols1 = jogo.Jogos[c].Gols1;
                //        gols2 = jogo.Jogos[c].Gols2;
                //        break;
                //    }
                //}

                //if (ganhador)
                //{
                //    if (gols1 > gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //    }
                //    else if (gols1 == gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //    else
                //    {
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //}
                //else
                //{
                //    if (gols1 < gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //    }
                //    else if (gols1 == gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //    else
                //    {
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //}

                #endregion
            }
            #endregion

            #region Time 2
            //Se não existe nenhum time na posição 1
            if (string.IsNullOrEmpty(jogos[index].NomeTime2))
            {
                #region Não encontrou o Time - Busca por recursividade

                int idTime2 = jogos[index].PendenteIdTime2;
                bool ganhadorTime2 = jogos[index].PendenteTime2Ganhador;

                //Busca-se a dependência do jogo
                List<string> temp = GetTimePontosExtras(jogos, jogo, idTime2, ganhadorTime2);

                if (temp == null)
                    return res;
                else
                {
                    for (int c = 0; c < temp.Count; c++)
                    {
                        //res.AddRange(temp);
                        //res.Add(temp[c]);
                        listTime2.Add(temp[c]);
                    }
                }
                #endregion
            }
            else
            {
                #region Encontrou o time

                listTime2.Add(jogos[index].NomeTime2);
                //int gols1 = 0;
                //int gols2 = 0;

                //for (int c = 0; c < jogo.Jogos.Count; c++)
                //{
                //    if (jogo.Jogos[c].JogoId == jogoId)
                //    {
                //        gols1 = jogo.Jogos[c].Gols1;
                //        gols2 = jogo.Jogos[c].Gols2;
                //        break;
                //    }
                //}

                //if (ganhador)
                //{
                //    if (gols1 < gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //    }
                //    else if (gols1 == gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //    else
                //    {
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //}
                //else
                //{
                //    if (gols1 > gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //    }
                //    else if (gols1 == gols2)
                //    {
                //        res.Add(jogos[index].NomeTime1);
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //    else
                //    {
                //        res.Add(jogos[index].NomeTime2);
                //    }
                //}

                #endregion
            }
            #endregion

            #region Verificação do jogo

            int gols1 = 0;
            int gols2 = 0;

            for (int c = 0; c < jogo.Jogos.Count; c++)
            {
                if (jogo.Jogos[c].JogoId == jogoId)
                {
                    gols1 = jogo.Jogos[c].Gols1;
                    gols2 = jogo.Jogos[c].Gols2;
                    break;
                }
            }

            if (ganhador)
            {
                if (gols1 > gols2)
                {
                    res.AddRange(listTime1);
                } 
                else if (gols1 < gols2)
                {
                    res.AddRange(listTime2);
                }
                else if (gols1 == gols2)
                {
                    res.AddRange(listTime1);
                    res.AddRange(listTime2);
                }
            }
            else
            {
                if (gols1 < gols2)
                {
                    res.AddRange(listTime1);
                } 
                else if (gols1 > gols2)
                {
                    res.AddRange(listTime2);
                }
                else if (gols1 == gols2)
                {
                    res.AddRange(listTime1);
                    res.AddRange(listTime2);
                }
            } 
            #endregion

            return res;

        }
        
        private Dictionary<int, List<string>> GetPontosExtras(List<ApostaPontos> membros, List<JogoInfo> jogos, JogoPossibilidadeAgrupamento jogo, IList<ExtraJogoTime> extrasCheck, List<ApostaExtraInfo> extras, out Dictionary<int, int> posicoesExtrasFound)
        {
            posicoesExtrasFound = new Dictionary<int, int>();
            //List<ApostaPontos> res = new List<ApostaPontos>();


            List<JogoInfo> tempJogos = new List<JogoInfo>();

            //for (int c = 0; c < jogo.Jogos.Count; c++)
            for (int c = 0; c < 16; c++)
            {
                tempJogos.Add(jogos[64-c-1].Clone());
            }

            List<string> primeiro = GetTimePontosExtras(tempJogos, jogo, 64, true);
            List<string> segundo = GetTimePontosExtras(tempJogos, jogo, 64, false);
            List<string> terceiro = GetTimePontosExtras(tempJogos, jogo, 63, true);
            List<string> quarto = GetTimePontosExtras(tempJogos, jogo, 63, false);


            Dictionary<int, List<string>> res = new Dictionary<int, List<string>>();
            res.Add(1, primeiro);
            res.Add(2, segundo);
            res.Add(3, terceiro);
            res.Add(4, quarto);

            return res;
        }

        private List<List<string>> GetPossibilidades(Dictionary<int, List<string>> input)
        {
            List<List<string>> output = new List<List<string>>();
            //List<int> posicoes = new List<int>();

            //List<List<string>> possibilidades = new List<List<string>>();


            bool duplicacao = false;

            #region Simulação 1

            //List<string> o = new List<string>();
            //if (o.Contains(input[1][0]))
            //{
            //    o.Add(input[1][1]);
            //}
            //else
            //{
            //    o.Add(input[1][0]);
            //}
            //if (o.Contains(input[2][0]))
            //{
            //    o.Add(input[2][1]);
            //}
            //else
            //{
            //    o.Add(input[2][0]);
            //}
            //if (o.Contains(input[3][0]))
            //{
            //    o.Add(input[3][1]);
            //}
            //else
            //{
            //    o.Add(input[3][0]);
            //}
            //if (o.Contains(input[4][0]))
            //{
            //    o.Add(input[4][1]);
            //}
            //else
            //{
            //    o.Add(input[4][0]);
            //}
            //output.Add(o);

            #endregion



            //TODO: CALCULO DE POSICOES
            for(int c=0; c < 4; c++)
            {

            }




            List<string> current = new List<string>();
            for (int c = 1; c <= 4; c++)
            {
                if (current.Contains(input[c][0]))
                    current.Add(input[c][1]);
                else
                    current.Add(input[c][0]);
            }
            output.Add(current);


            current = new List<string>();
            for (int c = 1; c <= 4; c++)
            {
                if (input[c].Count > 1)
                {
                    if (current.Contains(input[c][1]))
                        current.Add(input[c][0]);
                    else
                        current.Add(input[c][1]);
                }
                else
                {
                    if (current.Contains(input[c][0]))
                        current.Add(input[c][1]);
                    else
                        current.Add(input[c][0]);
                }
            }
            output.Add(current);


            #region Comments

            //List<int> ContadorPosicao = new List<int>();
            //for (int c = 0; c < 4; c++)
            //    ContadorPosicao.Add(-1);

            //List<string> timesValidacao = new List<string>();
            //List<string> current = new List<string>();

            //int count = 0;
            //int found = -1;
            //do
            //{
            //    count = 0;
            //    foreach (KeyValuePair<int, List<string>> entry in input)
            //    {
            //        if (entry.Value.Count > 1 && found < count)
            //        {
            //            found = count;
            //        }


            //        if (!current.Contains(entry.Value[0]))
            //        {
            //            current.Add(entry.Value[0]);
            //        }
            //        else
            //        {
            //            bool f = false;
            //            for (int c = 0; c < entry.Value.Count; c++)
            //            {
            //                if (!current.Contains(entry.Value[c]))
            //                {
            //                    current.Add(entry.Value[c]);
            //                    f = true;
            //                    break;
            //                }
            //            }
            //            if (!f)
            //                current.Add("");
            //        }

            //        count++;
            //    }
            //}
            //while (found >= 0 && count < 4);

            #endregion

            return output;
        }

        private List<ApostaPontos> GetPontuacao(List<ApostaPontos> classificacao, List<string> posicoes, List<ApostaExtraInfo> extras)
        {
            List<ApostaPontos> pontos = classificacao.ToList();

            for (int c=0; c < pontos.Count; c++)
            {
                pontos[c].Pontos = 0;
            }

            for (int c=0; c < posicoes.Count; c++)
            {
                for (int i = 0; i < extras[c].Possibilidades.Count; i++)
                {
                    if (string.Compare ( extras[c].Possibilidades[i].NomeTime, posicoes[c], true) == 0)
                    {

                        for (int l = 0; l < extras[c].Possibilidades[i].Pontos.Count;l++ )
                        {
                            pontos[l].Pontos += extras[c].Possibilidades[i].Pontos[l].Pontos;
                        }
                        break;
                    }
                }
            }

            return pontos;

        }

        private bool CheckUsuarioPontuacao(string outputFile, JogoPossibilidadeAgrupamento jogo, List<MembroClassificacao> classificacao, string userName, IList<ExtraJogoTime> extrasCheck, List<ApostaExtraInfo> extras, List<JogoInfo> jogos, bool ultimo, params int[] posicao)
        { 
            Dictionary<int, int> posicoesExtrasFound = null;
            //List<ApostaExtraInfo> info = extras.ToList();

            IList<string> times = new List<string>();


            Dictionary<int, List<string>> temp = GetPontosExtras(jogo.Pontuacao, jogos, jogo, extrasCheck, extras, out posicoesExtrasFound);
            List<List<string>> extrasPosicoes = GetPossibilidades(temp);

            //List<ApostaPontos> extraList = GetPontosExtras(jogo.Pontuacao, jogos, jogo, extrasCheck, extras, out posicoesExtrasFound);

            int jogoIndex = jogos.Count -1; 
            string time1 = jogos[jogoIndex].NomeTime1;
            string time2 = jogos[jogoIndex].NomeTime2;

 
            #region Atribuição de pontos

            List<ApostaPontos> listSoma = jogo.Pontuacao;
            int posFound = 0;

            for (int c=0; c < classificacao.Count; c++)
            {
                listSoma[c].Pontos += classificacao[c].Pontuacao ?? 0;
            }

            #endregion

            for (int y = 0; y < extrasPosicoes.Count; y++)
            {
                //Console.WriteLine(DateTime.Now.ToString() + " - " + "\t\t\t\t[" + (y + 1) + "/" + extrasPosicoes.Count + "]");

                List<ApostaPontos> listExtra = listSoma.ToList();
                for (int i = 0; i < extrasPosicoes[y].Count; i++)
                {
                    listExtra[i].Pontos = listExtra[y].Pontos;
                }

                List<ApostaPontos> tempApostas = CalculoJogoMultiplo(listExtra, jogos, null, jogo, extrasPosicoes[y]);



                List<ApostaPontos> list = listExtra.OrderByDescending(x => x.Pontos).ToList<ApostaPontos>();

                #region Calculando posições

                int currentPosicao = 0;
                int currentPontos = -1;

                for (int c = 0; c < list.Count; c++)
                {
                    if (list[c].Pontos != currentPontos)
                    {
                        currentPosicao++;
                        list[c].Posicao = currentPosicao;
                        currentPontos = list[c].Pontos;
                    }
                    else
                    {
                        list[c].Posicao = currentPosicao;
                    }
                }
                #endregion

                bool found = false;

                #region Verificação do último
                if (ultimo)
                {
                    currentPontos = list[list.Count - 1].Pontos;
                    currentPosicao = list[list.Count - 1].Posicao;
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (list[i].Posicao != currentPosicao)
                            break;

                        if (string.Compare(list[i].UserName, userName, true) == 0)
                        {
                            found = true;
                            posFound = list[i].Posicao;
                            break;
                        }
                    }
                }
                #endregion

                #region Verificação das primeiras posições

                if (!found)
                {

                    for (int i = 0; i < list.Count; i++)
                    {
                        bool exists = false;
                        for (int c = 0; c < posicao.Length; c++)
                        {
                            if (list[i].Posicao == posicao[c])
                                exists = true;
                        }
                        if (!exists)
                            break;

                        if (string.Compare(list[i].UserName, userName, true) == 0)
                        {
                            found = true;
                            posFound = list[i].Posicao;
                            break;
                        }
                    }
                }

                #endregion

                if (found)
                {
                    SaveUsuarioPontuacao(outputFile, jogo, list, currentPosicao, extrasCheck, extrasPosicoes[y], ultimo, posicao);
                }
            }

            return true;
        }
        
        private void SaveUsuarioPontuacao(string file, JogoPossibilidadeAgrupamento jogo, List<ApostaPontos> list, int currentPosicao, IList<ExtraJogoTime> extrasCheck, List<string> posicoesExtrasFound, bool ultimo, params int[] posicao)
        {
            StreamWriter writer = null;

            if (System.IO.File.Exists(file))
                writer = new StreamWriter(file, true);
            else
                writer = new StreamWriter(file);

            writer.Write("*");
            for (int c = 0; c < jogo.Jogos.Count; c++)
            {
                if (c > 0)
                    writer.Write(";");
                writer.Write(jogo.Jogos[c].JogoId + "=" + jogo.Jogos[c].Gols1 + "x" + jogo.Jogos[c].Gols2);
            }

            writer.Write(" |");
            for (int c = 0; c < posicoesExtrasFound.Count; c++ )
            {
                writer.Write(" " + (c + 1) + " : " + posicoesExtrasFound[c] + " |");
            }

                //writer.Write(" |");
                //foreach (KeyValuePair<int, int> entry in posicoesExtrasFound)
                //{
                //    writer.Write(" " + extrasCheck[entry.Value].Posicao + " : " + extrasCheck[entry.Value].NomeTime + " |");
                //}


                writer.WriteLine();

            for (int c = 0; c < list.Count; c++)
            {
                bool found = false;
                for (int i = 0; i < posicao.Length; i++)
                {
                    if (list[c].Posicao == posicao[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    break;

                writer.WriteLine(list[c].Posicao + "|" + list[c].UserName + "=" + list[c].Pontos);
            }

            if (ultimo)
            {

                int pos = list[list.Count - 1].Posicao;
                for (int c = list.Count - 1; c >= 0; c--)
                {
                    if (pos != list[c].Posicao)
                        break;

                    writer.WriteLine(list[c].Posicao + "|" + list[c].UserName + "=" + list[c].Pontos);
                }
            }

            writer.Close();
        }
        
        public IList<JogoIdAgrupamento> CheckPossibilidades(string outputFile, string indexFile, string path, List<MembroClassificacao> classificacao, string userName,List<ApostaExtraInfo> extras, List<JogoInfo> jogos, IList<ExtraJogoTime> extrasCheck, bool ultimo, params int [] posicoes)
        {
            IList<JogoIdAgrupamento> list = new List<JogoIdAgrupamento>();

            int id = GetIndexUserName(indexFile, userName);

            if (id == -1)
                return null;

            IList<string> indexList = LoadIndexFile(indexFile);


#if (COMPRESS_FILE)
            string[] files = System.IO.Directory.GetFiles(path, "*.zip");

#else
            string[] files = System.IO.Directory.GetFiles(path, "*.txt");
#endif
            for (int c = 0; c < files.Length; c++)
            {
                string fullFile = files[c];

                Console.WriteLine(DateTime.Now.ToString() + " - \t\t[" +  + (c+1) + " / " + files.Length + "]"); 

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

                JogoPossibilidadeAgrupamento jogoCurrent = null;

                int currentIdUser = 0;
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
                     
                    if (line.StartsWith("*"))
                    {
                        if (jogoCurrent != null)
                        {
                            //Console.WriteLine(DateTime.Now.ToString() + " - " + "\t\t\t\t[" + jogoCurrent.Jogos[0].Gols1 + "x" + jogoCurrent.Jogos[0].Gols2 + "]");

                            CheckUsuarioPontuacao(outputFile, jogoCurrent, classificacao, userName, extrasCheck, extras, jogos, ultimo, posicoes);                            
                        }

                        jogoCurrent = new JogoPossibilidadeAgrupamento();
                        jogoCurrent.Jogos = ReadAgrupamento(line);

                        currentIdUser = 0;
                    }
                    else
                    {

                        int idUser = currentIdUser++;
                        int pt = int.Parse (line);
                        jogoCurrent.Pontuacao.Add(new ApostaPontos()
                        {
                            UserName = indexList[idUser],
                            Pontos = pt
                        });
                    }

                }//end while 

                if (jogoCurrent != null)
                {
                    CheckUsuarioPontuacao(outputFile, jogoCurrent, classificacao, userName, extrasCheck, extras, jogos, ultimo, posicoes);                     
                }

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
        
        public IList<string> LoadIndexFile(string indexFile)
        {
            IList<string> list = new List<string>();
            StreamReader reader = new StreamReader(indexFile);

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] info = line.Split(new char[] { '=' });
                list.Add(info[1]);
            }

            reader.Close();
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

        public void UpdateClassificacao(string file, List<MembroClassificacao> membros)
        {
            if (!System.IO.File.Exists(file))
                return;

            for (int c=0; c < membros.Count; c++)
            {
                membros[c].Posicao = 0;
                membros[c].Pontuacao = 0;
            }

            StreamReader reader = new StreamReader(file);

            while (reader.Peek()>=0)
            {
                string line = reader.ReadLine();

                string[] data = line.Split(new char[] { '=' });

                string userName = data[0];
                int pontos = int.Parse(data[1]);

                for (int c=0; c < membros.Count; c++)
                {
                    if(string.Compare (membros[c].UserName, userName, true) == 0)
                    {
                        membros[c].Pontuacao = pontos;
                        break;
                    }
                }
            }

            reader.Close();
                
        }

        public void SaveClassificacao(string file, List<MembroClassificacao> membros)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            for (int c=0; c < membros.Count; c++)
            {
                writer.WriteLine(membros[c].UserName + "=" + membros[c].Pontuacao);
            }

            writer.Close();
        }

        public bool LoadTimeJogo(string file, int jogoId, out string nomeTime1, out string nomeTime2)
        {
            nomeTime1 = "";
            nomeTime2 = "";
            bool found = false;

            StreamReader reader = new StreamReader(file);

            while (reader.Peek () >= 0)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] info = line.Split(new char[] { '[', '|', ']' });

                int id = int.Parse (info[0]);

                if (jogoId == id)
                {
                    nomeTime1 = info[1];
                    nomeTime2 = info[2];
                    found = true;
                    break;
                }
                //"1[Rússia|Arábia Saudita]0|False|0|False"
            }

            reader.Close();

            return found;
        }

        public void SaveTimesJogos(string file, IList<JogoInfo> list)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            for (int c = 0; c < list.Count; c++ )
            {
                writer.Write(list[c].JogoId);
                writer.Write("[");
                if (string.IsNullOrEmpty(list[c].NomeTime1))
                    writer.Write("-");
                else
                    writer.Write(list[c].NomeTime1);

                writer.Write("|");
                if (string.IsNullOrEmpty(list[c].NomeTime2))
                    writer.Write("-");
                else
                    writer.Write(list[c].NomeTime2);

                writer.Write("]");

                writer.WriteLine(list[c].PendenteIdTime1 + "|" + list[c].PendenteTime1Ganhador + "|" +
                    list[c].PendenteIdTime2 + "|" + list[c].PendenteTime2Ganhador);
            }

            writer.Close();
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
        
        public void SaveApostasExtras(string path, List<ApostaExtraInfo> list)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);



            
            for (int c=0; c < list.Count; c++)
            {

                string file = System.IO.Path.Combine(path, list[c].Posicao+ ".txt");
                
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);

                StreamWriter writer = new StreamWriter(file);

                for (int i = 0; i < list[c].Possibilidades.Count; i++ )
                {
                    writer.WriteLine("*" + list[c].Possibilidades[i].NomeTime);

                    for (int x = 0; x < list[c].Possibilidades[i].Pontos.Count; x++)
                    {
                        writer.WriteLine(list[c].Possibilidades[i].Pontos[x].Pontos);
                    }
                }

                writer.Close();

            }//end for posições

            
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

                Console.WriteLine(DateTime.Now.ToString() +"\t\t\t[" + (c + 1) + " / " + files.Length + "]");
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

        public void SaveApostasExtrasPossibilidade(string file, int posicao, string nomeTime, ApostaExtraPossibilidade list)
        {
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("*" + posicao + "=" + nomeTime);
            
            for (int c = 0; c < list.Pontos.Count; c++ )
            {
                writer.WriteLine(list.Pontos[c].Pontos);
            }

            writer.Close();
        }

        public void SaveApostasExtrasPossibilidade(string baseFolder, string file, int posicao, string nomeTime, ApostaExtraPossibilidade entry)
        {
            string[] files = System.IO.Directory.GetFiles(baseFolder);

            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            StreamWriter writer = new StreamWriter(file);

            for (int c = 0; c < files.Length; c++ )
            {
                string fileBase = files[c];

                StreamReader reader = new StreamReader(fileBase);
                bool ignore = false;
                int currentId = 0;
                while(reader.Peek () >= 0)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (line.StartsWith("*"))
                    {
                        if (string.Compare(Execute.NomeTimeDesconhecido, nomeTime,true) != 0 && line.Contains(nomeTime))
                        {
                            ignore = true;
                        }
                        else
                        {
                            ignore = false;
                            currentId = 0;
                            writer.WriteLine(line + ";" + posicao + "=" + nomeTime);
                        }

                    }
                    else
                    {
                        if (ignore)
                            continue;

                        int pontos = int.Parse(line);
                        int total = entry.Pontos[currentId].Pontos + pontos;
                        currentId++;

                        writer.WriteLine(total);
                    }

                }//end while

                reader.Close();

            }//end for c


            writer.Close();

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
