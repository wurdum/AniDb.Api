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
        public void IndexAllowsAccessByIndex() {
            var index = new Index();

            Assert.AreNotEqual(default(Index.Entry), index[0]);
        }
    }
}