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
            restResponse.Content.Should().Contain("hdurl");
            restResponse.Content.Should().Contain("media_type");
            restResponse.Content.Should().Contain("service_version");
            restResponse.Content.Should().Contain("title");
            restResponse.Content.Should().Contain("url");

        }
        
}
