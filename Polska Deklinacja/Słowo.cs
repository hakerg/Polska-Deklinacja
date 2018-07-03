using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Słowo
    {
        public enum Rodzaj { Męski, Żeński, Nijaki, Męskoosobowy, Niemęskoosobowy };
        public enum Przypadek { Mianownik, Dopełniacz, Celownik, Biernik, Miejscownik, Narzędnik, Wołacz };

        public string Text;

        public static Rodzaj LiczbaMnoga(Rodzaj rodzaj)
        {
            if (rodzaj == Rodzaj.Męski || rodzaj == Rodzaj.Nijaki) return Rodzaj.Męskoosobowy;
            else return Rodzaj.Niemęskoosobowy;
        }

        public void ReplaceLast(char letter)
        {
            Text = Text.Substring(0, Text.Length - 1) + letter;
        }

        public void ReplaceLast(string letters)
        {
            Text = Text.Substring(0, Text.Length - 1) + letters;
        }

        public void ReplaceSecondLast(char letter)
        {
            char[] chars = Text.ToCharArray();
            chars[Text.Length - 2] = letter;
            Text = new string(chars);
        }

        public string GetLast(int count)
        {
            return Text.Substring(Text.Length - count);
        }

        public bool IsName()
        {
            return Char.IsUpper(Text.First());
        }
    }
}
