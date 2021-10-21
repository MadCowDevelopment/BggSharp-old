using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="yearpublished")]
    public class YearPublished {
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
    }
}