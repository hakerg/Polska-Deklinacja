using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Mianownik_M : Słowo
    {
        public Mianownik_M(Mianownik mianownik)
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
            l = Text.Length;

            if (Text.Last() == 'a')
            {
                if (Text[l - 2] == 'i')
                {
                    ReplaceLast('e');
                }
                else if (Text[l - 2] == 'k')
                {
                    ReplaceLast('i');
                }
                else
                {
                    ReplaceLast('y');
                }
            }
            else if (Text.Last() == 'c' || Text.Last() == 'l')
            {
                Text += 'e';
            }
            else if (Text.Last() == 'k' && !IsName())
            {
                Text += 'i';
            }
            else if (Text.Last() == 'o')
            {
                ReplaceLast('a');
            }
            else if (IsName())
            {
                Text += "owie";
            }
            else
            {
                Text += 'y';
            }
        }
    }
}
