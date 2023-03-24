using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EducationalCenterAPI.Models
{
    public class Mentor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ism Familiya bo'sh bo'lishi mumkin emas!"),
            MaxLength(60), MinLength(5)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mentor haqida bo'sh bo'lishi mumkin emas!"),
            MaxLength(200), MinLength(10)]
        public string Discription { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string CvUrl { get; set; }
    }
}
