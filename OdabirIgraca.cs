using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OTTER
{
    public partial class OdabirIgraca : Form
    {

        public OdabirIgraca()
        {
            InitializeComponent();
        }
        public string imeigraca = "Player";
        public int bodoviigraca = 0;
        public string datoteka = "igraci.txt";
        
        public Form Pocetna = null;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string tekst;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                imeigraca = textBox1.Text;
                bodoviigraca = 0;
            }
            if ( listBox1.SelectedIndex > -1)
            {
                tekst = listBox1.SelectedItem.ToString();
                var razdvoji = tekst.Split(' ');
                imeigraca = razdvoji[0];
                bodoviigraca = int.Parse(razdvoji[1]);
            }
            this.Hide();
            var form3 = new Razina(imeigraca, bodoviigraca);
            form3.OdabirIgraca = this;
            form3.Show();
        }

        private void OdabirIgraca_Load(object sender, EventArgs e)
        {
            if (!File.Exists(datoteka))
            {
                Console.WriteLine("Datoteka nije pronađena.");
            }

            using (StreamReader sr = File.OpenText(datoteka))
            {
                string linija = sr.ReadLine();
                while (linija != null)
                {
                    string[] niz = linija.Split(' ');
                    string igrac = niz[0];
                    int bodovi = int.Parse(niz[1]);
                    if (bodovi != 0)
                    {
                        listBox1.Items.Add(linija + "\n");
                    }
                    linija = sr.ReadLine();
                }
            }
        }

        private void OdabirIgraca_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Pocetna != null)
            {
                Pocetna.Show();
            }
           
        }
    }
}
