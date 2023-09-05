using LearningNUnit.BackEnd.Entities;
using RestSharp;

namespace LearningNUnit.BackEnd.Requests;

public class RequestClass
{
    static string token = "AZZG1IIlYSKdTvQpaHeuKYqM30t0bsEZdbi7NtVZ";
    static string baseUrl = "https://api.nasa.gov";

    public RestResponse NasaApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest= new RestRequest($"/planetary/apod?api_key={token}", Method.Get);
        RestResponse restResponse= client.Execute(restRequest);

        return restResponse;
    }
}