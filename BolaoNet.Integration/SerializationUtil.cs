using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BolaoNet.Integration
{
    /// <summary>
    /// Classe que possui funcionalidades de serialização e deserialização.
    /// </summary>
    public class SerializationUtil<T> where T : class
    {
        #region Methods

        public T Deserialize(byte[] xmlByteData)
        {
            XmlSerializer ds = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(xmlByteData);
            T res = (T)ds.Deserialize(memoryStream);
            return res;

        }
        public string Serialize(T entry)
        {
            String XmlizedString = null;
            XmlSerializer xs = new XmlSerializer(typeof(T));
            //create an instance of the MemoryStream class since we intend to keep the XML string 
            //in memory instead of saving it to a file.
            MemoryStream memoryStream = new MemoryStream();
            //XmlTextWriter - fast, non-cached, forward-only way of generating streams or files 
            //containing XML data
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            //Serialize emp in the xmlTextWriter
            xs.Serialize(xmlTextWriter, entry);
            //Get the BaseStream of the xmlTextWriter in the Memory Stream
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            //Convert to array
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
            return XmlizedString;
        }
        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        #endregion
    }
}
