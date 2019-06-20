using AudioNetwork1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioNetwork1.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ITrackService _trackService;
        public NavigationMenuViewComponent(ITrackService trackService)
        {
            _trackService = trackService;
        }
        public IViewComponentResult Invoke()
        {
            var trackList =  _trackService.GetTracks().GetAwaiter().GetResult();

            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(trackList
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
