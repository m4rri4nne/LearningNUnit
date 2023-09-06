using System.Net;
using FluentAssertions;
using LearningNUnit.BackEnd.Requests;
using NUnit.Allure.Attributes;
using RestSharp;
namespace LearningNUnit.BackEnd.Tests;
public class NasaApiTests
{
        RequestClass request = new RequestClass();
        [Test]
        public void SearchApodSucess()
        {
            RestResponse restResponse = request.NasaApiRequest();
            restResponse.Should().NotBeNull();
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            restResponse.Content.Should().Contain("copyright");
            restResponse.Content.Should().Contain("date");
            restResponse.Content.Should().Contain("explanation");
            //restResponse.Content.Should().Contain("hdurl");
            restResponse.Content.Should().Contain("media_type");
            restResponse.Content.Should().Contain("service_version");
            restResponse.Content.Should().Contain("title");
            restResponse.Content.Should().Contain("url");

        }

        [Test]
        public void SearchApodWithDate()
        {
            var queryParameters = "date=2023-05-01";
            RestResponse restResponse = request.NasaApiRequest(queryParameters: queryParameters);
            restResponse.Should().NotBeNull();
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            restResponse.Content.Should().Contain("copyright");
            restResponse.Content.Should().Contain("date");
            restResponse.Content.Should().Contain("explanation");
            //restResponse.Content.Should().Contain("hdurl");
            restResponse.Content.Should().Contain("media_type");
            restResponse.Content.Should().Contain("service_version");
            restResponse.Content.Should().Contain("title");
            restResponse.Content.Should().Contain("url");

        }

        [Test]
        public void SearchApodWithDateWrongFormat()
        {
            var queryParameters = "date=2023/05/01";
            RestResponse restResponse = request.NasaApiRequest(queryParameters: queryParameters);
            restResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void SearchApodWithStartDateEndDate()
        {
            const string startDate = "2023-05-01";
            const string endDate = "2023-06-01";
            var queryParameters = $"start_date={startDate}&end_date={endDate}";
            RestResponse restResponse = request.NasaApiRequest(queryParameters: queryParameters);
            restResponse.Should().NotBeNull();
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            restResponse.Content.Should().Contain("copyright");
            restResponse.Content.Should().Contain("date");
            restResponse.Content.Should().Contain("explanation");
            //restResponse.Content.Should().Contain("hdurl");
            restResponse.Content.Should().Contain("media_type");
            restResponse.Content.Should().Contain("service_version");
            restResponse.Content.Should().Contain("title");
            restResponse.Content.Should().Contain("url");
        }
        
        [Test]
        public void SearchApodWithStartDateBiggerThanEndDate()
        {
            const string startDate = "2023-12-01";
            const string endDate = "2023-11-01";
            var queryParameters = $"start_date={startDate}&end_date={endDate}";
            RestResponse restResponse = request.NasaApiRequest(queryParameters: queryParameters);
            restResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Test]
        public void SearchApodWithInvalidToken()
        {
            var token = "invalidToken";
            RestResponse restResponse = request.NasaApiRequest(token);
            restResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
}
