using System.Net;
using FluentAssertions;
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
        
    }
    
    [Test]
    public void CreateABook()
    {
        
    }
    
    [Test]
    public void UpdateABook()
    {
        
    }
    
    [Test]
    public void DeleteABook()
    {
        
    }
}