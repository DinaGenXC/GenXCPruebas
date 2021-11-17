using GenXCPruebas.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenXCPruebas
{
    public partial class Form1 : Form
    {
        Forms.FormPruebaSQlite fPruebasqlite = new Forms.FormPruebaSQlite();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            fPruebasqlite.Show();
           // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyCarpetasArchivos form = new CopyCarpetasArchivos();
            form.Show();
            this.Hide();
        }
    }
}
