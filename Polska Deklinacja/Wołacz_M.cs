using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Wołacz_M : Słowo
    {
        public Wołacz_M(Mianownik mianownik)
        {
            Text = new Mianownik_M(mianownik).Text;
        }
    }
}
