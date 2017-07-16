using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BolaoNet.MVC.Helpers
{
    public class CultureHelper
    {
        #region Variables

        /// <summary>
        /// Variável que possui os idiomas válidos para seleção.
        /// </summary>
        private static readonly List<string> _validCultures = new List<string> { "pt-br" }; //, "en-us"};
        /// <summary>
        /// The _cultures
        /// </summary>
        private static readonly List<string> _cultures = new List<string> { "pt-br" }; //,"en-US"};

        #endregion

        #region Properties
        /// <summary>
        /// Returns true if the language is a right-to-left language. Otherwise, false.
        /// </summary>       
        public static bool IsRighToLeft()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;

        }
        #endregion

        #region Methods
        /// <summary>
        /// Método que retorna a cultura válida baseada no nome. 
        /// </summary>
        /// <param name="name">Nome do idioma.</param>
        /// <returns>Nome do idioma implementado.</returns>
        public static string GetImplementedCulture(string name)
        {
            // make sure it's not null
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); // retorna a cultura padrão

            // garantindo que a primeira cultura é válida
            if (_validCultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() == 0)
                return GetDefaultCulture(); // retorna a cultura padrão caso inválida

            // Se foi implementada
            if (_cultures.Where(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                return name;

            // Find a close match. For example, if you have "en-US" defined and the user requests "en-GB", 
            // the function will return closes match that is "en-US" because at least the language is the same (ie English)  
            var n = GetNeutralCulture(name);

            foreach (var c in _cultures)
                if (c.StartsWith(n))
                    return c;

            //Se não foi implementada
            return GetDefaultCulture(); //retorna a cultura padrão
        }
        /// <summary>
        /// Método que retorna o nome da cultura padrão
        /// </summary>
        /// <returns>Nome da cultura padrão.</returns>
        public static string GetDefaultCulture()
        {
            return _cultures[0]; // return Default culture
        }
        /// <summary>
        /// Propriedade que configura/retorna o nome da cultura corrente.
        /// </summary>
        /// <returns>Nome da cultura.</returns>
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }
        /// <summary>
        /// Propriedade que retorna a cultura neutra corrente.
        /// </summary>
        /// <returns>Nome da cultura neutra.</returns>
        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }
        /// <summary>
        /// Propriedade que retorna o nome neutro da cultura passada como parâmetro.
        /// </summary>
        /// <param name="name">Nome da cultura.</param>
        /// <returns>Nome neutro da cultura.</returns>
        public static string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;

            return name.Split('-')[0];
        }

        #endregion
    }
}