using System.Collections.Generic;
using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
    [XmlRoot(ElementName="item")]
    public class Item {
        [XmlElement(ElementName="thumbnail")]
        public string Thumbnail { get; set; }
        [XmlElement(ElementName="image")]
        public string Image { get; set; }
        [XmlElement(ElementName="name")]
        public List<Name> Names { get; set; }
        [XmlElement(ElementName="description")]
        public string Description { get; set; }
        [XmlElement(ElementName="yearpublished")]
        public YearPublished YearPublished { get; set; }
        [XmlElement(ElementName="minplayers")]
        public MinPlayers MinPlayers { get; set; }
        [XmlElement(ElementName="maxplayers")]
        public MaxPlayers MaxPlayers { get; set; }
        [XmlElement(ElementName="poll")]
        public List<Poll> Polls { get; set; }
        [XmlElement(ElementName="playingtime")]
        public Playtime Playtime { get; set; }
        [XmlElement(ElementName="minplaytime")]
        public MinPlaytime MinPlaytime { get; set; }
        [XmlElement(ElementName="maxplaytime")]
        public MaxPlaytime MaxPlaytime { get; set; }
        [XmlElement(ElementName="minage")]
        public MinAge MinAge { get; set; }
        [XmlElement(ElementName="link")]
        public List<Link> Links { get; set; }
        [XmlAttribute(AttributeName="type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName="id")]
        public string Id { get; set; }
    }
}