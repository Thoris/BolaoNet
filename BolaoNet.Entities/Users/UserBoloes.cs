using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Users
{
    public class UserBoloes 
    {
        #region Properties
        
        public virtual Campeonatos.Campeonato Campeonato {get;set;}
        public int Position {get;set;} 
        public virtual Boloes.Bolao Bolao {get;set;}
        public int Membros {get;set;}
        public string Cobertura {get;set;}
        public int ApostasRestantes {get;set;}

        #endregion

        #region Constructors/Destructors

        public UserBoloes()
        {

        }

        #endregion
    }
}
