using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDFShelf.Api.DTOs
{
    public class PdfUpdateDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(255, ErrorMessage = "O título não pode exceder 255 caracteres.")]
        public string Title { get; set; } = string.Empty;
    }
}