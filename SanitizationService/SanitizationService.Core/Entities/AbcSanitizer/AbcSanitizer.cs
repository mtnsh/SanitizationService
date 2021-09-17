using SanitizationService.SanitizationService.Core.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SanitizationService.SanitizationService.Core.Entities.AbcSanitizer
{
    public sealed class AbcSanitizer :IFileSanitizer
    {
        public async Task Sanitize(string path)
        {
            var content = await File.ReadAllTextAsync(path);

            if (!content.StartsWith("123") || !content.EndsWith("789"))
                throw new Exception("incompatible file structure.");

            var numOfBlocksToSanitize = (content.Length / AbcBlock.BlockSize) - 2;
            var abcBlock = new AbcBlock();
            var badBlockReplacement = "A255C".ToCharArray();
            var sanitizedFile = new StringBuilder("123");

            for (var i = 1; i <= numOfBlocksToSanitize; i++)
            {
                abcBlock.SetBlock(content.Substring(i * AbcBlock.BlockSize, AbcBlock.BlockSize));
                sanitizedFile.Append(abcBlock.IsValid ? abcBlock.GetBlock() : badBlockReplacement);
            }

            sanitizedFile.Append("789");
            await File.WriteAllTextAsync(path, sanitizedFile.ToString());
        }
    }
}
