﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>   
    {
        
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioConfiguration()
        {
            ToTable("BoloesCampeonatosClassificacaoUsuarios");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(Campeonatos.CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeFase)
                .HasMaxLength(Campeonatos.CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(Campeonatos.CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(DadosBasicos.TimeConfiguration.NomeLen);

            Property(c => c.UserName)
                .HasMaxLength(Users.UserConfiguration.NomeLen);

        }

        #endregion
    }
}
