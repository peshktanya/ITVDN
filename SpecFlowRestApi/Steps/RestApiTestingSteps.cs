using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowRestApi.Steps
{
    [Binding]
    public class RestApiTestingSteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;

        [Given(@"connect to db")]
        public void GivenConnectToDb()
        {
            client = new RestClient("http://localhost:3000/");
            
        }

        [Given(@"create get request")]
        public void GivenCreateGetRequest()
        {
            request = new RestRequest("posts/1", Method.GET);
        }

        [When(@"send request")]
        public void WhenSendRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"response is success")]
        public void ThenResponseIsSuccess()
        {
            
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
