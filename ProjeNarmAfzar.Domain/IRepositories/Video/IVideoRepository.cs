
using ProjeNarmAfzar.Domain.IRepositories.Commen;
using ProjeNarmAfzar.Domain.Model.Video;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Domain.IRepositories.Video
{
    public interface IVideoRepository:IDbContextRepository
    {
        Task<FilterVideoViewModel> FilterVideo(FilterVideoViewModel filter);
        Task AddVideo(Model.Video.Video video);
        Task<Model.Video.Video> GetVideoById(long videoId);
        Task AddVideoTags(List<VideoTag> tags);
        void RemoveAllVideoTags(long videoId);
        Task AddVideoTags(List<string> tags, long videoId);
        void RemoveVideo(Model.Video.Video video);
    }
}
