using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="link")]
    public class Link {
        [XmlAttribute(AttributeName="type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName="id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
    }
}