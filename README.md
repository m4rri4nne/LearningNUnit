# Automated Tests using NUnit and C# - API Tests
---

### About the project 
Project focused on fix the knowledge on automated tests using NUnit Framework and C#. During this project, will be registered all the process to automated a test, like: 
- Understading the application 
- Writing Tests Cases 
- Automation of the tests 

The applications that will be tested: 

- [NASA APIs](https://api.nasa.gov/) 
- [Fake API](https://fakerestapi.azurewebsites.net/index.html)

You can see the step by step for this project [here](https://dev.to/m4rri4nne/nunit-and-c-tutorial-to-automate-your-api-tests-from-scratch-24nf)

---
### Setup
- .NET 7.0.307
- NUnit 3.13.3


### Dependencies 
- FluentAssertions 6.12.0
- RestSharp 110.2.0
- Should 1.1.20 

---
### Mind Map

<div align="center"> 

   ![mindmap.jpg](images%2Fmindmap.jpg)

</div>

--- 

### NASA API Tests

#### [About API](https://api.nasa.gov/)
This API returns the Astronomic Photo of the day in the following format: 
``` 
{
   "copyright":"\nAbdullah Al-Harbi\n",
   "date":"2023-09-04",
   "explanation":"As stars die, they create clouds.  Two stellar death clouds of gas and dust can be found toward the high-flying constellation of the Swan (Cygnus) as they drift through rich star fields in the plane of our Milky Way Galaxy. Caught here within the telescopic field of view are the Soap Bubble (lower left) and the Crescent Nebula (upper right). Both were formed at the final phase in the life of a star. Also known as NGC 6888, the Crescent Nebula was shaped as its bright, central massive Wolf-Rayet star, WR 136, shed its outer envelope in a strong stellar wind. Burning through fuel at a prodigious rate, WR 136 is near the end of a short life that should finish in a spectacular supernova explosion.  Discovered in 2013, the Soap Bubble Nebula is likely a planetary nebula, the final shroud of a lower mass, long-lived, Sun-like star destined to become a slowly cooling white dwarf. Both stellar nebulas are about 5,000 light-years distant, with the larger Crescent Nebula spanning about 25 light-years across. Within a few million years, both will likely have dispersed.   Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)",
   "hdurl":"https://apod.nasa.gov/apod/image/2309/CrescentBubble_AlHarbi_5732.jpg",
   "media_type":"image",
   "service_version":"v1",
   "title":"Cygnus: Bubble and Crescent",
   "url":"https://apod.nasa.gov/apod/image/2309/CrescentBubble_AlHarbi_1080.jpg"
}
```
Query parameters:

|Parameter	|Type |	Default |	Description  |
| ------------- | ------------- |------------- | ------------- |
date|	YYYY-MM-DD	 |today	|The date of the APOD image to retrieve |
start_date|	YYYY-MM-DD |	none |	The start of a date range, when requesting date for a range of dates. Cannot be used with date. |
end_date |	YYYY-MM-DD	| today |	The end of the date range, when used with start_date. |
count |	int |	none |	If this is specified then count randomly chosen images will be returned. Cannot be used with date or start_date and end_date.|
thumbs |	bool	 |	False |	If this is specified then count randomly chosen images will be returned. Cannot be used with date or start_date and end_date.|


#### Test cases

| Test | Expected Result |
| ------------- |------------- |
| Search for APOD using a valid token  | Status code 200 |
| Search for APOD using a valid token  | Valid body response
| Search for APOD using a valid token and passing a date  | Status code 200
| Search for APOD using a valid token and passing a date with wrong format  | Status code 400
| Search for APOD using a valid token and passing a start date and end date  | Status code 200
| Search for APOD using a valid token and passing a start date bigger than end date  | Status code 400
| Search for APOD using a invalid token | Status code 401

#### Process to automate
To automate, i've used the TDD process:

<div align="center"> 

   ![image-blog-test-driven-data.jpg](images%2Fimage-blog-test-driven-data.jpg)
</div>

First, i've created a test falling without any refactor:
```
 
 static string token = "AZZG1IIlYSKdTvQpaHeuKYqM30t0bsEZdbi7NtVZ";
 static string baseUrl = "https://api.nasa.gov";
 
 public void SearchApodSucess()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest= new RestRequest($"/planetary/apod?api_key={token}", Method.Get);
            RestResponse restResponse= client.Execute(restRequest);
            RestResponse restResponse = request.NasaApiRequest();
            restResponse.Should().NotBeNull();
            restResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }
```

After that, I've made the test pass and started the refactor. To test the BackEnd, I'm using the following model:
```
.
├── Solution
│   └── BackEnd
|       └── Entities/NasaApiEntity.cs
|       └── Requests/RequestClass.cs
|       └── Tests/NasaApiTests.cs  
```

- Entities: For body request and body response models. 
- Requests: Class responsible to do the requests of the project. 
- Tests: The automated tests. 

--- 
### Fake API Tests 

#### [About API](https://fakerestapi.azurewebsites.net/index.html)
This API returns a list of Books in the following format: 
``` 
[
  {
    "id": 1,
    "title": "Book 1",
    "description": "Lorem nonumy iusto takimata ut sit ut consetetur erat sanctus sed vel ut labore nulla et consetetur sed nonumy. Adipiscing hendrerit gubergren elitr at no\n",
    "pageCount": 100,
    "excerpt": "Nonumy duo no. Clita invidunt hendrerit lorem ea sed ipsum. Nonummy labore ut at lorem feugiat erat sit dolor sit et velit. Dolore sit lorem diam sit ipsum at stet elit kasd et et.\nJusto te accusam amet ea aliquyam iriure at et ea nihil esse nibh volutpat eros et. Eu consequat exerci voluptua dolor nonumy erat invidunt consetetur vel takimata veniam at zzril kasd dolor amet diam. Lorem kasd ipsum. Quod justo minim takimata dolor dolore sanctus clita diam dolore duis voluptua nonumy nibh cum velit tempor no. Velit suscipit diam ea sanctus consetetur dignissim magna dolor.\n",
    "publishDate": "2023-09-05T15:30:40.6574078+00:00"
  },
]
```

#### Test cases

| Test | Expected Result |
| ------------- |------------- |
| Search for Books  | Status code 200 |
| Search for Books  | Valid body response
| Search for a  Book  | Status code 200
| Create a Book  | Status code 200
| Update a Book  | Status code 200
| Delete a Book  | Status code 200

#### Process to automate

For the different methods(POST,PUT,DELETE), the process was basically the same,but, when is needed to pass a body request, before execute the request, just call the function AddBody. 

```
restRequest.AddBody(body, ContentType.Json);

```

To build the body request, i've created a method to use the FakeApiEntites:

```
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

```

To validate the response body during the tests, i've Deserialize the content of the response body using the JsonSerializer.Deserialize:

```
    var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content!);

```
