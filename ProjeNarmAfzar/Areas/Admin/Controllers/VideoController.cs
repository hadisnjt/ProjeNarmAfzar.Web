using Microsoft.AspNetCore.Mvc;
using ProjeNarmAfzar.Application.Services.InterFaces.Video;
using ProjeNarmAfzar.Application.Services.InterFaces.VideoCategory;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Areas.Admin.Controllers
{
    public class VideoController : AdminBaseController
    {
        #region Constroctor

        private readonly IVideoService _videoService;
        private readonly IVideoCategoryService _videoCategoryService;

        public VideoController(IVideoService videoService, IVideoCategoryService videoCategoryService)
        {
            _videoService = videoService;
            _videoCategoryService = videoCategoryService;
        }

        #endregion

        #region list

        public async Task<IActionResult> VideoLists(FilterVideoViewModel filter)
        {
            var data = await _videoService.FilterVideo(filter);
            return View(data);
        }

        #endregion

        #region Create

        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _videoCategoryService.GetAllVideoCategories();
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVideoViewModel create)
        {
            if (ModelState.IsValid)
            {
               var result= await _videoService.CreateVideo(create);
               switch (result)
               {
                    case CreateVideoResult.NoImageUploaded:
                        ModelState.AddModelError("","");
                        break;
                    case CreateVideoResult.Success:
                        return RedirectToAction("VideoLists");
               }
            }
            ViewBag.categories = await _videoCategoryService.GetAllVideoCategories();
            return View(create);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Edit(long videoId)
        {
            // get video for edit
            var video = await _videoService.GetVideoForEdit(videoId);
            if (video==null)
            {
                return NotFound();
            }
            ViewBag.categories = await _videoCategoryService.GetAllVideoCategories();
            ViewBag.referer = Request.Headers["Referer"].ToString();
            return View(video);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVideoViewModel edit,string? referer)
        {
            if (ModelState.IsValid)
            {
                // edit video
                var result=await _videoService.EditVideo(edit);
                switch (result)
                {
                    case EditVideoResult.NotFound:
                        return NotFound();

                    case EditVideoResult.Success:
                        if (!string.IsNullOrEmpty(referer))
                        {
                            return Redirect(referer);
                        }
                        return RedirectToAction("VideoLists");
                } 
            }
            ViewBag.categories = await _videoCategoryService.GetAllVideoCategories();
            return View(edit);
        }

        #endregion

        #region Remove

        public async Task<IActionResult> RemoveVideo(long id)
        {
            var result=await _videoService.RemoveVideo(id);
            if (result)
            {
                return new JsonResult(new
                {
                    status="success",
                    videoid=id
                });
            }

            return new JsonResult(new
            {
                status = "Failed",
                videoid = id
            });
        }

        #endregion 
        
        #region Return

        public async Task<IActionResult> ReturnVideo(long id)
        {
            var result=await _videoService.ReturnVideo(id);
            if (result)
            {
                return new JsonResult(new
                {
                    status="success",
                    videoid=id
                });
            }

            return new JsonResult(new
            {
                status = "Failed",
                videoid = id
            });
        }

        #endregion
    }
}
