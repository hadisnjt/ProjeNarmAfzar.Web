
using ProjeNarmAfzar.Application.Services.InterFaces.Video;
using ProjeNarmAfzar.Application.Statics;
using ProjeNarmAfzar.Application.Utilities.ExtensionMethods;
using ProjeNarmAfzar.Domain.IRepositories.Video;
using ProjeNarmAfzar.Domain.Model.Video;
using ProjeNarmAfzar.Domain.ViewModels.Video;

namespace ProjeNarmAfzar.Application.Services.Implementations.Video
{
    public class VideoService : IVideoService
    {
        #region Constroctor

        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        #endregion

        public async Task<FilterVideoViewModel> FilterVideo(FilterVideoViewModel filter)
        {
            return await _videoRepository.FilterVideo(filter);
        }

        public async Task<CreateVideoResult> CreateVideo(CreateVideoViewModel create)
        {
            if (create.Image == null)
            {
                return CreateVideoResult.NoImageUploaded;
            }

            // add video
            var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(create.Image.FileName);
            create.Image.AddImageToServer(imageName, PathTools.VideoOriginImageUpload);

            var newVideo = new Domain.Model.Video.Video
            {
                Title = create.Title,
                Description = create.Description,
                VideoCategoryId = create.VideoCategoryId,
                ImageName = imageName
            };

            await _videoRepository.AddVideo(newVideo);
            await _videoRepository.SaveChanges();

            // add video tags
            if (!string.IsNullOrEmpty(create.Tags))
                await _videoRepository.AddVideoTags(create.Tags.Split(',').ToList(), newVideo.Id);

            await _videoRepository.SaveChanges();
            return CreateVideoResult.Success;
        }

        public async Task<EditVideoViewModel> GetVideoForEdit(long videoId)
        {
            var video = await _videoRepository.GetVideoById(videoId);
            if (video == null)
            {
                return null;
            }

            var videoTags = string.Join(',', video.VideoTags.Select(s => s.TagTitle).ToArray());
            return new EditVideoViewModel
            {
                Id = video.Id,
                Description = video.Description,
                VideoCategoryId = video.VideoCategoryId,
                Title = video.Title,
                Tags = videoTags,
                VideoImage = video.ImageName
            };
        }

        public async Task<EditVideoResult> EditVideo(EditVideoViewModel edit)
        {
            var video = await _videoRepository.GetVideoById(edit.Id);
            if (video == null)
            {
                return EditVideoResult.NotFound;
            }

            if (video.ImageName != null)
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(edit.Image.FileName);
                edit.Image.AddImageToServer(imageName, PathTools.VideoOriginImageUpload, video.ImageName);

                video.ImageName = imageName;
            }

            video.Title = edit.Title;
            video.Description = edit.Description;
            video.VideoCategoryId = edit.VideoCategoryId;

            //edit video tags
            _videoRepository.RemoveAllVideoTags(video.Id);
            if (!string.IsNullOrEmpty(edit.Tags))
                await _videoRepository.AddVideoTags(edit.Tags.Split(',').ToList(), video.Id);

            await _videoRepository.SaveChanges();

            return EditVideoResult.Success;
            }

        public async Task<bool> RemoveVideo(long videoId)
        {
            var video = await _videoRepository.GetVideoById(videoId);
            if (video == null)
            {
                return false;
            }

            video.IsDelete = true;

            await _videoRepository.SaveChanges();

            return true;

        }

        public async Task<bool> ReturnVideo(long videoId)
        {
            var video = await _videoRepository.GetVideoById(videoId);
            if (video == null)
            {
                return false;
            }

            video.IsDelete = false;
            await _videoRepository.SaveChanges();

            return true;
        }

        public async Task<SingleVideoViewModel> GetSingleVideo(long videoId)
        {
            var video = await _videoRepository.GetVideoById(videoId);
            if (video == null)
            {
                return null;
            }

            return new SingleVideoViewModel
            {
                Id = video.Id,
                Description = video.Description,
                Title = video.Title,
                ImageName = video.ImageName,
                VideoCategoryId = video.VideoCategoryId,
                CategoryTitle = video.VideoCategory.Title,
            };
        }
    }
}
    
    

