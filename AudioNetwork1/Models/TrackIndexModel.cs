using AudioNetwork1.Models.ViewModels;
using System.Collections.Generic;

namespace AudioNetwork1.Models
{
    public class TrackIndexModel
    {
        public IEnumerable<Track> Tracks { get; set; }
        public IEnumerable<Composer> Composers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
