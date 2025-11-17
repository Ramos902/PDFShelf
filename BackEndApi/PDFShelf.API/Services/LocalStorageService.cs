namespace PDFShelf.Api.Services
{
    public class LocalStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _uploadDirectory;

        public LocalStorageService(IWebHostEnvironment env)
        {
            _env = env;
            // Define o caminho para a pasta 'uploads' dentro de 'wwwroot'
            _uploadDirectory = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");

            // Garante que a pasta exista
            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, string storagePath)
        {
            // 'storagePath' será algo como "userId/guid_filename.pdf"
            // Vamos garantir que os diretórios existam
            var fullPath = Path.Combine(_uploadDirectory, storagePath);
            var directory = Path.GetDirectoryName(fullPath);

            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Salva o arquivo no disco
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retorna o caminho *relativo* que o endpoint salvará no banco
            return storagePath; 
        }

        public Task DeleteFileAsync(string filePath)
        {
            var fullPath = Path.Combine(_uploadDirectory, filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            return Task.CompletedTask;
        }
    }
}