
using System.ComponentModel.DataAnnotations;

namespace ProjeNarmAfzar.Domain.ViewModels.VideoCategory
{
    public class CreateVideoCategoryViewModel
    {
        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string TitleInUrl { get; set; }
    }

    public enum CreateVideoCategoryResult
    {
        Success,
        DuplicateCategory
    }
}
