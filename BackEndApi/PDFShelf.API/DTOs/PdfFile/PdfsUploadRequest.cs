using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc; // <-- Adicione este using

namespace PDFShelf.Api.DTOs
{
    public class PdfUploadRequest
    {
        [Required]
        public IFormFile File { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;
    }
}