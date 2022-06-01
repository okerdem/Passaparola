using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passaparola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int iSoruNo = 1, iDogru = 0, iYanlis = 0, iSayac = 0;
        string[] cevapAnahtari = { "", "Akdeniz", "Karadeniz" };
        string[] sorular = { "", "Ülkemizin güneyindeki kıyı bölgesi neredir ?", "Ülkemizin en çok ormanlık bölgesi hangisidir ?" };

        private void buttonSonraki_Click(object sender, EventArgs e)
        {
            iSoruNo++;
            soru(iSoruNo);
        }

        public void cevap(int x)
        {
            switch (x)
            {
                case 1:
                    if (textBox1.Text == cevapAnahtari[x])
                    {
                        buttonA.BackColor = Color.Green; iDogru++;
                    }
                    else
                    {
                        buttonA.BackColor = Color.Red; iYanlis++;
                    }
                    break;
                case 2:
                    if (textBox1.Text == cevapAnahtari[x])
                    {
                        buttonB.BackColor = Color.Green; iDogru++;
                    }
                    else
                    {
                        buttonB.BackColor = Color.Red; iYanlis++;
                    }
                    break;
            }

        }

        public void soru(int x)
        {
            switch (x)
            {
                case 1:
                    richTextBox1.Text = sorular[x];
                    buttonA.BackColor = Color.Yellow;
                    break;
                case 2:
                    richTextBox1.Text = sorular[x];
                    buttonB.BackColor = Color.Yellow;
                    break;
            }
        }

        private void buttonCevapla_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || buttonCevapla.Text == "Sonraki")
            {
                iSayac++;
                if (textBox1.Text != "")
                {
                    cevap(iSoruNo);
                    textBox1.Text = "";
                    buttonCevapla.Text = "Sonraki";
                }

                if (iSayac == (3 * iSoruNo))
                {
                    buttonCevapla.Text = "Cevapla";
                    iSoruNo++;
                    soru(iSoruNo);
                }

                labelDogru.Text = iDogru.ToString();
                labelYanlis.Text = iYanlis.ToString();
            }
            else if (textBox1.ReadOnly == false && textBox1.Text == "" && buttonCevapla.Text != "Sonraki")
            {
                MessageBox.Show("Lütfen bir yanıt giriniz.");
            }

            if (buttonCevapla.Text == "Başla")
            {
                textBox1.ReadOnly = false;
                buttonCevapla.Text = "Cevapla";
                soru(iSoruNo);
                iSayac++;
            }
        }
    }
}
