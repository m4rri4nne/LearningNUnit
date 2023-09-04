public class Requests{

    static string token = "AZZG1IIlYSKdTvQpaHeuKYqM30t0bsEZdbi7NtVZ";
    static string baseUrl = "https://api.nasa.gov/planetary/apod?api_key=";

    public async Task<HttpResponseMessage> NasaAPIRequest(){
        var client = new HttpClient();
        var response = await client.GetAsync(baseUrl+ token);

        return response; 

    }
}