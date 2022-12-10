using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    class Program
    {
        static void Main(string[] args)
        {

            Execute exe = new Execute();
            //exe.Run("Copa América 2019", true);

            //exe.Run("Copa do Mundo 2018", true);

            //exe.Run("Copa do Mundo 2022", true);
            exe.ReRun("Copa do Mundo 2022");
        }
    }
}
