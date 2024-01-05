using Microsoft.AspNetCore.Mvc;
using ProjeNarmAfzar.Application.Services.InterFaces.Video;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Controllers
{
    public class HomeController : Controller
    {
        #region Constroctor

        private readonly ILogger<HomeController> _logger;
        private readonly IVideoService _videoService;
        public HomeController(ILogger<HomeController> logger, IVideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        #endregion

        public async Task<IActionResult> Index(FilterVideoViewModel filter)
        {
            filter.VideoState = FilterVideoState.NotDeleted;
            var videos = await _videoService.FilterVideo(filter);
            return View(videos);
            
        }
    }
}