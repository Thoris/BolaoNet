using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BolaoNet.Estatisticas.Calculo
{
    public class Serialization
    {
        #region Methods

        public static T DeserializeFromFile<T>(string file)
        {
            StreamReader reader = new StreamReader(file);

            string data = reader.ReadToEnd();

            reader.Close();

            T obj = Deserialize<T>(data);

            return obj;
        }
        public static T Deserialize<T>(string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }

        public static void Serialize<T>(T toSerialize, string file)
        {
            StreamWriter writer = new StreamWriter(file);

            string buffer = Serialize<T>(toSerialize);

            writer.Write(buffer);

            writer.Close();
        }
        public static string Serialize<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }
        #endregion
    }
}
