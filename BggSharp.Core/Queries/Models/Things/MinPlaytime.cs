using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="minplaytime")]
    public class MinPlaytime {
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
    }
}