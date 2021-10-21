using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="minage")]
    public class MinAge {
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
    }
}