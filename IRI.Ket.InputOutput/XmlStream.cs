// besmellahe rahmane rahim
// Allahomma ajjel le-valiyek al-faraj

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IRI.Ket.IO
{
    public static class XmlStream
    {
        public static void Serialize<T>(string path, T value)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(path, System.Text.Encoding.UTF8);

            serializer.Serialize(writer, value);

            writer.Close();
        }

        public static string Parse<T>(T value)
        {
            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            //System.IO.StringWriter writer = new System.IO.StringWriter();

            //serializer.Serialize(writer, value);

            //return writer.ToString();


            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            //System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            //settings.Encoding = Encoding.UTF8;
            //settings.Indent = true;
            //settings.OmitXmlDeclaration = false;

            //using (StringWriter textWriter = new StringWriter())
            //{
            //    using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(textWriter, settings))
            //    {
            //        serializer.Serialize(xmlWriter, value);
            //    }

            //    return textWriter.ToString();
            //}


            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            //using (var stringWriter = new StringWriter())
            //{
            //    System.Xml.XmlWriterSettings setting = new System.Xml.XmlWriterSettings();
            //    setting.Indent = true;
            //    setting.Encoding = Encoding.UTF8;

            //    using (var xw = System.Xml.XmlTextWriter.Create(stringWriter, setting))
            //    {
            //        serializer.Serialize(xw, value);
            //        xw.Flush();

            //    }
            //    return stringWriter.ToString();
            //}

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8);

            serializer.Serialize(streamWriter, value);

            byte[] utf8EncodedXml = memoryStream.ToArray();
            return Encoding.UTF8.GetString(utf8EncodedXml);

            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            //System.IO.Stream stream = new System.IO.MemoryStream();
            //System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(stream, Encoding.UTF8);
            //serializer.Serialize(writer, value);
            //writer.Flush();

            //return writer.ToString();
        }

        public static T Deserialize<T>(string path)
        {
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(path);

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            T result = (T)serializer.Deserialize(reader);

            reader.Close();

            return result;
        }
    }
}
