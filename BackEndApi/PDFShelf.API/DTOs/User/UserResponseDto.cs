namespace PDFShelf.Api.DTOs;

public record UserResponseDto(
    int Id,
    string Name,
    string Email,
    string Role,
    double UsedStorageMB,
    int PlanId,
    string Token // JWT retornado ao logar/registrar
);
