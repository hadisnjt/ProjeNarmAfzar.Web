
using ProjeNarmAfzar.Application.Services.InterFaces.VideoCategory;
using ProjeNarmAfzar.Domain.IRepositories.VideoCategory;
using ProjeNarmAfzar.Domain.ViewModels.VideoCategory;

namespace ProjeNarmAfzar.Application.Services.Implementations.VideoCategory
{
    public class VideoCategoryService : IVideoCategoryService
    {
        #region Constroctor

        private readonly IVideoCategoryRepository _videoCategoryRepository;

        public VideoCategoryService(IVideoCategoryRepository videoCategoryRepository)
        {
            _videoCategoryRepository = videoCategoryRepository;
        }

        #endregion

        #region Video Category

        public async Task<List<Domain.Model.Video.VideoCategory>> GetAllVideoCategories()
        {
            return await _videoCategoryRepository.GetAllVideoCategories();
        }

        public async Task<CreateVideoCategoryResult> CreateVideoCategory(CreateVideoCategoryViewModel create)
        {
            // check name in url is exist or not

            var isExist = await _videoCategoryRepository.IsVideoCategoryIsExistByNameInUrl(create.TitleInUrl,null);
            if (isExist)
            {
                return CreateVideoCategoryResult.DuplicateCategory;
            }

            // add category

            await _videoCategoryRepository.AddVideoCategory(new Domain.Model.Video.VideoCategory
            {
                TitleInUrl = create.TitleInUrl,
                Title = create.Title,
            });

            await _videoCategoryRepository.SaveChanges();
            return CreateVideoCategoryResult.Success;
        }

        public async Task<EditVideoCategoryViewModel> GetVideoCategoryForEdit(long categoryId)
        {
            // get category data from database
            var category = await _videoCategoryRepository.GetVideoCategoryById(categoryId);

            // return null if not found
            if (category == null)
            {
                return null;
            }

            // return view model of data
            return new EditVideoCategoryViewModel
            {
                Id = category.Id,
                Title = category.Title,
                TitleInUrl = category.TitleInUrl
            };
        }

        public async Task<EditVideoCategoryResult> EditVideoCategory(EditVideoCategoryViewModel edit)
        {
            // get base data from database
            var mainCategory = await _videoCategoryRepository.GetVideoCategoryById(edit.Id);

            // check data is not found
            if (mainCategory == null)
            {
                return EditVideoCategoryResult.NotFound;
            }

            // check data is duplicate or not
            var isExist = await _videoCategoryRepository.IsVideoCategoryIsExistByNameInUrl(edit.TitleInUrl, edit.Id);
            if (isExist)
            {
                return EditVideoCategoryResult.DuplicateCategory;
            }

            // edit video category
            mainCategory.TitleInUrl = edit.TitleInUrl;
            mainCategory.Title = edit.Title;
            _videoCategoryRepository.EditVideoCategory(mainCategory);
            await _videoCategoryRepository.SaveChanges();

            return EditVideoCategoryResult.Success;
        }

        #endregion
    }
}
