using Microsoft.AspNetCore.Mvc;
using ProjeNarmAfzar.Application.Services.InterFaces.VideoCategory;
using ProjeNarmAfzar.Domain.ViewModels.VideoCategory;

namespace ProjeNarmAfzar.Areas.Admin.Controllers
{
    public class VideoCategoryController : AdminBaseController
    {
        #region Constroctor

        private readonly IVideoCategoryService _videoCategoryService;

        public VideoCategoryController(IVideoCategoryService videoCategoryService)
        {
            _videoCategoryService = videoCategoryService;
        }

        #endregion

        #region Video Category List

        [HttpGet]
        public async Task<IActionResult> VideoCategoryList()
        {
            var category = await _videoCategoryService.GetAllVideoCategories();
            return View(category);
        }

        #endregion

        #region Create  

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVideoCategoryViewModel create)
        {
            if (ModelState.IsValid)
            {
                var result = await _videoCategoryService.CreateVideoCategory(create);
                switch (result)
                {
                    case CreateVideoCategoryResult.DuplicateCategory:
                        ModelState.AddModelError("TitleInUrl","این نام قبلا استفاده شده است");
                        break;
                    case CreateVideoCategoryResult.Success:
                        return RedirectToAction("VideoCategoryList");
                }
            }
            return View(create);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Edit(long id)
        {
            // get category for edit
            var category = await _videoCategoryService.GetVideoCategoryForEdit(id);

            // return not found if null
            if (category == null)
            {
                return NotFound();
            }
             
            // show data in form
            return View(category);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVideoCategoryViewModel edit)
        {
            if (ModelState.IsValid)
            {
                var result = await _videoCategoryService.EditVideoCategory(edit);
                switch (result)
                {
                    case EditVideoCategoryResult.DuplicateCategory:
                        ModelState.AddModelError("TitleInUrl","این نام قبلا استفاده شده است");
                        break;
                    case EditVideoCategoryResult.NotFound:
                        TempData["error message"] = "این دسته بندی یافت نشد ";
                        return RedirectToAction("VideoCategoryList");
                    case EditVideoCategoryResult.Success:
                        return RedirectToAction("VideoCategoryList");
                }
            }
            return View(edit);
        }

        #endregion
    }
}
