
using ProjeNarmAfzar.Domain.ViewModels.Paging;

namespace ProjeNarmAfzar.Domain.ViewModels.Video
{
    public class FilterVideoViewModel:BasePaging<Model.Video.Video>
    {
        public FilterVideoViewModel()
        {
            VideoState = FilterVideoState.All;
        }
        public string? Title { get; set; }
        public FilterVideoState VideoState { get; set; }
    }

    public enum FilterVideoState
    {
        All,
        Deleted,
        NotDeleted
    }
}
