using System.Net;
using System.Text.Json;
using FluentAssertions;
using LearningNUnit.BackEnd.Entities;
using LearningNUnit.BackEnd.Requests;
using RestSharp;

namespace LearningNUnit.BackEnd.Tests;

public class FakeApiTests
{
    RequestClass request = new RequestClass();
    
    [Test]
    public void SearchBooks()
    {
        RestResponse response = request.GetFakeApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        
    }

    [Test]
    public void SearchForABook()
    {
        int id = 1;
        RestResponse response = request.GetFakeApiRequest(id);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
    }
    
    [Test]
    public void CreateABook()
    {
        RestResponse response = request.PostFakeApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content!);
        bodyContent!.Id.Should().NotBeNull();
        bodyContent!.Description.Should().NotBeNull();
        bodyContent!.Title.Should().NotBeNull();
        
    }
    
    [Test]
    public void UpdateABook()
    {
        RestResponse response = request.PutFakeApiRequest(15);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content!);
        bodyContent!.Id.Should().NotBeNull();
        bodyContent!.Id.Should().Be(15);
        bodyContent!.Description.Should().NotBeNull();
        bodyContent!.Title.Should().NotBeNull();
    }
    
    [Test]
    public void DeleteABook()
    {
        RestResponse response = request.DeleteFakeApiRequest(15);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
    }
}