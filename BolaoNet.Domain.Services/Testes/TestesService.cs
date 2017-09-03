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
        private Interfaces.Services.Notification.INotificationService _notification;

        #endregion

        #region Constructors/Destructors

        public TestesService(string userName, 
            Interfaces.Repositories.Testes.ITesteDao dao, Interfaces.Services.Notification.INotificationService notification)
        {
            _dao = dao;
            _notification = notification;
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
        public bool TestNotifyWelcome(string password, string email)
        {
            if (string.Compare (password, "thoris123") != 0)
            {
                return false;
            }

            _notification.NotifyWelcome(new Entities.Users.User()
                {
                    UserName = "thoris",
                    Email = email,
                    FullName = "Thoris A Pivetta"
                });

            return true;

        }

        #endregion




    }
}
