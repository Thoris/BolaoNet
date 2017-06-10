using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.Logging
{
    public class Logger : Domain.Interfaces.Services.Logging.ILogging
    {
        #region Constructors/Destructors

        /// <summary>
        ///  constructor to initialize configuration
        /// </summary>
        public Logger()
        {
            //XmlConfigurator.Configure();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Configure(string file)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(file));
        }
        /// <summary>
        /// Get Logger
        /// </summary>
        /// <param name="objectSource">The object source.</param>
        /// <returns></returns>
        private ILog GetLogger(object objectSource)
        {
            return log4net.LogManager.GetLogger(objectSource.GetType().FullName);
        }
        /// <summary>
        /// Add an information message to log4net regarding the source object
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Info(object sourceObject, string message, params string[] args)
        {
            GetLogger(sourceObject).Info(String.Format(CultureInfo.InvariantCulture, message, args));
        }
        /// <summary>
        /// Add an information message to log4net regarding the source object
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Debug(object sourceObject, string message, params string[] args)
        {
            GetLogger(sourceObject).Debug(String.Format(CultureInfo.InvariantCulture, message, args));
        }
        /// <summary>
        /// Add an information message to log4net regarding the source object
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Warn(object sourceObject, string message, params string[] args)
        {
            GetLogger(sourceObject).Warn(String.Format(CultureInfo.InvariantCulture, message, args));
        }
        /// <summary>
        /// Add an information message to log4net regarding the source object
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Error(object sourceObject, string message, params string[] args)
        {
            GetLogger(sourceObject).Error(String.Format(CultureInfo.InvariantCulture, message, args));
        }
        /// <summary>
        /// Fatals the specified source object.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Fatal(object sourceObject, string message, params string[] args)
        {
            GetLogger(sourceObject).Fatal(String.Format(CultureInfo.InvariantCulture, message, args));
        }
        /// <summary>
        /// Send error found when the system crashes.
        /// </summary>
        /// <param name="sourceObject">The source object.</param>
        /// <param name="ex">The exception value.</param>
        public void Fatal(object sourceObject, Exception ex)
        {
            GetLogger(sourceObject).Fatal(sourceObject, ex);
        }
        #endregion
    }
}
