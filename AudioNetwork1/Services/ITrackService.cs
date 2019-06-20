using AudioNetwork1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioNetwork1.Services
{
    public interface ITrackService
    {
        Task<IList<Track>> GetTracks();
        Task<IList<Composer>> GetComposers();
    }
}
