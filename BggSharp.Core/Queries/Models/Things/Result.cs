using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="result")]
    public class Result {
        [XmlAttribute(AttributeName="value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName="numvotes")]
        public string NumVotes { get; set; }
        [XmlAttribute(AttributeName="level")]
        public string Level { get; set; }
    }
}