
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ultra_comment_viewer.src.model.xml.model
{


    [XmlRoot(ElementName = "user")]
    public class User
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "nickname")]
        public string Nickname { get; set; }
    }

    [XmlRoot(ElementName = "response")]
    public class UserNickNameXmlModel
    {
        [System.Xml.Serialization.XmlElement(ElementName = "user")]
        public User User { get; set; }
    }




}
