
namespace PDFShelf.Api.DTOs
{
    public class PdfsDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public double FileSizeMB { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        
    }
}