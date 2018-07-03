using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Celownik : Słowo
    {
        public Celownik(Mianownik mianownik)
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
                if (Text[l - 2] == 'c')
                {
                    ReplaceLast("y");
                }
                else if (Text[l - 2] == 'd')
                {
                    ReplaceLast("zie");
                }
                else if (Text[l - 2] == 'k')
                {
                    ReplaceSecondLast('c');
                    ReplaceLast('e');
                }
                else if (Text[l - 2] == 'r')
                {
                    ReplaceLast("ze");
                }
                else if (Text[l - 2] == 't')
                {
                    ReplaceSecondLast('c');
                    ReplaceLast("ie");
                }
                else
                {
                    ReplaceLast("ie");
                }
            }
            else if (Text.Last() == 'ć')
            {
                ReplaceLast("ci");
            }
            else if (Text.Last() == 'e')
            {
                ReplaceLast('u');
            }
            else if (Text.Last() == 'o')
            {
                ReplaceLast('u');
            }
            else
            {
                Text += "owi";
            }
        }
    }
}
