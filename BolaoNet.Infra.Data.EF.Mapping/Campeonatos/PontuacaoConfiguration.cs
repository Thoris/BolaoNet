﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class PontuacaoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.Pontuacao>
    {
        
        #region Constructors/Destructors

        public PontuacaoConfiguration()
        {

            //Property(c => c.)
            //    .HasMaxLength(100);
        }

        #endregion
    }
}
