
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Application.Services.InterFaces.Video
{
    public interface IVideoService
    {
        Task<FilterVideoViewModel> FilterVideo(FilterVideoViewModel filter);
        Task<CreateVideoResult> CreateVideo(CreateVideoViewModel create);
        Task<EditVideoViewModel> GetVideoForEdit(long videoId);
        Task<EditVideoResult> EditVideo(EditVideoViewModel edit);
        Task<bool> RemoveVideo(long videoId);
        Task<bool> ReturnVideo(long videoId);
        Task<SingleVideoViewModel> GetSingleVideo(long videoId);
    }
}
