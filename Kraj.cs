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
    public partial class Kraj : Form
    {
        public string _ime;
        public int _bodovi;
        public Kraj(string i, int b)
        {
            _ime = i;
            _bodovi = b;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string datoteka = "igraci.txt";

        private void Kraj_Load(object sender, EventArgs e)
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }

        private void Kraj_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
