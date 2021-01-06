using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ultra_comment_viewer.src.model.xml.model;

namespace ultra_comment_viewer.src.model.xml.converter
{
    public class NicoNicoXmlConverter
    {

        public UserNickNameXmlModel ConvertToNickNameModel(string xml)
        {
            using var memory = new MemoryStream();

            WriteXmlBinary(xml, memory);

            var serialize = new System.Xml.Serialization.XmlSerializer(typeof(UserNickNameXmlModel));

            return (UserNickNameXmlModel)serialize.Deserialize(memory);
        }

        private void WriteXmlBinary(string xml, MemoryStream memory)
        {
            var buffer = Encoding.UTF8.GetBytes(xml);
            memory.Write(buffer, 0, buffer.Length);
            memory.Seek(0, SeekOrigin.Begin);
        }
    }
}
