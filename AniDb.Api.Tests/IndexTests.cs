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
            Assert.AreEqual(index.Find("❄").Value.Id, 4726);
        }
    }
}