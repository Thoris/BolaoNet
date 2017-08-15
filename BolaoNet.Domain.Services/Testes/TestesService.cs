using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Testes
{
    public class TestesService 
        : Interfaces.Services.Testes.ITesteService
    {
        #region Variables


        private string _currentUserName;
        private Interfaces.Repositories.Testes.ITesteDao _dao;

        #endregion

        #region Constructors/Destructors

        public TestesService(string userName, 
            Interfaces.Repositories.Testes.ITesteDao dao)
        {
            _dao = dao;
            _currentUserName = userName;
        }

        #endregion

        #region ITesteService members

        public bool TestConnection()
        {
            return _dao.TestConnection();
        }

        public DateTime GetCurrentDateTime()
        {
            return _dao.GetCurrentDateTime();
        }

        #endregion

    }
}
