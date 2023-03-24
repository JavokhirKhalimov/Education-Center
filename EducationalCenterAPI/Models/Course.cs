using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EducationalCenterAPI.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Kurs nomi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(10, ErrorMessage = "Kamida 10 ta belgi kiriting!"),
            MaxLength(300, ErrorMessage = "Ko'pi bilan 300 ta belgi kiriting!"),
            DisplayName("Kurs haqida")]
        public string Discription { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Kurs davomiyligi")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(10, ErrorMessage = "Kamida 10 ta belgi kiriting!"),
            DisplayName("Kurs davomida o'rganiladi")]
        public string Learning { get; set; }

        [ForeignKey(nameof(Mentor))]
        public int MentorId { get; set; }

        [ForeignKey(nameof(MentorId))]
        public virtual Mentor Mentor { get; set; }
    }
}
