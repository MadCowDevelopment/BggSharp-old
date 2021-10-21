using System.Collections.Generic;
using System.Linq;

namespace BggSharp.Core.Queries
{
    public class ThingItemQueryCriteria : QueryCriteria
    {
        private readonly IReadOnlyCollection<string> _ids;

        public ThingItemQueryCriteria(IEnumerable<string> ids)
        {
            _ids = ids.ToList().AsReadOnly();
        }

        protected override string Command => "thing";

        protected override IEnumerable<(string, string)> GetParameters()
        {
            return new[] { ("id", string.Join(",", _ids)) };
        }
    }
}