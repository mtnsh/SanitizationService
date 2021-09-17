using System.Threading.Tasks;

namespace SanitizationService.SanitizationService.Core.Interfaces
{
    public interface ISanitizationService
    {
        Task SanitizeFile(string path);
        bool IsSupportedFile(string filePath);
    }
}
