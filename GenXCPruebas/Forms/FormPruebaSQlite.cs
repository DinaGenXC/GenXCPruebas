using GenXCPruebas.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenXCPruebas.Forms
{
    public partial class FormPruebaSQlite : Form
    {
        PruebaSqlite PruebaSqlite = new PruebaSqlite();
        public FormPruebaSQlite()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cod;
                PruebaSqlite PruebaDB = new PruebaSqlite();                

                //cod = "INSERT INTO persona(nombre,edad) VALUES('" + txtNombre.Text + "','" + txtEdad.Text + "')";
                //PruebaSqlite.Set(cod);
                //MessageBox.Show("Insertado");

                cod = "INSERT INTO LastSettings(Layer,dest,draw) VALUES('" + txtNombre.Text + "','" + txtEdad.Text + "','true')";
                PruebaSqlite.Set(cod);
                //MessageBox.Show("Insertado");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cod = "SELECT * FROM persona";
                dataGridView1.DataSource = PruebaSqlite.Datatable1(cod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text.Trim())) { txtNombre.Focus(); MessageBox.Show("insert nombre que desea borrar"); return; }

                string cod = "DELETE FROM persona WHERE nombre='" + txtNombre.Text + "'";
                PruebaSqlite.Set(cod);
                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cod = "UPDATE persona set nombre='" + txtNombre.Text + "', edad='" + txtEdad.Text + "' where id ='4'";
                PruebaSqlite.Set(cod);
                MessageBox.Show("UPDATED");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PruebaSqlite.Conectar();
        }
    }
}
