using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Wołacz : Słowo
    {
        public Wołacz(Mianownik mianownik)
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
                ReplaceLast('o');
            }
            else if (Text.Last() == 'ć')
            {
                ReplaceLast("ci");
            }
            else if (Text.Last() == 'd')
            {
                Text += "zie";
            }
            else if (Text.Last() == 'e' || Text.Last() == 'o')
            {
                ReplaceLast('u');
            }
            else if (Text.Last() == 'r')
            {
                Text += "ze";
            }
            else if (Text.Last() == 'n' || Text.Last() == 's' || Text.Last() == 'z')
            {
                Text += "ie";
            }
            else if (Text.Last() == 't')
            {
                ReplaceLast("cie");
            }
            else
            {
                Text += 'u';
            }
        }
    }
}
