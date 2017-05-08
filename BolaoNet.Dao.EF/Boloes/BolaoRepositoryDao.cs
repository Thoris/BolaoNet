﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class BolaoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Boloes.Bolao>, Dao.Boloes.IBolaoDao
    {
        
        #region Constructors/Destructors

        public BolaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
