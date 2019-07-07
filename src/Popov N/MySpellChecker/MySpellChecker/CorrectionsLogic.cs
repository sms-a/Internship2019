using System.Collections.Generic;
using System.Linq;
using MySpellChecker.Interfaces;

namespace MySpellChecker
{
    public class CorrectionsLogic : ICorrections
    {
        private readonly IDictionaryLogic _dictionaryLogic;
        private readonly IFormatStrings _formatStrings;

        private struct StrEdit
        {
            public string str;
            public int indx;
            public bool isDelete;
        }

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
            // if(Corrections(word, out var tmpList)) return _formatStrings.FormatStringsToFinalView(tmpList); Corrections
            if (Corrections(word, out var tmpList)) return _formatStrings.FormatStringsToFinalView(tmpList);
            //Not Found
            return _formatStrings.FormatStringToUnknown(word);
        }

        private bool Corrections(string word, out IEnumerable<string> outputEnumerable)
        {
            var editsEnumerable = GetEditsEnumerable(word);

            // 1 Edit
            var firstEdits = _dictionaryLogic.GetKnownWordsInDictionary(getStringsEnumerable(editsEnumerable));
            if (firstEdits.Any())
            {
                outputEnumerable = firstEdits.Distinct();
                return true;
            }

            // 2 Edit
            var secondEdits = from w1Edit in editsEnumerable
                from w2Edit in InsertsEnumerable(w1Edit.str, w1Edit.indx, !w1Edit.isDelete).Union(DeletesEnumerable(w1Edit.str, w1Edit.indx, w1Edit.isDelete))
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

        private IEnumerable<StrEdit> GetEditsEnumerable(string word)
        {
            var splits = from i in Enumerable.Range(0, word.Length + 1)
                select new {a = word.To(i), b = word.From(i)};

            var enumerable = splits.ToArray();

            var deletes = from s in enumerable
                where s.b != ""
                select new StrEdit() {str = s.a + s.b.From(1),indx = s.a.Length, isDelete = true};

           var inserts = from s in enumerable
                from c in Alphabet
                select new StrEdit(){ str = (s.a + c + s.b), indx = s.a.Length};

            return deletes.Concat(inserts);
        }

        private IEnumerable<string> InsertsEnumerable(string word, int indx, bool isCorrect)
        {
            var splits = from i in Enumerable.Range(0, word.Length+1)
                select new { a = word.To(i), b = word.From(i) };
            if (isCorrect)
            {
                var inserts = from s in splits
                    from c in Alphabet
                    where s.a.Length != indx && s.a.Length != indx + 1
                    select s.a + c + s.b;
                return inserts;
            }
            else {
                var inserts = from s in splits
                    from c in Alphabet
                    select s.a + c + s.b;
                return inserts;
            }
        }

        private IEnumerable<string> DeletesEnumerable(string word, int indx, bool isCorrect)
        {
            var splits = from i in Enumerable.Range(0, word.Length+1)
                select new { a = word.To(i), b = word.From(i)};

            if (isCorrect)
            {
                var deletes = from s in splits
                    where s.b != "" && (s.a.Length!= indx && s.a.Length != indx - 1)
                    select s.a + s.b.From(1);
                return deletes;
            }
            else
            {
                var deletes = from s in splits
                              where s.b != ""
                    select s.a + s.b.From(1);
                return deletes;
            }
        }

        private IEnumerable<string> getStringsEnumerable(IEnumerable<StrEdit> strStructs)
        {
            return from strStruct in strStructs select strStruct.str;
        }
    }
}
