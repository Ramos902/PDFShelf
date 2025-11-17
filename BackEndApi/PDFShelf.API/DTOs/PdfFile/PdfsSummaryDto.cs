
namespace PDFShelf.Api.DTOs
{
    public class PdfsSummaryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public double FileSizeMB { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}