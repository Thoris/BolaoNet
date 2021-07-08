using System.Text;

namespace BolaoNet.MVC.Helpers
{
    /// <summary>
    /// Classe de gerenciamento de string.
    /// </summary>
    public class StringHelper
    {
        #region Methods

        /// <summary>
        /// Encodes the string.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns></returns>
        public static string EncodeString(string entry)
        {
            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(entry);
            string fixName = Encoding.UTF8.GetString(bytes);

            return fixName;
        }

        #endregion
    }
}