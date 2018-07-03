using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Dopełniacz_M : Słowo
    {
        public Dopełniacz_M(Mianownik mianownik)
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
            else if (Text[l - 2] == 'k')
            {
                Text = Text.Insert(l - 2, "e");
            }
            l = Text.Length;

            if (Text.Last() == 'a')
            {
                Text = Text.Substring(0, l - 1);
            }
            else if (Text.Last() == 'c' && Text[l - 2] == 'ą')
            {
                ReplaceSecondLast('ę');
                ReplaceLast("cy");
            }
            else
            {
                Text += "ów";
            }
        }
    }
}
