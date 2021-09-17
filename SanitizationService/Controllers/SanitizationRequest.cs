using FluentValidation;
using System.IO;
using SanitizationService.SanitizationService.Core.Interfaces;

namespace SanitizationService.Controllers
{
    public class SanitizationRequest
    {
        public string Path { get; set; }
    }

    public class SanitizationRequestValidator : AbstractValidator<SanitizationRequest>
    {
        public SanitizationRequestValidator(ISanitizationService sanitizationService)
        {
            RuleFor(sr => sr.Path)
                .NotEmpty().WithMessage(sr=>$"{nameof(sr.Path)} can't be empty")
                .NotNull().WithMessage(sr=>$"{nameof(sr.Path)} can't be null")
                .Must(File.Exists).WithMessage("File not exists")
                .Must(sanitizationService.IsSupportedFile).WithMessage("Unsupported file type");
        }
    }
}
