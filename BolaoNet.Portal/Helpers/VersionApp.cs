using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BolaoNet.Portal.Helpers
{
    /// <summary>
    /// Classe que trabalha com o gerenciamento de versões.
    /// </summary>
    public class VersionApp
    {
        #region Methods

        /// <summary>
        /// Retorna a versão corrente obtido no arquivo AssemblyInfo.cs.
        /// </summary>
        public static string CurrentVersion()
        {
            try
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return version.ToString();
            }
            catch
            {
                return "?.?.?.?";
            }
        }

        /// <summary>
        /// Método que retorna a data da versão corrente.
        /// </summary>
        /// <returns>String que possui a data da versão.</returns>
        public static string CurrentVersionDate()
        {
            var entryAssembly = Assembly.GetExecutingAssembly();
            var fileInfo = new FileInfo(entryAssembly.Location);
            var buildDate = fileInfo.LastWriteTime;


            return buildDate.ToString("dd/MM/yyyy");
            //try
            //{
            //    if (_CachedCurrentVersionDate == null)
            //    {
            //        // Ignores concurrency issues - assuming not locking this is faster than 
            //        // locking it, and we don't care if it's set twice to the same value.
            //        var version = Assembly.GetExecutingAssembly().GetName().Version;
            //        var ticksForDays = TimeSpan.TicksPerDay * version.Build; // days since 1 January 2000
            //        var ticksForSeconds = TimeSpan.TicksPerSecond * 2 * version.Revision; // seconds since midnight, (multiply by 2 to get original)
            //        _CachedCurrentVersionDate = new DateTime(2000, 1, 1).Add(new TimeSpan(ticksForDays + ticksForSeconds)).ToString("dd/MM/yyyy");
            //    }

            //    return _CachedCurrentVersionDate;
            //}
            //catch
            //{
            //    return "Unknown Version Date";
            //}
        }
        #endregion
    }
}