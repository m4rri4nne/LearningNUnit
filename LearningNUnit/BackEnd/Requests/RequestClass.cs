using RestSharp;

namespace LearningNUnit.BackEnd.Requests;

public class RequestClass
{

    static string token = "AZZG1IIlYSKdTvQpaHeuKYqM30t0bsEZdbi7NtVZ";
    static string baseUrl = "https://api.nasa.gov";

    public RestResponse NasaApiRequest(string? queryParameters=null)
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest = new RestRequest(NasaResource(token, queryParameters), Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

    private string NasaResource(string token, string? queryParameters = null)
    {   
        var baseResource = $"/planetary/apod?api_key={token}";
        if (queryParameters != null)
        {
            return baseResource + queryParameters;
        }

        return baseResource;

    }
}