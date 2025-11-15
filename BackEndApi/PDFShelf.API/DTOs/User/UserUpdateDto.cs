namespace PDFShelf.Api.DTOs;

public record UserUpdateDto {
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
};
