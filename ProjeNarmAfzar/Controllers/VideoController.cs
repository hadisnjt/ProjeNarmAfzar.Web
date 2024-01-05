using Microsoft.AspNetCore.Mvc;
using ProjeNarmAfzar.Application.Services.InterFaces.Video;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Controllers
{
    public class VideoController : Controller
    {
        #region Constroctor

        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        #endregion

        #region Index
        [HttpGet("videos")]
        public async Task<IActionResult> Index(FilterVideoViewModel filter)
        {
            filter.VideoState = FilterVideoState.NotDeleted;
            var videos = await _videoService.FilterVideo(filter);
            return View(videos);
        }

        #endregion

        #region Video Detail
        [HttpGet("videos/{videoId}/{title}")]
        public async Task<IActionResult> VideoDetail(long videoId, string title)
        {
            var video = await _videoService.GetSingleVideo(videoId);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        #endregion
    }
}
