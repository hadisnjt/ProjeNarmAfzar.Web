
using Microsoft.EntityFrameworkCore;
using ProjeNarmAfzar.Domain.Model.Video;

namespace ProjeNarmAfzar.Data.Context
{
    public class ProjenarmAfzarDbContext:DbContext
    {
        public ProjenarmAfzarDbContext(DbContextOptions<ProjenarmAfzarDbContext> options) : base(options) { }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }
        public DbSet<VideoTag> VideoTags { get; set; }
    }
}
