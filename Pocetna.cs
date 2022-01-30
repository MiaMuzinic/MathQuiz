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
    public partial class Pocetna : Form
    {
        private string imeigraca;
        private int bodoviigraca;

        public Pocetna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();        
            var form2 = new OdabirIgraca();

            form2.Pocetna = this;
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
