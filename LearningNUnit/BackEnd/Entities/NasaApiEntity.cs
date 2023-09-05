using System.Text.Json.Serialization;

namespace LearningNUnit.BackEnd.Entities;

public class NasaApiEntity
{
    [JsonPropertyName("copyright")]
    public string Copyright { get; }
    [JsonPropertyName("date")]
    public string Date { get;  }
    [JsonPropertyName("explanation")]
    public string Explanation { get; }
    [JsonPropertyName("hdurl")] public string Hdurl { get;  }
    [JsonPropertyName("media_type")] public string MediaType { get;  }
    [JsonPropertyName("service_name")] public string ServiceVersion { get; }
    [JsonPropertyName("title")] public string Title { get;}
    [JsonPropertyName("url")] public string Url { get;  }
}