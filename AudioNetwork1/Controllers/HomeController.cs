using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AudioNetwork1.Models;
using AudioNetwork1.Services;
using AudioNetwork1.Models.ViewModels;

namespace AudioNetwork1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrackService _trackService;
        public int PageSize = 6;
        public HomeController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public async Task<IActionResult> Index(string category, int page = 1)
        {
            var trackList = await _trackService.GetTracks();

            var composerList = await _trackService.GetComposers();

            var model = new TrackIndexModel()
            {
                Composers = composerList,
                Tracks = trackList.Where(p => category == null || p.Genre == category)
                                       .OrderBy(p => p.Title)
                                      .Skip((page - 1) * PageSize)
                                      .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                   trackList.Count() :
                   trackList.Where(e => e.Genre == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
