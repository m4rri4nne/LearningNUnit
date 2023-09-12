using LearningNUnit.BackEnd.Entities;
using RestSharp;

namespace LearningNUnit.BackEnd.Requests;

public class RequestClass
{
    
    static readonly string baseUrlNasa = "https://api.nasa.gov";
    static readonly string baseUrlFake = "https://fakerestapi.azurewebsites.net/api/v1/Books";

    public RestResponse NasaApiRequest(string? token="AZZG1IIlYSKdTvQpaHeuKYqM30t0bsEZdbi7NtVZ", string? queryParameters=null)
    {
        RestClient client = new RestClient(baseUrlNasa);
        RestRequest restRequest = new RestRequest(NasaResource(token, queryParameters), Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

    private string NasaResource(string token, string? queryParameters = null)
    {   
        var baseResource = $"/planetary/apod?api_key={token}";
        if (queryParameters != null)
        {
            return $"{baseResource}&{queryParameters}";
        }

        return baseResource;

    }

    public RestResponse GetFakeApiRequest(int? id=null)
    {
        RestClient client = new RestClient(baseUrlFake);
        RestRequest restRequest = new RestRequest(id == null ? baseUrlFake : $"{baseUrlFake}/{id}", Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }
    
    public static FakeApiEntities BuildBodyRequest(int? id=null)
    {
        return new FakeApiEntities
        {
            Id = id ?? 100,
            Title = "Test Book",
            Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
            Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
            PageCount = 100,
            PublishDate = "2023-09-03T13:50:32.6884665+00:00"
        };
    }

    public RestResponse PostFakeApiRequest()
    {
        RestClient client = new RestClient(baseUrlFake);
        var body = BuildBodyRequest();
        RestRequest restRequest = new RestRequest(baseUrlFake, Method.Post);
        restRequest.AddBody(body, ContentType.Json);

        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }
    
    public RestResponse PutFakeApiRequest(int id)
    {
        RestClient client = new RestClient(baseUrlFake);
        var body = BuildBodyRequest(id);
        RestRequest restRequest = new RestRequest( $"{baseUrlFake}/{id}", Method.Put);
        restRequest.AddBody(body, ContentType.Json);

        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

    public RestResponse DeleteFakeApiRequest(int id)
    {
        RestClient client = new RestClient(baseUrlFake);
        var body = BuildBodyRequest(id);
        RestRequest restRequest = new RestRequest( $"{baseUrlFake}/{id}", Method.Delete);
        restRequest.AddBody(body, ContentType.Json);

        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }
}