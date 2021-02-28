using Application.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileService : IFileService
    {
        private readonly string filePath =
            Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Reports/");

        public async Task Write(string text)
        {
            await File.WriteAllTextAsync(filePath, text);
        }

    }
}
