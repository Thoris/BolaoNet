﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoCriterioPontosConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoCriterioPontos>
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosConfiguration()
        {
            ToTable("BoloesCriteriosPontos");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

        }

        #endregion

    }
}
