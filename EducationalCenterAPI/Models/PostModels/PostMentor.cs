using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using EducationalCenterAPI.Entitys;

namespace EducationalCenterAPI.Models.PostModels
{
    public class PostMentor
    {
        [Required(ErrorMessage = "Ism Familiya bo'sh bo'lishi mumkin emas!"),
            MaxLength(60), MinLength(5), DisplayName("Mentor ism familyasi")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mentor haqida bo'sh bo'lishi mumkin emas!"),
            MaxLength(200), MinLength(10), DisplayName("Mentor haqida")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            NotNull, DisplayName("Mentor rasmi"),
            MaxFileSize(5 * 1024 * 1024), AllowedExtensions(".jpg", ".png", ".jpeg")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!")]
        public string CvUrl { get; set; }
    }
}
