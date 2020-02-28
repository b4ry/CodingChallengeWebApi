using WebApiCodingChallenge.Services.Wrappers;
using System;

namespace WebApiCodingChallenge.Services.ReverseWords
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
            if (sentence == null || sentence == string.Empty)
            {
                return string.Empty;
            }

            var cacheKey = $"ReverseWords:{sentence}";
            var splitWords = sentence.Split(' ');
            string result;

            if (!_memoryCacheWrapper.TryGetValue(cacheKey, out result))
            {
                result = Reverse(splitWords);

                _memoryCacheWrapper.Set(cacheKey, result);
            }

            return result;
        }

        private string Reverse(string[] splitWords)
        {
            string reversedWords = string.Empty;
            bool first = true;

            foreach (var word in splitWords)
            {
                var letters = word.ToCharArray();
                Array.Reverse(letters);

                if (!first)
                {
                    reversedWords += " ";
                }

                reversedWords += new string(letters);
                first = false;
            }

            return reversedWords;
        }
    }
}

