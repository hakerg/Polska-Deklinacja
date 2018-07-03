using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Celownik_M : Słowo
    {
        public Celownik_M(Mianownik mianownik)
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
                ReplaceLast("om");
            }
            else
            {
                Text += "om";
            }
        }
    }
}
