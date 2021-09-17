using SanitizationService.SanitizationService.Core.Entities.AbcSanitizer;
using SanitizationService.SanitizationService.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace SanitizationService.SanitizationService.Core.Services
{
    public class FileSanitizersFactory
    {
        private static readonly Dictionary<string, Func<IFileSanitizer>> _fileSanitizers = new Dictionary<string, Func<IFileSanitizer>>()
        {
            { ".abc", () => new AbcSanitizer()}
        };

        public static IFileSanitizer CreateSanitizer(string sanitizerType)
        {
            return _fileSanitizers[sanitizerType]();
        }

        public static bool IsTypeSupported(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return false;

            return _fileSanitizers.TryGetValue(type, out var factory);
        }
    }
}