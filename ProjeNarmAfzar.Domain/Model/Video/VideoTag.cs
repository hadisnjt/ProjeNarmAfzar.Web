
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjeNarmAfzar.Domain.Model.Commen;

namespace ProjeNarmAfzar.Domain.Model.Video
{
    public class VideoTag : BaseEntity
    {
        #region Properties
        public long VideoId { get; set; }

        [DisplayName("عنوان تگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")] 
        [MaxLength(128, ErrorMessage = "{0} وارد شده نمیتواند بیش از {1} کارکتر داشته باشد")]
        public string TagTitle { get; set; }

        #endregion

        #region Relations

        public Video Video { get; set; }

        #endregion
    }
}
