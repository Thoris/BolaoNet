using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo.ReadValidate
{
    public class FileIdReader
    {
        #region Methods

        public IList<ResultadoJogo> ReadIds(string file)
        {
            IList<ResultadoJogo> list = new List<ResultadoJogo>();

            StreamReader reader = new StreamReader(file);

            while (reader.Peek () >= 0)
            {
                string line = reader.ReadLine();

                list.Add(ReadLine(line));
            }

            reader.Close();

            return list;
        }

        public ResultadoJogo ReadLine(string line)
        {
            ResultadoJogo res = new ResultadoJogo();
            //"1	: 61	|	0 [1 x 2]"

            string[] data = line.Split(new char[] { ':', '|', '[', 'x', ']' },  StringSplitOptions.RemoveEmptyEntries);


            int c = 0;
            int index = int.Parse (data[c++].Trim());
            int jogoId = int.Parse(data[c++].Trim());
            int possibilidadeId = int.Parse(data[c++].Trim());
            int gols1 = int.Parse(data[c++].Trim());
            int gols2 = int.Parse(data[c++].Trim());

            res.Gols1 = gols1;
            res.Gols2 = gols2;
            res.JogoId = jogoId;
            res.PossibilidadeId = possibilidadeId;
            res.Index = index;

            return res;
        }

        #endregion
    }
}
