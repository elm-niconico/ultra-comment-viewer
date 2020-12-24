using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Threading.Tasks;
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.http;

namespace ultra_comment_viewer_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetWebSocketUrl()
        {
            var mock = new Mock<ILiveRestClient>();
            var userId = "testUser";

            mock.Setup(m  =>  m.GetWebSocketUrlAsync(userId)).ReturnsAsync("1111");
            var actual = await mock.Object.GetWebSocketUrlAsync(userId);
            var expect = "1111";
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public async Task TestGetWebSocketUrlReal()
        {
            var client = new TwicasRestClient();
            var mock = new Mock<TwicasRestClient>();
            var usrId = "elm03211114";
           
            var actual = await mock.Object.GetWebSocketUrlAsync(usrId);
            TestContext.WriteLine(actual);
        }

        [Test]
        public async Task TestMovieIdReal()
        {
            var client = new TwicasRestClient();
            var method = client.GetType().GetMethod("GetMovieIdAsync", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var userId = "elm03211114";
            var actual = await (Task<string>)method.Invoke(client, new object[]{  userId });
            TestContext.WriteLine(actual);
        }
        


    }
}