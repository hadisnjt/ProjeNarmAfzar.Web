
using ProjeNarmAfzar.Domain.ViewModels.Paging;

namespace ProjeNarmAfzar.Domain.ViewModels.VideoCategory
{
    public class FilterVideoCategoryViewModel:BasePaging<Model.Video.VideoCategory>
    {
        public string TitleUrl { get; set; }
    }
}
