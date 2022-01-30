using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OTTER
{
    public partial class Razina : Form
    {

        string Imeigraca;
        int BrojBodova;

        public Razina(string imeigraca, int bodoviigraca)
        {
            this.Imeigraca = imeigraca;
            this.BrojBodova = bodoviigraca;
            InitializeComponent();
        }

        public string razina;
        public string tekstPitanja;
        public List<string> odgovori;

        public Form OdabirIgraca = null;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            razina = "Quick_Math";
            BGL bgl = new BGL(Imeigraca, BrojBodova, razina, tekstPitanja, odgovori);
            BGL.allSprites.Clear();
            this.Hide();
            bgl.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            razina = "Logical";
            BGL bgl = new BGL(Imeigraca, BrojBodova, razina, tekstPitanja, odgovori);
            BGL.allSprites.Clear();
            this.Hide();
            bgl.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            razina = "About_Math";
            BGL bgl = new BGL(Imeigraca, BrojBodova, razina, tekstPitanja, odgovori);
            BGL.allSprites.Clear();
            this.Hide();
            bgl.Show();

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label4.Text = "Instructions: Drag the Einstein icon located in the upper left corner to the correct answer.";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label4.Text = "Instructions: Drag the Einstein icon located in the upper left corner to the correct answer.";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label4.Text = "Instructions: Drag the Einstein icon located in the upper left corner to the correct answer.";
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void Razina_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(OdabirIgraca != null)
            {
                OdabirIgraca.Show();
            }
        }
    }
}
