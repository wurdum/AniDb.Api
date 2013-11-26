using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AniDb.Api.Tests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void IndexIsNeverEmpty() {
            var index = new Index();

            Assert.True(index.Count > 0);
            Assert.AreEqual(index.FindFirst("❄").Value.Id, 4726);
        }

        [Test]
        public void IndexAllowsAccessByKey() {
            var index = new Index();

            var entries = index.FindAll("clannad");
            Assert.AreNotEqual(Enumerable.Empty<Index.Entry>(), entries);
            Assert.True(entries.Any());
        }
    }
}