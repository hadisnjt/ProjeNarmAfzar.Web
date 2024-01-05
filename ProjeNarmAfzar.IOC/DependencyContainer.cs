
using Microsoft.Extensions.DependencyInjection;
using ProjeNarmAfzar.Application.Services.Implementations.Video;
using ProjeNarmAfzar.Application.Services.Implementations.VideoCategory;
using ProjeNarmAfzar.Application.Services.InterFaces.Video;
using ProjeNarmAfzar.Application.Services.InterFaces.VideoCategory;
using ProjeNarmAfzar.Data.Repositories.Video;
using ProjeNarmAfzar.Data.Repositories.VideoCategory;
using ProjeNarmAfzar.Domain.IRepositories.Video;
using ProjeNarmAfzar.Domain.IRepositories.VideoCategory;

namespace ProjeNarmAfzar.IOC
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Add Repositories
            services.AddScoped<IVideoCategoryRepository, VideoCategoryRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();

            // Add Services
            services.AddScoped<IVideoCategoryService, VideoCategoryService>();
            services.AddScoped<IVideoService, VideoService>();
        }
    }
}
