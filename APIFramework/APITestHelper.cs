using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;

namespace APIFramework
{
    public class APITestHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://restful-booker.herokuapp.com/";
        
        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest CreateAuthRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }
        public RestRequest CreatePutRequest(string payload,string token)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Cookie", "token=" + token);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDeleteRequest(string token)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Cookie", "token=" + token);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }
                
        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO getContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

    }
}
