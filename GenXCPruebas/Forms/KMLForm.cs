using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;
using Point3D = System.Windows.Forms.DataVisualization.Charting.Point3D;

namespace GenXCPruebas.Forms
{
    public partial class KMLForm : Form
    {
        public KMLForm()
        {
            InitializeComponent();
        }



        private void CargarKML()
        {
            txtFile.Text = "";
            ArrayList data = new ArrayList();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "KML Files|*.kml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = "";
                fileName = openFileDialog.FileName;
                txtFile.SelectionStart = openFileDialog.FileName.Length;


                using (var reader = new StreamReader(fileName))
                {
                    bool next = false;
                    ArrayList Lon = new ArrayList();
                    ArrayList Lat = new ArrayList();
                    while (!reader.EndOfStream)
                    {

                        List<Point3D> Lp3d = new List<Point3D>();
;
                        string line = reader.ReadLine();
                        if (next)
                        {
                            string[] ar;
                            next = false;
                            MessageBox.Show(line.ToString(), "line");

                            string[] Data = line.Trim().Split(' ');

                            foreach(string S in Data)
                            {
                                string[] data1 = line.Split(',');

                                Point3D point3D = new Point3D(line[0], line[1], line[2]);

                                Lp3d.Add(point3D);
                            }
                            
                            
                            foreach(Point3D P3 in Lp3d)
                            {
                                MessageBox.Show(P3.ToString());
                            }

                        }
                        else if (line.Contains("<coordinates>"))
                        {
                            if (line.Contains("</coordinates>"))
                            {
                                next = false;
                                MessageBox.Show("next is false, same line");
                                line = line.Remove(0, 17);
                                line = line.Remove(line.Length - 14, 14); //MessageBox.Show(line.ToString(), "complete");
                                string[] Data = line.Split(' ');
                                // Data = line.Split(',');
                               // Point3D p = new Point3D(Convert.ToDouble(Data[0]), Data[1], Data[2]);
                                for (int i = 0; i < Data.Length; i++)
                                {
                                    MessageBox.Show(Data[i].ToString(), "data2 __"); ;
                                }
                            }
                            else
                            { 
                                next = true;
                            }
                        }                     
                    }
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarKML();
        }
    }
}
