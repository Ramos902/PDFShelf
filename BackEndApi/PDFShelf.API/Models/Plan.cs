using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDFShelf.Api.Models
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do plano é obrigatório.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // Free, Basic, Premium

        [Required]
        public double StorageLimitMB { get; set; } 

        [Required]
        public bool CanAnnotate { get; set; } = true;

        [Required]
        public bool CanShare { get; set; } = false;

        public double? MonthlyPrice { get; set; } = null;

        [Required]
        public bool IsActive { get; set; } = true;

        [InverseProperty("Plan")]
        public ICollection<User>? Users { get; set; }
    }
}