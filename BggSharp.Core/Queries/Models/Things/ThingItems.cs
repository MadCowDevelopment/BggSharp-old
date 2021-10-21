using System.Collections.Generic;
using System.Xml.Serialization;

namespace BggSharp.Core.Queries.Models.Things
{
	[XmlRoot(ElementName="items")]
	public class ThingItems {
		[XmlElement(ElementName="item")]
		public List<Item> Item { get; set; }
		[XmlAttribute(AttributeName="termsofuse")]
		public string TermsOfUse { get; set; }
	}
}