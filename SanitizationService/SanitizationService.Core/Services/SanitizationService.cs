using SanitizationService.SanitizationService.Core.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SanitizationService.SanitizationService.Core.Services
{
    public class SanitizationService : ISanitizationService
    {
        public async Task SanitizeFile(string path)
        {
            var extension = Path.GetExtension(path);
            var fileSanitizer = FileSanitizersFactory.CreateSanitizer(extension);
            await fileSanitizer.Sanitize(path);
        }

        public bool IsSupportedFile(string filePath)
        {
            var type = Path.GetExtension(filePath);
            return FileSanitizersFactory.IsTypeSupported(type);
        }
    }
}
