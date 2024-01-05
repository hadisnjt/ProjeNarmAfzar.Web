
using Microsoft.EntityFrameworkCore;
using ProjeNarmAfzar.Domain.ViewModels.VideoCategory;

namespace ProjeNarmAfzar.Application.Services.InterFaces.VideoCategory
{
    public interface IVideoCategoryService
    {
        #region Video Category
        public Task<List<Domain.Model.Video.VideoCategory>> GetAllVideoCategories();
        Task<CreateVideoCategoryResult> CreateVideoCategory(CreateVideoCategoryViewModel create);
        Task<EditVideoCategoryViewModel> GetVideoCategoryForEdit(long categoryId);
        Task<EditVideoCategoryResult> EditVideoCategory(EditVideoCategoryViewModel edit);

        #endregion
    }
}
