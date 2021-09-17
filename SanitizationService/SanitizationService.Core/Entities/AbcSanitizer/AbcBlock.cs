using System;
using System.Linq;

namespace SanitizationService.SanitizationService.Core.Entities.AbcSanitizer
{
    public class AbcBlock
    {
        internal const int BlockSize = 3;
        private readonly char[] _block = new char[BlockSize];
        private readonly char[] _allowedWildCards = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public char[] GetBlock()
        {
            return _block;
        }

        public void SetBlock(string str)
        {
            if (!string.IsNullOrWhiteSpace(str) && str.Length <= BlockSize)
            {
                Array.Copy(str.ToCharArray(), _block, BlockSize);
            }
        }

        public bool IsValid =>
            _block[0] == 'A'
            && _block[2] == 'C'
            && _allowedWildCards.Contains(_block[1]);
    }
}
