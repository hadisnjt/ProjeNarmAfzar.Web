
using Microsoft.EntityFrameworkCore;
using ProjeNarmAfzar.Data.Context;
using ProjeNarmAfzar.Domain.IRepositories.VideoCategory;

namespace ProjeNarmAfzar.Data.Repositories.VideoCategory
{
    public class VideoCategoryRepository:IVideoCategoryRepository
    {
        #region Constroctor

        private readonly ProjenarmAfzarDbContext _context;

        public VideoCategoryRepository(ProjenarmAfzarDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Video Category

        public async Task<List<Domain.Model.Video.VideoCategory>> GetAllVideoCategories()
        {
           return await _context.VideoCategories.ToListAsync();
        }

        public async Task<bool> IsVideoCategoryIsExistByNameInUrl(string nameInUrl,long? categoryId)
        {
            if (categoryId == null)
            {
                return await _context.VideoCategories.AnyAsync(category=>category.TitleInUrl==nameInUrl);
            }

            return await _context.VideoCategories.AnyAsync(category => category.TitleInUrl == nameInUrl && category.Id != categoryId);
        }

        public async Task AddVideoCategory(Domain.Model.Video.VideoCategory category)
        {
            await _context.VideoCategories.AddAsync(category);
        }

        public async Task<Domain.Model.Video.VideoCategory> GetVideoCategoryById(long categoryId)
        {
            return await _context.VideoCategories.SingleOrDefaultAsync(category => category.Id == categoryId);
        }

        public void EditVideoCategory(Domain.Model.Video.VideoCategory videoCategory)
        {
            _context.VideoCategories.Update(videoCategory);
        }

        #endregion

        #region Save Changes

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
