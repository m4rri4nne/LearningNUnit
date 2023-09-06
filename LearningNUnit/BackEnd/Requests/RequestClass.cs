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

    public RestResponse GetFakeApiRequest()
    {
        RestClient client = new RestClient(baseUrlFake);
        RestRequest restRequest = new RestRequest(baseUrlFake, Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }
}