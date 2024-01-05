
using ProjeNarmAfzar.Domain.Model.Commen;
using System.ComponentModel.DataAnnotations;

namespace ProjeNarmAfzar.Domain.Model.Video
{
    public class VideoCategory:BaseEntity
    {
        #region Properties

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string TitleInUrl { get; set; }

        #endregion

        #region Relations

        public ICollection<Video> Videos { get; set; }

        #endregion
    }
}
