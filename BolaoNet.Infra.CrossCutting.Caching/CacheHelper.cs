﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.Caching
{
    public class CacheHelper : ICacheProvider
    {
        #region Variables

        private readonly double secondsIn60Days = 60 * 24 * 60 * 60.0;
        private readonly ObjectCache _cache;

        #endregion

        #region Constructors/Destructors
        
        public CacheHelper()
        {
            _cache = MemoryCache.Default;
        }

        #endregion

        #region ICacheProvider members

        public void Put<T>(string cacheItemName, T objectToCache)
        {
            Put<T>(cacheItemName, objectToCache, secondsIn60Days);
        }

        public void Put<T>(string cacheItemName, T objectToCache, double expirationSeconds)
        {
            _cache.Set(cacheItemName, objectToCache, new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expirationSeconds)
            });
        }

        public T Get<T>(string cacheItemName)
        {
            var cachedItem = _cache[cacheItemName];
            if (cachedItem == null)
            {
                return default(T);
            }

            return (T)cachedItem;
        }

        public void Remove<T>(string cacheItemName)
        {
            _cache.Remove(cacheItemName);
        }

        public void Clear()
        {
            
        }

        #endregion



    }
}
