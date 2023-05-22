using System.ComponentModel.DataAnnotations;

namespace MyTasks.Core.Models.Domains
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Kategoria jest wymagane")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Pole Tytuł jest wymagane")]
        [MaxLength(50)]
        [Display(Name ="Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole Opis jest wymagane")]
        [MaxLength(250)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Termin")]
        public DateTime? Term { get; set; }

        [Display(Name = "Zrealizowane")]
        public bool IsExecuted { get; set; }

        public string UserId { get; set; }

        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
