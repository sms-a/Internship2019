using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class CorrectionsLogic : ICorrections
    {
        private readonly IDictionaryLogic _dictionaryLogic;
        private readonly IFormatStrings _formatStrings;

        public string Alphabet { get; set; }

        public CorrectionsLogic(IDictionaryLogic dictionaryLogic,IFormatStrings formatStrings,string alphabet)
        {
            _dictionaryLogic = dictionaryLogic;
            Alphabet = alphabet;
            _formatStrings = formatStrings;
        }

        public string Correct(string word)
        {
            // Found
            if (_dictionaryLogic.Contains(word)) return  word;
            // Changed
            if(Corrections(word, out var tmpList)) return _formatStrings.FormatStringsToFinalView(tmpList);
            //Not Found
            return _formatStrings.FormatStringToUnknown(word);
        }

        private IEnumerable<string> GetEditsEnumerable(string word)
        {
            var splits = from i in Enumerable.Range(0, word.Length)
                select new { a = word.To(i), b = word.From(i) };

            var enumerable = splits.ToArray();

            var deletes = from s in enumerable
                where s.b != "" 
                select s.a + s.b.From(1);

            var inserts = from s in enumerable
                from c in Alphabet
                select s.a + c + s.b;

            return deletes.Union(inserts);
        }

        private bool Corrections(string word, out IEnumerable<string> outputEnumerable)
        {
            var editsEnumerable = GetEditsEnumerable(word);

            // 1 Edit
            var firstEdits = _dictionaryLogic.GetKnownWordsInDictionary(editsEnumerable);
            if (firstEdits.Any())
            {
                outputEnumerable = firstEdits.Distinct();
                return true;
            }
                
            // 2 Edit
            var secondEdits = from w1Edit in editsEnumerable
                from w2Edit in GetEditsEnumerable(w1Edit) 
                where _dictionaryLogic.Contains(w2Edit) 
                select w2Edit;
            if (secondEdits.Any())
            {
                outputEnumerable = secondEdits.Distinct();
                return true;
            }

            outputEnumerable = null;
            return false;
        }
    }
}
