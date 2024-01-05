
using ProjeNarmAfzar.Domain.Model.Commen;
using System.ComponentModel.DataAnnotations;

namespace ProjeNarmAfzar.Domain.Model.Video
{
    public class Video:BaseEntity
    {
        #region Properties

        public long VideoCategoryId { get; set; }

        [Display(Name = "نام ویدیو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string ImageName { get; set; }

        #endregion

        #region Relations

        public VideoCategory VideoCategory { get; set; }
        public ICollection<VideoTag> VideoTags { get; set; }

        #endregion
    }
}
