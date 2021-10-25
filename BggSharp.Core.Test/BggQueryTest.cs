using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BggSharp.Core.Queries;
using BggSharp.Core.Queries.Models.Things;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

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

            Assert.AreEqual(1, result.Items.Count);
            Assert.AreEqual("Die Macher", result.Items[0].Names[0].Value);
        }


        [TestMethod]
        public async Task GetAllImageIds()
        {
            var existingImageIds = await File.ReadAllLinesAsync(@"D:\ImageIds.txt");
            var gameIds = await File.ReadAllLinesAsync(@"D:\GameIds.txt");

            var imageIds = new List<string>();
            for (var i = 0; i < gameIds.Length; i++)
            {
                var gameId = gameIds[i];
                var imageId = existingImageIds[i];
                if (string.IsNullOrEmpty(gameId))
                {
                    imageIds.Add(string.Empty);
                    continue;
                }

                if (!string.IsNullOrEmpty(imageId) && !imageId.StartsWith("ERROR"))
                {
                    imageIds.Add(imageId);
                    continue;
                }

                try
                {
                    var result =
                        await BggQuery.Execute<ThingItems, ThingItemQueryCriteria>(
                            new ThingItemQueryCriteria(new[] { gameId }));

                    var imageUrl = result.Items[0].Image;
                    var picPart = imageUrl.Substring(imageUrl.IndexOf("/pic"));
                    imageId = picPart.Substring(4, picPart.Length - 8);
                    imageIds.Add(imageId);
                }
                catch (Exception)
                {
                    imageIds.Add($"ERROR: {gameId}");
                }

                Thread.Sleep(500);
            }

            await File.WriteAllLinesAsync(@"D:\ImageIds.txt", imageIds);
        }

        [TestMethod]
        public void WriteTestPost()
        {
            var builder = new StringBuilder();
            var lines = File.ReadAllLines(@"D:\Book1.csv");
            foreach (var line in lines)
            {
                var items = line.Split(";");
                if(items[1] == string.Empty) continue;

                builder.AppendLine(items[0]);
                builder.AppendLine($"[thing={items[1]}][/thing]");
                builder.AppendLine($"[ImageID={items[2]}]");
                builder.AppendLine();
            }

            File.WriteAllText(@"D:\TestPost.txt", builder.ToString());
        }
    }
}