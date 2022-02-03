using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RESTTest.Model;
using System.Collections.Generic;
using System.Net;

namespace RESTTest
{
    [TestFixture]
    public class CompleteTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GET_WhenGetPostsWithId_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("posts/1", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GET_WhenGetPostsWithId_ResponseShouldContainExpectedValue()
        {
            // arrange
            string title = "super title";
            string author = "john smith";
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("posts/1", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert          
            var result = new JsonDeserializer().Deserialize<Dictionary<string, string>>(response);
            Assert.That(result["title"], Is.EqualTo(title));
            Assert.That(result["author"], Is.EqualTo(author));
        }    

        [Test]
        public void POST_WhenExecutePostModel_ItShouldAppearInResponse()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new PostsModel()
            {
                id = "3",
                title = "test-title",
                author = "Api test"
            });

            // act
            IRestResponse<PostsModel> response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.Data.author, Is.EqualTo("Api test"));

        }


        [Test]
        public void PUT_UpdateTypeClassBody()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("posts/2", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new PostsModel()
            {
                title = "test-title",
                author = "anna"
            });

            // act
            var response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.Data.author, Is.EqualTo("anna"));

        }

        [Test]
        public void DELETE_RemovePostsWithId_ShouldBeSuccessful()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:3000/");
            RestRequest request = new RestRequest("posts/4", Method.DELETE);


            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

    }
}