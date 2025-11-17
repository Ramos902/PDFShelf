namespace PDFShelf.Api.Services
{
    /// <summary>
    /// Abstração para salvar arquivos. Permite trocar
    /// o armazenamento local por Azure/S3 no futuro.
    /// </summary>
    public interface IFileStorageService
    {
        /// <summary>
        /// Salva um arquivo e retorna o caminho (ou nome do blob).
        /// </summary>
        /// <param name="file">O arquivo (IFormFile) vindo do request.</param>
        /// <param name="storagePath">O caminho/identificador único (ex: "userId/guid.pdf")</param>
        /// <returns>O caminho final onde o arquivo foi salvo.</returns>
        Task<string> SaveFileAsync(IFormFile file, string storagePath);

        /// <summary>
        /// Deleta um arquivo (usado se o "soft delete" for revertido ou para limpeza).
        /// </summary>
        /// <param name="filePath">O caminho/identificador do arquivo.</param>
        Task DeleteFileAsync(string filePath);
    }
}