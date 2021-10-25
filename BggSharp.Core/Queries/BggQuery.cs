using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace BggSharp.Core.Queries
{
    public static class BggQuery
    {
        private const string RootPath = "https://www.boardgamegeek.com/xmlapi2/";

        public static async Task<TResult> Execute<TResult, TCriteria>(TCriteria query) where TCriteria : IQueryCriteria
        {
            var client = new RestClient(RootPath);
            client.UseDotNetXmlSerializer();

            var request = new RestRequest(query.CreateQueryUrl(), DataFormat.Xml);

            return await client.GetAsync<TResult>(request);
        }
    }
}