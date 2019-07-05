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
            throw new NotImplementedException("Функциональность проверки текста будет реализована позднее");
        }
        public static string CheckWord(string word, string[] dict)
        {
            foreach (string dictword in dict)
                if (word.Equals(dictword, StringComparison.CurrentCultureIgnoreCase))
                    return word;
            return "";
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
