using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PDFShelf.Api.Models; 

namespace PDFShelf.Api.Models
{
    // O nome da classe "Pdf" (singular) está correto.
    public class Pdfs
    {
        // --- CHAVE PRIMÁRIA (PK) ---
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(255)] // Um bom tamanho para títulos
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)] // Nomes de arquivo originais podem ser longos
        public string OriginalFileName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O caminho do arquivo é obrigatório.")]
        [MaxLength(1024)] // Para caminhos de S3 ou Azure Blob
        public string FilePath { get; set; } = string.Empty;
        
        [MaxLength(64)] // Para um hash SHA-256 (64 caracteres)
        public string FileHash { get; set; } = string.Empty;
        
        [Required]
        public double FileSizeMB { get; set; }
        
        [Required]
        public int PageCount { get; set; }
        
        [MaxLength(2048)] // URLs de thumbnail podem ser longas
        public string ThumbnailUrl { get; set; } = string.Empty;
        
        [Required]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        
        [Required]
        public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;
        
        [Required]
        public bool IsDeleted { get; set; } = false;
        
        public DateTime? DeletedAt { get; set; } 

        // --- CHAVE ESTRANGEIRA (FK) ---
        
        [Required]
        public Guid UserId { get; set; } 
        
        public User User { get; set; } = null!;
    }
}