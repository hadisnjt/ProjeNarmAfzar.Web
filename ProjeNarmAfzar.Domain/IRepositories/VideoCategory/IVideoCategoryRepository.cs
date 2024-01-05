
using ProjeNarmAfzar.Domain.IRepositories.Commen;

namespace ProjeNarmAfzar.Domain.IRepositories.VideoCategory
{
    public interface IVideoCategoryRepository:IDbContextRepository
    {
        #region Video Category

        Task<List<Model.Video.VideoCategory>> GetAllVideoCategories();
        Task<bool> IsVideoCategoryIsExistByNameInUrl(string nameInUrl,long? categoryId);
        Task AddVideoCategory(Model.Video.VideoCategory category);
        Task<Model.Video.VideoCategory> GetVideoCategoryById(long categoryId);
        void EditVideoCategory(Model.Video.VideoCategory videoCategory);

        #endregion
    }
}
