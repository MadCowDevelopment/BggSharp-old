using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BggSharp.Core.Queries
{
    public abstract class QueryCriteria : IQueryCriteria
    {
        public string CreateQueryUrl()
        {
            var builder = new StringBuilder();
            builder.Append($"{Command}?");
            builder.Append($"{string.Join(",", GetParameters().Select(p => $"{p.Item1}={p.Item2}"))}");
            return builder.ToString();
        }

        protected abstract IEnumerable<(string, string)> GetParameters();

        protected abstract string Command { get; }
    }
}