
using Microsoft.EntityFrameworkCore;
using ProjeNarmAfzar.Data.Context;
using ProjeNarmAfzar.Domain.IRepositories.Video;
using ProjeNarmAfzar.Domain.Model.Video;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Data.Repositories.Video
{
    public class VideoRepository : IVideoRepository
    {
        #region Constroctor

        private readonly ProjenarmAfzarDbContext _context;

        public VideoRepository(ProjenarmAfzarDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<FilterVideoViewModel> FilterVideo(FilterVideoViewModel filter)
        {
            var query = _context.Videos.AsQueryable();

            #region State

            switch (filter.VideoState)
            {
                case FilterVideoState.Deleted:
                    query = query.Where(video=>video.IsDelete);
                    break;
                case FilterVideoState.NotDeleted:
                    query = query.Where(video => !video.IsDelete);
                    break;
                case FilterVideoState.All:
                    query = query;
                    break;
            }

            #endregion

            #region filter By Title

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(video => EF.Functions.Like(video.Title, $"%{filter.Title}%"));
            }

            #endregion

            // paging 

            await filter.Paging(query);

            return filter;
        }

        public async Task AddVideo(Domain.Model.Video.Video video)
        {
            await _context.Videos.AddAsync(video);
        }


        public async Task<Domain.Model.Video.Video> GetVideoById(long videoId)
        {
            return await _context.Videos
                .Include(s=>s.VideoTags)
                .Include(s=>s.VideoCategory)
                .SingleOrDefaultAsync(video => video.Id == videoId);
        }

        #region product tags

        public async Task AddVideoTags(List<VideoTag> tags)
        {
            await _context.AddRangeAsync(tags);
        }

        public void RemoveAllVideoTags(long videoId)
        {
            var videoTags = _context.VideoTags.Where(tag => tag.VideoId == videoId);
            _context.VideoTags.RemoveRange(videoTags);
        }


        public async Task AddVideoTags(List<string> tags, long videoId)
        {
            List<VideoTag> videoTags = new List<VideoTag>();
            foreach (string tag in tags)
            {
                videoTags.Add(new VideoTag()
                {
                    VideoId = videoId,
                    TagTitle = tag
                });
            }

            await AddVideoTags(videoTags);
        }

        public void RemoveVideo(Domain.Model.Video.Video video)
        {
            if (video != null)
            {
                video.IsDelete = true;
            }
        }

        #endregion



        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
