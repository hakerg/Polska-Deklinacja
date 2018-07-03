using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Mianownik : Słowo
    {
        public Mianownik(string noun)
        {
            Text = noun;
        }

        public string GetNumberForm(double number)
        {
            if (number == 1)
            {
                return Text;
            }
            else if ((number % 100 < 10 || number % 100 > 20) && (number % 10 >= 2 && number % 10 <= 4))
            {
                return new Mianownik_M(this).Text;
            }
            else
            {
                return new Dopełniacz_M(this).Text;
            }
        }

        public string GetNumberForm(string number_string)
        {
            int number = 0;
            if (number_string.Length <= 2) Int32.TryParse(number_string, out number);
            else Int32.TryParse(number_string.Substring(number_string.Length - 2, 2), out number);
            if (number == 1 && number_string.Length == 1)
            {
                return Text;
            }
            else if ((number < 10 || number > 20) && (number >= 2 && number <= 4))
            {
                return new Mianownik_M(this).Text;
            }
            else
            {
                return new Dopełniacz_M(this).Text;
            }
        }

        public Rodzaj JakiRodzaj()
        {
            if (Text.Length == 0) return Rodzaj.Męski;
            if (Text.Last() == 'a' || (Text[Text.Length - 2] == 'e' && Text.Last() == 'w') || Text.Last() == 'i') return Rodzaj.Żeński;
            if (Text.Last() == 'o' || Text.Last() == 'e' || Text.Last() == 'ę' || (Text[Text.Length - 2] == 'u' && Text.Last() == 'm')) return Rodzaj.Nijaki;
            return Rodzaj.Męski;
        }
    }
}
