using Autodesk.AutoCAD.Geometry;
using GenXCPruebas.Clases;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenXCPruebas.Clases;

namespace GenXCPruebas.Forms
{
    public partial class FormDbPgAdmin : Form
    {
        //public NpgsqlConnection conn = new NpgsqlConnection("Username = postgres; Password = 1234; Host = localhost; Port = 5432; Database = DewinGym");
        public NpgsqlConnection conn = new NpgsqlConnection("Username = postgres; Password = GenXC2020; Host = famdt.synology.me; Port = 5432; Database = GenXC_Project_Data");
        #region
        string geom = "";
        List<String> ListTables = new List<string>();
        double[] latArray;
        double[] lonArray;
        string SchemaC = "";
        string StringName = "";
        string filename;

        string BasDirParInt = "https://services.arcgis.com/LBbVDC0hKPAnLRpO/arcgis/rest/services/parcels_2020/FeatureServer/0/query?where=1%3D1&outFields=*&geometry=";
        string BasDirParEnd = "&geometryType=esriGeometryEnvelope&inSR=4326&spatialRel=esriSpatialRelContains&outSR=4326&f=json";
        #endregion

        Clases.Class1.Point p = new Class1.Point();
        public FormDbPgAdmin()
        {
            InitializeComponent();
            try
            {
                conn.Open();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        public DataTable ComandoSql(string query)
        {
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public void ReadKml()
        {
            bool next = false; int c = 0;
            bool name = false; geom = "";

            using (var reader = new StreamReader(filename))
            {
                ArrayList Lon = new ArrayList();
                ArrayList Lat = new ArrayList();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("<Folder>"))
                    {
                        name = true;
                    }
                    if (line.Contains("<name>") && name)
                    {
                        StringName = p.getBetween(line, "<name>", "</name>");
                        name = false;
                        if (StringName.Contains("_GXC"))
                        {
                            StringName = StringName.Remove(StringName.Length - 4, 4);
                        }
                    }

                    if (line.Contains("<coordinates>"))
                    {
                        next = true; c++;
                    }

                    else if (next)
                    {
                        geom = "";
                        string[] data = line.Split(' ');

                        foreach (string a in data)
                        {
                            string s = a.Replace(',', ' ');
                            //s = s + " 0";
                            geom += s + ","; 
                        }

                        next = false;
                        geom = geom.Remove(geom.Length - 4, 4); //richTextBox1.Text = geom;

                        string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = \'" + SchemaC + "\'";

                        DataTable dt = new DataTable();
                        dt = ComandoSql(query);
                        foreach (DataRow row in dt.Rows)
                        {
                            ListTables.Add(row["table_name"].ToString());
                        }

                        if (!ListTables.Contains("" + StringName.Trim() + ""))
                        {
                            string queryCreate = "CREATE TABLE IF NOT EXISTS \"" + SchemaC.Trim() + "\".\"" + StringName.Trim() + "\"(id SERIAL PRIMARY KEY, geom geometry, client integer, project character varying, userId integer, time timestamp without time zone, status integer)";
                            ComandoSql(queryCreate);
                        }

                        string queryInsert = "INSERT INTO \"" + SchemaC + "\".\"" + StringName + "\"(geom, client, project, userId, time, status)VALUES((SELECT ST_GeomFromText('LINESTRING(" + geom + ")', 4326)), '002', 'ASD451F','04', current_timestamp, 1)";
                        //Sustituir cuando este lista la db y controlar que no esten vacios los campos 
                        //string queryInsert = "INSERT INTO \"" + SchemaC + "\".\"" + StringName + "\"(geom, client, project, userId, time, status)VALUES((SELECT ST_GeomFromText('LINESTRING(" + geom + ")', 4326)), '"+cboClient.Text +"', '"+txtProjectName.Text+"','"+txtUserId.Text+"', current_timestamp, 1)";
                        ComandoSql(queryInsert);
                    }
                }
            }
            MessageBox.Show("Upload completed.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindState();
        }

        public double[] CoordinateMaxMin(ArrayList Lat)
        {//return max and min lat or lon
            double max = 1;
            double min = 1000;

            if (Lat[0] != " ")
            {
                if (Convert.ToDouble(Lat[0]) < 0)
                {
                    max = min * -1;
                    min = -1;
                }
            }

            for (int i = 0; i < Lat.Count; i++)
            {
                double f = Convert.ToDouble(Lat[i]);
                if (f > max)
                {
                    max = f;
                }
                else if (f < min)
                {
                    min = f;
                }
            }

            double[] Resul = new double[2];
            Resul[0] = min;
            Resul[1] = max;
            return Resul;
        }

        private void WebScraping()
        {
            try
            {
                WebBrowser wb = new WebBrowser();
                wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(GetEsPoints);
                wb.Url = new Uri(BasDirParInt + latArray[0] + "%2C" + latArray[1] + "%2C" + lonArray[0] + "%2C" + lonArray[1] + BasDirParEnd, UriKind.Absolute);
                //File.AppendAllText(@"C:\GenXCTool\Temp Arc\URL.txt", BasDirParInt + "\n" + latArray[0] + "%2C" + latArray[1] + "%2C" + lonArray[0] + "%2C" + lonArray[1] + "\n" + BasDirParEnd + "\n" + BasDirParInt + latArray[0] + "%2C" + latArray[1] + "%2C" + lonArray[0] + "%2C" + lonArray[1] + BasDirParEnd);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "WebScraping");
            }
        }

        private void GetEsPoints(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            wb.Document.ExecCommand("SelectAll", true, null);
            wb.Document.ExecCommand("Copy", true, null);
            string text1 = Clipboard.GetText();
            string County = ""; string State = "";

            bool J = true;

            try
            {
                while (J)
                {
                    string S = p.getBetween(text1, "[[[", "]]]");

                    if (S == "")
                        J = false;
                    else
                    {
                        County = p.getBetween(text1, "\"CNTYNAME\":\"", "\",\"").Trim();
                        State = p.getBetween(text1, "\"OSTATE\":\"", "\",\"").Trim();

                        //File.AppendAllText(@"C:\GenXCTool\Temp Arc\Plats.txt", County + "\n");                  
                        if (State == "FL".ToUpper())
                        {
                            State = "Florida".ToUpper();
                        }

                        J = false;

                        SchemaC = County + " - " + State; MessageBox.Show(SchemaC);

                        string FindSchemName = "SELECT schema_name FROM information_schema.schemata";

                        DataTable dt = new DataTable();
                        dt = ComandoSql(FindSchemName);
                        foreach (DataRow row in dt.Rows)
                        {
                            ListTables.Add(row["schema_name"].ToString());
                        }

                        ArrayList arraySchema = new ArrayList();

                        foreach (string f in ListTables)
                        {
                            if (char.IsUpper(f[0]))
                            {
                                arraySchema.Add(f);
                            }
                        }
                        if (arraySchema.Contains(SchemaC))
                        {
                            //MessageBox.Show("Schema Created");
                        }
                        else
                        {
                            string queryCreateSchema = "CREATE SCHEMA IF NOT EXISTS \"" + SchemaC + "\" AUTHORIZATION postgres";
                            ComandoSql(queryCreateSchema);
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            ReadKml();
        }

        public void FindState()
        {
            
            bool next = false; int c = 0;

            if (string.IsNullOrEmpty(txtProjectName.Text.Trim())) { MessageBox.Show("please fill the fields"); txtProjectName.Focus(); return; }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "KML files|*.kml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;

                using (var reader = new StreamReader(filename))
                {
                    ArrayList Lon = new ArrayList();
                    ArrayList Lat = new ArrayList();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line.Contains("<coordinates>"))
                        {
                            next = true; c++;
                        }

                        else if (next)
                        {
                            string[] data = line.Split(' ');

                            foreach (string a in data)
                            {
                                string s = a.Replace(',', ' ');
                                //s = s + " 0";
                                geom += s + ",";
                            }

                            next = false;
                            geom = geom.Remove(geom.Length - 4, 4);
                            geom = geom.Trim();

                            if (c == 1)
                            {
                                for (int i = 0; i < data.Length - 1; i++)
                                {
                                    string[] Data2 = data[i].Split(',');
                                    Lon.Add(Data2[0]);                                                       
                                    Lat.Add(Data2[1]); 
                                }
                            }
                            break;
                        }
                    }
                    latArray = CoordinateMaxMin(Lat); //latMin [0], latMax[1] 
                    lonArray = CoordinateMaxMin(Lon);
                    //MessageBox.Show(" min lat: " + latArray[0] + " max lat: " + latArray[1] + "\n" + " min lon: " + lonArray[0] + " max lon: " + lonArray[1]);
                }
            }
            WebScraping();
        }
    }
}
