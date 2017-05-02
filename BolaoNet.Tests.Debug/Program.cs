using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Dao.EF.UnitOfWork uow = new Dao.EF.UnitOfWork();

            Dao.EF.Campeonatos.CampeonatoRepositoryDao dao = new Dao.EF.Campeonatos.CampeonatoRepositoryDao(uow);
            dao.Load(new Entities.Campeonatos.Campeonato());

        }
    }
}
