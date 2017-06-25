using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Helpers.PersistenceProviders
{
    public class PersistenceProvider
    {
        #region Variables

        private Controller _current;

        #endregion

        #region Constructors/Destructors

        public PersistenceProvider(Controller current)
        {
            _current = current;
        }

        #endregion

        public void Put<T>(string itemName, T objectToPersist)
        {
            _current.TempData[itemName] = objectToPersist;
        }

        public void Put<T>(string itemName, T objectToPersist, double expirationSeconds)
        {
            _current.TempData[itemName] = objectToPersist;

            if (expirationSeconds == 0)
                _current.TempData.Keep(itemName);
        }

        public T Get<T>(string itemName)
        {
            T result;

            result = (T)_current.TempData[itemName];

            return result;
        }

        public void Remove<T>(string itemName)
        {
            _current.TempData.Remove(itemName);
        }
    }
}