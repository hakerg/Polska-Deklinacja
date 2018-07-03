using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polska_Deklinacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Liczba_Button_Click(object sender, EventArgs e)
        {
            Mianownik m = new Mianownik(Rzeczownik_L_Textbox.Text);
            if (WykluczPotęgi_CheckBox.Checked)
            {
                int pow = Liczba.MaxPower;
                if (Int32.TryParse(WykluczonePotęgi_TextBox.Text, out pow))
                {
                    Liczba_Label.Text = "Słownie: " + new Liczba(Liczba_TextBox.Text, m.JakiRodzaj(), pow).Text + ' ' + m.GetNumberForm(Liczba_TextBox.Text);
                }
                else
                {
                    MessageBox.Show("Potęga musi być liczbą o wartości od 3 do 603 " + Liczba.MaxPower.ToString());
                }
            }
            else
            {
                Liczba_Label.Text = "Słownie: " + new Liczba(Liczba_TextBox.Text, m.JakiRodzaj()).Text + ' ' + m.GetNumberForm(Liczba_TextBox.Text);
            }
        }

        private void WypełnijPrzypadki_Button_Click(object sender, EventArgs e)
        {
            var s = new Mianownik(Mianownik_TextBox.Text);
            Dopełniacz_TextBox.Text = new Dopełniacz(s).Text;
            Celownik_TextBox.Text = new Celownik(s).Text;
            Biernik_TextBox.Text = new Biernik(s).Text;
            Narzędnik_TextBox.Text = new Narzędnik(s).Text;
            Miejscownik_TextBox.Text = new Miejscownik(s).Text;
            Wołacz_TextBox.Text = new Wołacz(s).Text;

            Mianownik_M_TextBox.Text = new Mianownik_M(s).Text;
            Dopełniacz_M_TextBox.Text = new Dopełniacz_M(s).Text;
            Celownik_M_TextBox.Text = new Celownik_M(s).Text;
            Biernik_M_TextBox.Text = new Biernik_M(s).Text;
            Narzędnik_M_TextBox.Text = new Narzędnik_M(s).Text;
            Miejscownik_M_TextBox.Text = new Miejscownik_M(s).Text;
            Wołacz_M_TextBox.Text = new Wołacz_M(s).Text;

            if (PrzymiotnikCheckBox.Checked)
            {
                if (PrzymiotnikTextBox.Text.Length < 2)
                {
                    MessageBox.Show("Przymiotnik jest za krótki");
                }
                else
                {
                    var p = new Przymiotnik(PrzymiotnikTextBox.Text);
                    Słowo.Rodzaj r = s.JakiRodzaj();
                    Dopełniacz_TextBox.Text = Dopełniacz_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Dopełniacz, r) + ' ');
                    Celownik_TextBox.Text = Celownik_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Celownik, r) + ' ');
                    Biernik_TextBox.Text = Biernik_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Biernik, r) + ' ');
                    Narzędnik_TextBox.Text = Narzędnik_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Narzędnik, r) + ' ');
                    Miejscownik_TextBox.Text = Miejscownik_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Miejscownik, r) + ' ');
                    Wołacz_TextBox.Text = Wołacz_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Wołacz, r) + ' ');

                    r = Słowo.LiczbaMnoga(r);
                    Mianownik_M_TextBox.Text = Mianownik_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Mianownik, r) + ' ');
                    Dopełniacz_M_TextBox.Text = Dopełniacz_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Dopełniacz, r) + ' ');
                    Celownik_M_TextBox.Text = Celownik_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Celownik, r) + ' ');
                    Biernik_M_TextBox.Text = Biernik_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Biernik, r) + ' ');
                    Narzędnik_M_TextBox.Text = Narzędnik_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Narzędnik, r) + ' ');
                    Miejscownik_M_TextBox.Text = Miejscownik_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Miejscownik, r) + ' ');
                    Wołacz_M_TextBox.Text = Wołacz_M_TextBox.Text.Insert(0, p.Odmień(Słowo.Przypadek.Wołacz, r) + ' ');
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    this.AcceptButton = WypełnijPrzypadki_Button;
                    break;
                case 1:
                    this.AcceptButton = Liczba_Button;
                    break;
            }
        }

        private void WykluczPotęgi_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WykluczonePotęgi_TextBox.Enabled = WykluczPotęgi_CheckBox.Checked;
        }

        private void PrzymiotnikCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PrzymiotnikTextBox.Enabled = PrzymiotnikCheckBox.Checked;
        }
    }
}
