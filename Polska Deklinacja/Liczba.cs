using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polska_Deklinacja
{
    class Liczba : Słowo
    {
        public static readonly string[] cyfry = { "zero", "jeden",      "dwa",         "trzy",        "cztery",       "pięć",         "sześć",         "siedem",         "osiem",         "dziewięć" };
        public static readonly string[] nastki = {        "jedenaście", "dwanaście",   "trzynaście",  "czternaście",  "piętnaście",   "szesnaście",    "siedemnaście",   "osiemnaście",   "dziewiętnaście" };
        public static readonly string[] dziesiątki = {    "dziesięć",   "dwadzieścia", "trzydzieści", "czterdzieści", "pięćdziesiąt", "sześćdziesiąt", "siedemdziesiąt", "osiemdziesiąt", "dziewięćdziesiąt" };
        public static readonly string[] setki = {         "sto",        "dwieście",    "trzysta",     "czterysta",    "pięćset",      "sześćset",      "siedemset",      "osiemset",      "dziewięćset" };
        public static readonly Dictionary<int, string> e = new Dictionary<int, string>();

        public static readonly int MaxPower = 603;

        static Liczba()
        {
            e.Add(603, "centyliard");
            e.Add(600, "centylion");
            e.Add(483, "oktogiliard");
            e.Add(480, "oktogilion"); //out of max double's range
            e.Add(243, "kwadragiliard");
            e.Add(240, "kwadragilion");
            e.Add(183, "trycyliard");
            e.Add(180, "trycylion");

            e.Add(100, "googol");

            e.Add(75, "duodecyliard");
            e.Add(72, "duodecylion");
            e.Add(69, "undecyliard");
            e.Add(66, "undecylion");
            e.Add(63, "decyliard");
            e.Add(60, "decylion");
            e.Add(57, "noniliard");
            e.Add(54, "nonilion");
            e.Add(51, "oktyliard");
            e.Add(48, "oktylion");
            e.Add(45, "septyliard");
            e.Add(42, "septylion");
            e.Add(39, "sekstyliard");
            e.Add(36, "sekstylion");
            e.Add(33, "kwintyliard");
            e.Add(30, "kwintylion"); //out of max decimal's range
            e.Add(27, "kwadryliard");
            e.Add(24, "kwadrylion");
            e.Add(21, "tryliard");
            e.Add(18, "trylion");
            e.Add(15, "biliard");
            e.Add(12, "bilion");
            e.Add(9, "miliard");
            e.Add(6, "milion");
            e.Add(3, "tysiąc");
        }

        public Liczba(double liczba, Rodzaj rodzaj, int ExcludePowersOver = -1)
        {
            if (ExcludePowersOver == -1) ExcludePowersOver = MaxPower;
            bool ApplyOneForm = (liczba == 1);
            Text = "";
            foreach (KeyValuePair<int, string> v in e)
            {
                if (v.Key > ExcludePowersOver) continue;
                double power = Math.Pow(10, v.Key);
                if (double.IsInfinity(power)) continue;
                double t = Math.Floor(liczba / power);
                if (t == 1) Text += v.Value + ' ';
                else if (t > 0)
                {
                    Mianownik m = new Mianownik(v.Value);
                    Text += new Liczba(t, m.JakiRodzaj(), ExcludePowersOver).Text + ' ' + m.GetNumberForm(t) + ' ';
                }
                liczba -= t * power;
            }
            if (liczba >= 100)
            {
                double t = Math.Floor(liczba / 100);
                Text += setki[(int)t - 1] + ' ';
                liczba -= t * 100;
            }
            if (liczba >= 11 && liczba <= 19)
            {
                Text += nastki[(int)liczba - 11] + ' ';
            }
            else
            {
                if (liczba >= 10)
                {
                    double t = Math.Floor(liczba / 10);
                    Text += dziesiątki[(int)t - 1] + ' ';
                    liczba -= t * 10;
                }
                if (liczba > 0)
                {
                    if (ApplyOneForm)
                    {
                        if (rodzaj == Rodzaj.Żeński) Text += "jedna ";
                        else if (rodzaj == Rodzaj.Nijaki) Text += "jedno ";
                        else Text += cyfry[(int)liczba] + ' ';
                    }
                    else if (liczba == 2 && rodzaj == Rodzaj.Żeński) Text += "dwie ";
                    else Text += cyfry[(int)liczba] + ' ';
                }
            }
            if (Text.Length == 0) Text = cyfry[0];
            else Text = Text.Remove(Text.Length - 1);
        }

        public Liczba(string liczba, Rodzaj rodzaj, int ExcludePowersOver = -1)
        {
            if (ExcludePowersOver == -1) ExcludePowersOver = MaxPower;
            bool ApplyOneForm = (liczba == "1");
            int digits = liczba.Length;
            Text = "";
            foreach (KeyValuePair<int, string> v in e)
            {
                if (v.Key > ExcludePowersOver) continue;
                if (digits > v.Key)
                {
                    string t = liczba.Substring(0, digits - v.Key);
                    int n = 0;
                    int.TryParse(t.Last().ToString(), out n);
                    if (t.Length > 1 && t.First() != '0' || n > 2)
                    {
                        Mianownik m = new Mianownik(v.Value);
                        Text += new Liczba(t, m.JakiRodzaj(), ExcludePowersOver).Text + ' ' + m.GetNumberForm(t) + ' ';
                    }
                    else if (n == 1) Text += v.Value + ' ';
                    liczba = liczba.Substring(digits - v.Key);
                    digits = liczba.Length;
                }
            }
            int number;
            if (int.TryParse(liczba, out number))
            {
                if (number >= 100)
                {
                    int t = number / 100;
                    Text += setki[t - 1] + ' ';
                    number -= t * 100;
                }
                if (number >= 11 && number <= 19)
                {
                    Text += nastki[number - 11] + ' ';
                }
                else
                {
                    if (number >= 10)
                    {
                        int t = number / 10;
                        Text += dziesiątki[t - 1] + ' ';
                        number -= t * 10;
                    }
                    if (number > 0)
                    {
                        if (ApplyOneForm)
                        {
                            if (rodzaj == Rodzaj.Żeński) Text += "jedna ";
                            else if (rodzaj == Rodzaj.Nijaki) Text += "jedno ";
                            else Text += cyfry[number] + ' ';
                        }
                        else if (number == 2 && rodzaj == Rodzaj.Żeński) Text += "dwie ";
                        else Text += cyfry[number] + ' ';
                    }
                }
                if (Text.Length == 0) Text = cyfry[0];
                else Text = Text.Remove(Text.Length - 1);
            }
            else
            {
                Text = "(nieprawidłowa liczba)";
            }
        }
    }
}
