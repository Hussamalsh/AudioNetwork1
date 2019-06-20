using System.Net.Http;

namespace AudioNetwork1.Helpers
{
    public interface IHttpClientAccessor
    {
        HttpClient HttpClient { get; }
    }
}
