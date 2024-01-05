using System.ComponentModel.DataAnnotations;

namespace ProjeNarmAfzar.Domain.ViewModels.Video
{
    public class SingleVideoViewModel
    {
        public long Id { get; set; }
        public long VideoCategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<SingleVideoViewModel>? RelatedVideos { get; set; }
    }
}
