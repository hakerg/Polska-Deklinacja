using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Dopełniacz : Słowo
    {
        public Dopełniacz(Mianownik mianownik)
        {
            Text = mianownik.Text;
            var l = Text.Length;
            if (l < 2) return;
            
            if (Text[l - 2] == 'e')
            {
                if (Text.Last() == 'j') {}
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
                if (Text[l - 2] == 'i' || Text[l - 2] == 'k' || Text[l - 2] == 'l')
                {
                    ReplaceLast('i');
                }
                else
                {
                    ReplaceLast('y');
                }
            }
            else if (Text.Last() == 'ć')
            {
                ReplaceLast("ci");
            }
            else if (Text.Last() == 'n' || Text.Last() == 's' || Text.Last() == 't')
            {
                Text += 'u';
            }
            else if (Text.Last() == 'e' || Text.Last() == 'o')
            {
                ReplaceLast('a');
            }
            else if (Text.Last() == 'w')
            {
                Text = Text.Remove(l - 2, 1);
                Text += 'i';
            }
            else
            {
                Text += 'a';
            }
        }
    }
}
