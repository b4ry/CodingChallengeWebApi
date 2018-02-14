using KnockKnockReadifyChallenge.Services.Wrappers;
using System;

namespace KnockKnockReadifyChallenge.Services.ReverseWords
{
    public class ReverseWordsService : IReverseWordsService
    {
        private IMemoryCacheWrapper _memoryCacheWrapper;

        public ReverseWordsService(IMemoryCacheWrapper memoryCacheWrapper)
        {
            _memoryCacheWrapper = memoryCacheWrapper;
        }

        public string ReverseWords(string words)
        {
            return string.Empty;
        }
    }
}
