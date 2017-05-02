using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Collection
{
    public class FactoryCollection : Dao.IFactoryDao
    {
        public Campeonatos.ICampeonatoDao CreateCampeonatoDao()
        {
            throw new NotImplementedException();
        }
    }
}
