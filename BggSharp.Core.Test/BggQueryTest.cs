using System.Threading.Tasks;
using BggSharp.Core.Queries;
using BggSharp.Core.Queries.Models.Things;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BggSharp.Core.Test
{
    [TestClass]
    public class BggQueryTest
    {
        public BggQueryTest()
        {

        }

        [TestMethod]
        public async Task X()
        {
            var result =
                await BggQuery.Execute<ThingItems, ThingItemQueryCriteria>(
                    new ThingItemQueryCriteria(new[] { "1" }));
        }
    }
}