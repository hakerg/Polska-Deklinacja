using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Narzędnik : Słowo
    {
        public Narzędnik(Mianownik mianownik)
        {
            Text = mianownik.Text;
            var l = Text.Length;
            if (l < 2) return;

            if (Text[l - 2] == 'e')
            {
                if (Text.Last() == 'j') { }
                else
                {
                    Text = Text.Remove(l - 2, 1);
                }
            }
            else if (Text[l - 2] == 'ó')
            {
                ReplaceSecondLast('o');
            }
            l = Text.Length;

            if (Text.Last() == 'a')
            {
                ReplaceLast('ą');
            }
            else if (Text.Last() == 'ć')
            {
                ReplaceLast("cią");
            }
            else if (Text.Last() == 'e')
            {
                Text += 'm';
            }
            else if (Text.Last() == 'g' || Text.Last() == 'k')
            {
                Text += "iem";
            }
            else if (Text.Last() == 'o')
            {
                ReplaceLast("em");
            }
            else
            {
                Text += "em";
            }
        }
    }
}
