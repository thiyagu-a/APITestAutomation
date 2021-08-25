using APIFramework;
using APIFramework.DTO;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace APITestAutomation
{
    public class Tests
    {

        [SetUp]
        public void HealthCheck()
        {
            var apiRead = new APIRead<IRestResponse>();
            var response = apiRead.GetHealthCheck("ping");
            Assert.That(response.StatusCode == HttpStatusCode.Created, "Health Check Failed");
        }

        [Test]
        public void CreateBooking()
        {
            string payload = @"{
                            ""firstname"" : ""Jim"",
                            ""lastname"" :  ""Brown"",
                            ""totalprice"" : 111,
                            ""depositpaid"" : true,
                            ""bookingdates"" : {
                            ""checkin"" : ""2018-01-01"",
                            ""checkout"" : ""2019-01-01""
                            },
                            ""additionalneeds"" : ""Breakfast""
                            }";

            var apiRead = new APIRead<CreateBookingDTO>();
            var response = apiRead.CreateBooking("booking", payload);
            Assert.That(response.StatusCode == HttpStatusCode.OK);
            Assert.That(string.IsNullOrEmpty(response.Content), Is.False);
        }



        [Test]
        public void UpdateBooking()
        {
            string payload = @"{
                            ""firstname"" : ""James_update"",
                            ""lastname"" : ""Brown"",
                            ""totalprice"" : 111,
                            ""depositpaid"" : true,
                            ""bookingdates"" : {
                            ""checkin"" : ""2018-01-01"",
                            ""checkout"" : ""2019-01-01""
                            },
                            ""additionalneeds"" : ""Breakfast""
                            }";
            string create_payload = @"{
                            ""firstname"" : ""Jim"",
                            ""lastname"" :  ""Brown"",
                            ""totalprice"" : 111,
                            ""depositpaid"" : true,
                            ""bookingdates"" : {
                            ""checkin"" : ""2018-01-01"",
                            ""checkout"" : ""2019-01-01""
                            },
                            ""additionalneeds"" : ""Breakfast""
                            }";

            var apiRead = new APIRead<UpdateBookingDTO>();
            var createResponse = apiRead.CreateBooking("booking", create_payload);
            var bookingId = apiRead.GetBookingId(createResponse);
            var tokenResponse = apiRead.CreateToken("auth");
            var response = apiRead.UpdateBooking("booking/"+ bookingId, payload, tokenResponse.Token);
            Assert.That(response.StatusCode == HttpStatusCode.OK);
            Assert.That(string.IsNullOrEmpty(response.Content), Is.False);
        }

        [Test]
        public void DeleteBooking()
        {
            string create_payload = @"{
                            ""firstname"" : ""Jim"",
                            ""lastname"" :  ""Brown"",
                            ""totalprice"" : 111,
                            ""depositpaid"" : true,
                            ""bookingdates"" : {
                            ""checkin"" : ""2018-01-01"",
                            ""checkout"" : ""2019-01-01""
                            },
                            ""additionalneeds"" : ""Breakfast""
                            }";
            var apiRead = new APIRead<CreateBookingDTO>();
            var createResponse = apiRead.CreateBooking("booking", create_payload);
            var bookingId = apiRead.GetBookingId(createResponse);
            var tokenResponse = apiRead.CreateToken("auth");
            var response = apiRead.DeleteBooking("booking/"+ bookingId, tokenResponse.Token);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}