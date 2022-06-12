using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SensitiveWord.Api.SensitiveWord.BL
{
    public class BloopSensetiveWords
    {
        internal string BloobWords(List<string> listOfWords, string aword)
        {
            listOfWords = listOfWords.ConvertAll(s => s.ToLower());

            foreach (var word in listOfWords)
            {
                var pattern = $@"\b{word}\b";
                aword = Regex.Replace(aword, pattern, BloobSensitiveWordslist(word), RegexOptions.IgnoreCase);
            }
            return aword;
        }
        internal string BloobSensitiveWordslist(string word)
        {
            var bleepedWord = "";

            for (var i = 0; i < word.Length; i++) bleepedWord += "*";

            return bleepedWord;
        }
    }
}
