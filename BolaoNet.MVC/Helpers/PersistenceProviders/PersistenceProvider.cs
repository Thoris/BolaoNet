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
        private Infra.CrossCutting.Caching.ICacheProvider _caching;

        #endregion

        #region Constructors/Destructors

        public PersistenceProvider(Controller current)
        {
            _current = current;
            _caching = new Infra.CrossCutting.Caching.CacheHelper();
        }

        #endregion

        public void Put<T>(string itemName, T objectToPersist)
        {
            //_current.TempData[itemName] = objectToPersist;
            //_current.TempData.Keep(itemName);
            _caching.Put<T>(itemName, objectToPersist);
        }

        public void Put<T>(string itemName, T objectToPersist, double expirationSeconds)
        {
            //_current.TempData[itemName] = objectToPersist;

            //if (expirationSeconds == 0)
            //    _current.TempData.Keep(itemName);

            _caching.Put<T>(itemName, objectToPersist);
        }

        public T Get<T>(string itemName)
        {
            //T result;

            //result = (T)_current.TempData[itemName];

            //return result;
            return _caching.Get<T>(itemName);
        }

        public void Remove<T>(string itemName)
        {
            //_current.TempData.Remove(itemName);
            _caching.Remove<T>(itemName);
        }
        public void Clear()
        {
            _caching.Clear();
        }
    }
}