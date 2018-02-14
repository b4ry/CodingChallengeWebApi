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

        public string ReverseWords(string sentence)
        {
            if (sentence == null)
            {
                sentence = string.Empty;
            }

            var cacheKey = $"ReverseWords:{sentence}";
            string result;

            if (!_memoryCacheWrapper.TryGetValue(cacheKey, out result))
            {
                result = Reverse(sentence);

                _memoryCacheWrapper.Set(cacheKey, result);
            }

            return result;
        }

        private string Reverse(string sentence)
        {
            var letters = sentence.ToCharArray();
            Array.Reverse(letters);

            return new string(letters);
        }
    }
}

