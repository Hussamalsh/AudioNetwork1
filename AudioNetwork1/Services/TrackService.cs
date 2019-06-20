using AudioNetwork1.Configurations;
using AudioNetwork1.Helpers;
using AudioNetwork1.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AudioNetwork1.Services
{
    /// <summary>
    /// TrackService
    /// The class provides functions to help with TrackService. 
    /// </summary>
    public class TrackService : ITrackService
    {
        /// <summary>
        /// Provides a base class for sending HTTP requests and receiving HTTP responses.
        /// </summary>
        private readonly HttpClient _httpclient;
        private readonly AppSettings _appSetings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpclient">Provides a base class for sending HTTP requests and receiving HTTP responses.</param>
        public TrackService(IHttpClientAccessor httpClientAccessor, IOptions<AppSettings>  appSetings)
        {
            _httpclient = httpClientAccessor.HttpClient;
            _appSetings = appSetings.Value;
        }

        /// <summary>
        /// This function return list of tracks
        /// </summary>
        /// <returns>returns a list of trakcs</returns>
        public async Task<IList<Track>> GetTracks()
        {
            HttpResponseMessage response = await _httpclient.GetAsync("/tracks");
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                var trackList = JsonConvert.DeserializeObject<List<Track>>(contents);
                return trackList;
            }
            return new List<Track>();
        }

        /// <summary>
        /// This function return list of composers
        /// </summary>
        /// <returns>returns a list of composers</returns>
        public async Task<IList<Composer>> GetComposers()
        {
            HttpResponseMessage response = await _httpclient.GetAsync("/composers");
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                var composerList = JsonConvert.DeserializeObject<IList<Composer>>(contents);
                return composerList;
            }
            return new List<Composer>();
        }
    }
}
