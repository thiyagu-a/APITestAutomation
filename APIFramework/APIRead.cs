using APIFramework.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIFramework
{
    public class APIRead<T>
    {
        public IRestResponse CreateBooking(string endpoint, dynamic payload)
        {
            var bookingDetails = new APITestHelper<CreateBookingDTO>();
            var url = bookingDetails.SetUrl(endpoint);
            var request = bookingDetails.CreatePostRequest(payload);
            var response = bookingDetails.GetResponse(url, request);
            return response;
        }

        public IRestResponse UpdateBooking(string endpoint, dynamic payload, string token)
        {
            var bookingDetails = new APITestHelper<UpdateBookingDTO>();
            var url = bookingDetails.SetUrl(endpoint);
            var request = bookingDetails.CreatePutRequest(payload,token);
            var response = bookingDetails.GetResponse(url, request);
            return response;
        }
        public IRestResponse DeleteBooking(string endpoint, string token)
        {
            var bookingDetails = new APITestHelper<IRestResponse>();
            var url = bookingDetails.SetUrl(endpoint);
            var request = bookingDetails.CreateDeleteRequest(token);
            var response = bookingDetails.GetResponse(url, request);
            return response;
        }


        public CreateTokenDTO CreateToken(string endpoint)
        {
            string payload = @"{
                            ""username"" : ""admin"",
                            ""password"" : ""password123""
                            }";
            var authDetails = new APITestHelper<IRestResponse>();
            var url = authDetails.SetUrl(endpoint);
            var request = authDetails.CreateAuthRequest(payload);
            var response = authDetails.GetResponse(url, request);
            CreateTokenDTO content = authDetails.getContent<CreateTokenDTO>(response);
            return content;
        }

        public Int32 GetBookingId(IRestResponse createResponse)
        {
            var bookingDetails = new APITestHelper<CreateBookingDTO>();
            CreateBookingDTO content = bookingDetails.getContent<CreateBookingDTO>(createResponse);            ;
            return content!=null ? (Int32)content.Bookingid : 0;
        }

        public IRestResponse GetHealthCheck(string endpoint)
        {
            var apiDetails = new APITestHelper<IRestResponse>();
            var url = apiDetails.SetUrl(endpoint);
            var request = apiDetails.CreateGetRequest();
            var response = apiDetails.GetResponse(url, request);
            return response;
        }



    }
}
