using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    public class SpellChecker
    {
        public static string CheckText(string text, string[] dict)
        {
            int alpha = 0, nonAlpha = 0;
            string result = "";
            for (int i = 0; i<text.Length; i++)
            {
                
            }
            return result;
        }
        /**
         * Для заданного слова word с учетом словаря корректных слов dict ыозвращает
         * это слово, если оно корректно, либо список возможных замен
         */
        public static string CheckWord(string word, string[] dict)
        {
            if (word.Length > 50) return "{" + word + "?}"; // по условию, длина слова не больше 50, поэтому тест на дурака (если не сделать, CanReplace может зависнуть)
            string lWord = word.ToLower();
            bool hasOneEditDistSubst = false;
            string substs = "{";
            foreach (string dictword in dict)
            {

                string lDict = dictword.ToLower();
                switch (CanReplace(lWord, lDict))
                {
                    case 0:
                        return dictword;
                    case 1:
                        if (!hasOneEditDistSubst)
                        {
                            hasOneEditDistSubst = true;
                            substs = "{";
                        }
                        substs += dictword + ", ";
                        break;
                    case 2:
                        if (!hasOneEditDistSubst)
                        {
                            substs += dictword + ", ";
                        }
                        break;
                    default: // -1
                        break;

                }
            }
            if (substs == "{")
                return "{" + word + "?}";
            else
                return substs.TrimEnd().Contains(" ") ? substs.Substring(0, substs.Length - 2) + "}" : substs.Substring(1, substs.Length - 3);
        }
        /**
         * Проверка, может ли проверяемое слово быть заменено на словарное с помощью не более чем двух правок.
         * Если да, возвращает минимальное число правок. Если нет, -1.
         * 
         * Параметры:
         * checkword: проверяемое слово
         * dictword: словарное слово
        */
        public static int CanReplace(string checkword, string dictword)
        {
            if (checkword.Length - dictword.Length > 2 || checkword.Length - dictword.Length < -2) return -1;
            if (checkword.Equals(dictword)) return 0;
            int len1 = checkword.Length, len2 = dictword.Length;
            int[,] editDistances = new int[len1+1, len2+1];
            for (int i = 0; i <= len1; i++)
                editDistances[i, 0] = i;
            for (int j = 0; j <= len2; j++)
                editDistances[0, j] = j;
            for (int i =1; i<=len1; i++)
                for (int j=1; j<=len2; j++)
                {
                    int editDistanceNoSub = Math.Min(editDistances[i, j - 1]+1, editDistances[i - 1, j]+1);
                    // замена символа стоит двух изменений
                    editDistances[i, j] = Math.Min(editDistanceNoSub, editDistances[i - 1, j - 1] + (checkword[i-1] == dictword[j-1] ? 0 : 2));
                    // проверка на присутствие двух подряд лишних (недостающих) букв
                    if (i == j && i>=2 && editDistances[i, i] - editDistances[i - 2, i - 2] == 4)
                            return -1;
                }
            // два пропущенных символа в конце слова
            if (editDistances[len1, len2] == 2 && (len1 > 2 && editDistances[len1 - 2, len2] == 0 ||len2>2 && editDistances[len1, len2 - 2] == 0))
                return -1;
            return editDistances[len1, len2] < 3? editDistances[len1, len2] : -1;
            
        }


    }
}
