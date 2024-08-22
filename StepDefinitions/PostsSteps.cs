using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
using System.Net;

namespace ChallengeSpecflowRestsharpApi.StepDefinitions
{
    [Binding]
    public class PostsSteps
    {
        private RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
        private RestRequest request = new RestRequest();
        private RestResponse response = new RestResponse();
        private string path = "posts/";
        private Post existingPost = new Post("74", "8", "enim unde ratione doloribus quas enim ut sit sapiente", string.Empty);
        private Post newPost = new Post(string.Empty, "12345", "title test", "body test");

        [Given(@"I send a GET request by ID")]
        public void GivenISendAGETRequestByID()
        {
            this.request = new RestRequest(this.path + existingPost.Id, Method.Get);
            this.response = this.client.Execute(request);
        }

        [Given(@"I send a POST request")]
        public void GivenISendAPOSTRequest()
        {
            this.request = new RestRequest(this.path, Method.Post);
            request.AddJsonBody(new
            {
                userId = newPost.UserId,
                title = newPost.Title,
                body = newPost.Body
            });
            this.response = this.client.Execute(request);
        }

        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string statusCode)
        {
            HttpStatusCode expectedStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);
            Assert.AreEqual(expectedStatusCode, this.response.StatusCode);
        }

        [Then(@"the response body should contain existing user data")]
        public void ThenTheResponseBodyShouldContainExistingUserData()
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.Content.Contains("\"userId\": " + existingPost.UserId));
                Assert.That(response.Content.Contains("\"id\": " + existingPost.Id));
                Assert.That(response.Content.Contains("\"title\": \"" + existingPost.Title + "\""));
            });
        }

        [Then(@"the response body should contain new user data")]
        public void ThenTheResponseBodyShouldContainNewUserData()
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.Content.Contains("\"userId\": \"" + newPost.UserId + "\""));
                Assert.That(response.Content.Contains("\"title\": \"" + newPost.Title + "\""));
                Assert.That(response.Content.Contains("\"body\": \"" + newPost.Body + "\""));
            });
        }
    }
}
