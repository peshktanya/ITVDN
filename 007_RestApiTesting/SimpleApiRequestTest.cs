using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace RESTTest
{
    [TestFixture]
    public class SimpleApiRequest
    {
        [SetUp]
        public void Setup()
        {
        }

        

        [Test]
        public void CheckSuccessfulResponse_WhenGetUsersRepos()
        {
            // arrange
            RestClient client = new RestClient("https://api.github.com/");
            RestRequest request = new RestRequest("users/restsharp/repos", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        } 

    }
}