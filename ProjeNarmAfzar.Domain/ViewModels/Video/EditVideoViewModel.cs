

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjeNarmAfzar.Domain.ViewModels.Video
{
    public class EditVideoViewModel
    {
        public long VideoCategoryId { get; set; }

        [Display(Name = "نام ویدیو")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "{0} وارد شده نمی تواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? Tags { get; set; }
        public long Id { get; set; }
        public string? VideoImage { get; set; }
    }

    public enum EditVideoResult
    {
        Success,
        NotFound,

    }
}
