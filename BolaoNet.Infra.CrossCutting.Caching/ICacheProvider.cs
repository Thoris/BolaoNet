using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.Caching
{
    public interface ICacheProvider
    {
        void Put<T>(string cacheItemName, T objectToCache);
        void Put<T>(string cacheItemName, T objectToCache, double expirationSeconds);
        T Get<T>(string cacheItemName);
        void Remove<T>(string cacheItemName);
    }
}
