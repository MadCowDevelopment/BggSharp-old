using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="minplayers")]
    public class MinPlayers {
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
    }
}