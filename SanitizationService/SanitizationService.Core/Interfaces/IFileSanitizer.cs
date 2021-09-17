using System.Threading.Tasks;

namespace SanitizationService.SanitizationService.Core.Interfaces
{
    public interface IFileSanitizer
    {
        Task Sanitize(string path);
    }
}
