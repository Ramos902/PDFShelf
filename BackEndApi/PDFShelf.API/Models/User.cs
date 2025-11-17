using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDFShelf.Api.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "A role é obrigatória.")]
        [MaxLength(50)]
        public string Role { get; set; } = "User";
        
        [Required]
        public int PlanId { get; set; } = 1; 

        [ForeignKey("PlanId")]
        public Plan? Plan { get; set; }
        
        [Required]
        public double UsedStorageMB { get; set; } = 0.0;
        
        [Required]
        public bool IsActive { get; set; } = true;
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? LastLogin { get; set; } // Nullable, não é obrigatório

        // --- Propriedades de Navegação (Relações) ---
        
        // CORREÇÃO: O tipo da coleção é "Pdf", não "Pdfs"
        // [InverseProperty] diz ao EF qual propriedade no modelo "Pdf"
        // aponta de volta para este User (no caso, a propriedade "User")
        [InverseProperty("User")]
        public ICollection<Pdfs>? Pdfs { get; set; }

        /*
        [InverseProperty("User")]
        //public ICollection<PdfAnnotation>? PdfAnnotations { get; set; }

        [InverseProperty("SharedByUser")]
        public ICollection<Share>? SharesGiven { get; set; }

        [InverseProperty("SharedWithUser")]
        public ICollection<Share>? SharesReceived { get; set; }
        */
    }
}