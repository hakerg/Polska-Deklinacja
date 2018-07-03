using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Przymiotnik : Słowo
    {
        public Przymiotnik(string MianownikLPoj)
        {
            Text = MianownikLPoj;
            if (Text.Last() == 'a' || Text.Last() == 'e')
            {
                if (Text[Text.Length - 2] == 'i') Text = Text.Remove(Text.Length - 1);
                else ReplaceLast('y');
            }
        }

        public string Odmień(Przypadek przypadek, Rodzaj rodzaj)
        {
            string ret = Text;
            if (ret.Last() == 'y') ret = ret.Remove(ret.Length - 1);
            switch (przypadek)
            {
                case Przypadek.Mianownik:
                case Przypadek.Wołacz:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski: if (ret.Last() != 'i') ret += 'y'; break;
                        case Rodzaj.Żeński: ret += 'a'; break;
                        case Rodzaj.Nijaki: ret += 'e'; break;
                        case Rodzaj.Męskoosobowy:
                            if (ret.Last() == 'r') ret += "zy";
                            else if (ret.Last() == 'd') ret += "zi";
                            else ret += 'i';
                            break;
                        case Rodzaj.Niemęskoosobowy: ret += 'e'; break;
                    }
                    break;
                case Przypadek.Dopełniacz:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski: ret += "ego"; break;
                        case Rodzaj.Żeński: ret += "ej"; break;
                        case Rodzaj.Nijaki: ret += "ego"; break;
                        case Rodzaj.Męskoosobowy: ret += "ych"; break;
                        case Rodzaj.Niemęskoosobowy: ret += "ych"; break;
                    }
                    break;
                case Przypadek.Celownik:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski: ret += "emu"; break;
                        case Rodzaj.Żeński: ret += "ej"; break;
                        case Rodzaj.Nijaki: ret += "emu"; break;
                        case Rodzaj.Męskoosobowy: ret += "im"; break;
                        case Rodzaj.Niemęskoosobowy: ret += "im"; break;
                    }
                    break;
                case Przypadek.Biernik:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski:
                        case Rodzaj.Żeński:
                        case Rodzaj.Nijaki:
                        case Rodzaj.Męskoosobowy:
                        case Rodzaj.Niemęskoosobowy: break;
                    }
                    break;
                case Przypadek.Miejscownik:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski: ret += "ym"; break;
                        case Rodzaj.Żeński: ret += "ej"; break;
                        case Rodzaj.Nijaki: ret += "ym"; break;
                        case Rodzaj.Męskoosobowy: ret += "ich"; break;
                        case Rodzaj.Niemęskoosobowy: ret += "ich"; break;
                    }
                    break;
                case Przypadek.Narzędnik:
                    switch (rodzaj)
                    {
                        case Rodzaj.Męski: ret += "ym"; break;
                        case Rodzaj.Żeński: ret += "ą"; break;
                        case Rodzaj.Nijaki: ret += "ym"; break;
                        case Rodzaj.Męskoosobowy: ret += "ymi"; break;
                        case Rodzaj.Niemęskoosobowy: ret += "ymi"; break;
                    }
                    break;
            }
            return ret;
        }
    }
}
