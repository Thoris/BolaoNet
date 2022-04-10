using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace BolaoNet.MVC.Helpers
{
    /// <summary>
    /// Classe utilizada para prevenir ataques de sql injection.
    /// </summary>
    public class AntiSqlInjectionHelper
    {
        #region Variables

        private static readonly string[] _sqlExtremelyDangerousCharacters = { "--", "#" };
        private static readonly string[] _sqlDangerousCharacters = { "'", ";", "=", "&", "<", ">", "*", "\"" };
        //private static readonly string[] _sqlExtremelyDangerousStrings = { "drop", "insert", "delete", "truncate", "update", "alter", "exec", "xp_cmdshell" };
        //private static readonly string[] _sqlDangerousStrings = { "select", "null", "count", "like", "values", "into" };

        private static readonly string[] _xssExtremelyDangerousCharacters = { "<", ">" };
        private static readonly string[] _xssDangerousCharacters = { "'", ";", "!", "-", "=", "&", "{", "(", ")", "}", "#", "\"" };
        private static readonly string[] _xssExtremelyDangerousStrings = { "fromcharcode", "script", "javascript", "object", ".js", "vbscript", "allowscriptaccess", "activex" };
        private static readonly string[] _xssDangerousStrings = { "iframe", "object", "input", "dynsrc", "lowsrc", "size", "link", "href", "rel", "import", "moz-binding", "htc", "mocha", "livescript", "content", "embed", "src" };

        private static readonly Regex _whiteSpace = new Regex(@"[\c\r\n\t\0]", RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private static readonly Regex _findMultiSpaces = new Regex(@"[\ ]{2,}", RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private static readonly Regex _findHex = new Regex(@"\&\#x[0-9a-fA-F]{0,3}\;?|\%[0-9a-fA-F]{0,2}\;?", RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private static readonly Regex _findUnicode = new Regex("\\&\\#(?:0000)?(\\d{3})", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        #endregion

        #region Common attack checks

        /// <summary>
        /// Checks a string for XSS.
        /// Returns the possibility factor of the string containing a XSS attack.
        /// If it's 71+, then its a potential attack
        /// If it's 201+, then it's a XSS attack.
        /// Most real XSS attacks score from 700 and up
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The posibility factor</returns>
        public static int CheckForXss(string input)
        {
            int weight = 0;

            string temp = NormalizeData(input);

            foreach (string edc in _xssExtremelyDangerousCharacters)
            {
                if (temp.Contains(edc))
                    weight += 200;
            }

            foreach (string dc in _xssDangerousCharacters)
            {
                if (temp.Contains(dc))
                    weight += 35;
            }

            foreach (string eds in _xssExtremelyDangerousStrings)
            {
                if (temp.Contains(eds))
                    weight += 200;
            }

            foreach (string ds in _xssDangerousStrings)
            {
                if (temp.Contains(ds))
                    weight += 100;
            }

            return weight;
        }

        /// <summary>
        /// Checks for SQL injection.
        /// Returns the possibility factor of the string containing a SQL injection attack.
        /// If it's 71+, then its a potential attack
        /// If it's 201+, then it's a SQL injection attack.
        /// Most real SQL injection attacks score from 300 and up
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static int CheckForSqlInjection(string input)
        {
            int weight = 0;

            string temp = NormalizeData(input);

            foreach (string edc in _sqlExtremelyDangerousCharacters)
            {
                if (temp.Contains(edc))
                    weight += 200;
            }

            foreach (string dc in _sqlDangerousCharacters)
            {
                if (temp.Contains(dc))
                    weight += 35;
            }

            //foreach (string eds in _sqlExtremelyDangerousStrings)
            //{
            //    if (temp.Contains(eds))
            //        weight += 200;
            //}

            //foreach (string ds in _sqlDangerousStrings)
            //{
            //    if (temp.Contains(ds))
            //        weight += 100;
            //}

            return weight;
        }

        /// <summary>
        /// Método que verifica possíveis ataques de sql injection.
        /// </summary>
        /// <param name="input">Dado de entrada</param>
        /// <returns>true se é válido, false se há possíveis ataques.</returns>
        public static bool IsValidForSqlInjection(string input)
        {
            string temp = NormalizeData(input);

            foreach (string edc in _sqlExtremelyDangerousCharacters)
            {
                if (temp.Contains(edc))
                    return false;
            }

            foreach (string dc in _sqlDangerousCharacters)
            {
                if (temp.Contains(dc))
                    return false;
            }

            //foreach (string eds in _sqlExtremelyDangerousStrings)
            //{
            //    if (temp.Contains(eds))
            //        return false;
            //}

            //foreach (string ds in _sqlDangerousStrings)
            //{
            //    if (temp.Contains(ds))
            //        return false;
            //}

            return true;
        }

        /// <summary>
        /// Método que efetua a validação da entrada e dispara a exceção quando falhar.
        /// </summary>
        /// <param name="input">Dados de entrada.</param>
        public static void ValidateInput(string input)
        {
            if (!IsValidForSqlInjection(input))
                throw new Exception("Invalid Input, data is not allowed");
        }

        #endregion

        #region Normalize data and encoding

        /// <summary>
        /// This is only to be used when checking for attacks. It decodes html, removes multispaces, tabs and newlines,
        /// converts hex to ascii and converts unicode to ansi.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string NormalizeData(string data)
        {
            string temp = string.Empty;

            if (!string.IsNullOrEmpty(data))
            {
                //Converts the string to lowercase and decodes the encoded html in the string
                temp = HtmlDecodeCharacters(data.ToLowerInvariant());

                // Finds multispaces and replaces them with a single space
                temp = RemoveMultipleSpaces(temp);

                // Finds tabs, newlines and returns and removes them
                temp = RemoveTabsAndNewLines(temp);

                // Finds any hex in the string and replaces it with ASCII
                temp = ConvertHexToAscii(temp);

                // Converts unicode to ansi characters
                temp = ConvertUnicode(temp);
            }
            return temp;
        }

        /// <summary>
        /// Converts long and short format unicode to ASCII
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertUnicode(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                foreach (Match match in _findUnicode.Matches(input))
                {
                    input = input.Replace(match.Value, Convert.ToString(Convert.ToChar(short.Parse(match.Groups[1].Value))));
                }
            }

            return input;
        }

        /// <summary>
        /// Removes several spaces in a row and replaces them with a single space
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Returns the string with removed spaces</returns>
        public static string RemoveMultipleSpaces(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return _findMultiSpaces.Replace(input, " ");

            return string.Empty;
        }

        /// <summary>
        /// Removes tabs and newlines from the input
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string RemoveTabsAndNewLines(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return _whiteSpace.Replace(input, string.Empty);

            return string.Empty;
        }

        /// <summary>
        /// Converts the hex input to a string in ASCII
        /// </summary>
        /// <param name="hexValue">The hex string.</param>
        /// <returns>Returns a ASCII string</returns>
        public static string ConvertHexToAscii(string hexValue)
        {
            if (!string.IsNullOrEmpty(hexValue))
            {
                char[] cleanChars = { '&', '#', 'x', ';', '%' };

                foreach (Match match in _findHex.Matches(hexValue))
                {
                    string matchValueCleaned = match.Value;

                    foreach (char c in cleanChars)
                    {
                        matchValueCleaned = matchValueCleaned.Replace(c, ' ').Trim();
                    }

                    if (!string.IsNullOrEmpty(matchValueCleaned))
                    {
                        char hexChar = (char)int.Parse(matchValueCleaned, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
                        hexValue = hexValue.Replace(match.Value, hexChar.ToString(CultureInfo.InvariantCulture));
                    }
                }
            }

            return hexValue;
        }

        /// <summary>
        /// Encode HTML
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A string of encoded characters</returns>
        public static string HtmlEncodeCharacters(string input)
        {
            string encoded = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                encoded = HttpUtility.HtmlEncode(input);
            }
            return encoded;
        }

        /// <summary>
        /// Decode HTML
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlDecodeCharacters(string input)
        {
            string decoded = string.Empty;
            if (!string.IsNullOrEmpty(input))
                decoded = HttpUtility.HtmlDecode(input);

            return decoded;
        }

        #endregion
    }
}