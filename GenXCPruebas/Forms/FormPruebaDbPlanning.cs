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
using System.Windows.Media.Media3D;
using GenXCPruebas.Clases;

namespace GenXCPruebas.Forms
{
    public partial class FormPruebaDbPlanning : Form
    {
        PruebaSqlite db = new PruebaSqlite();
        Clases.Class1.Point p = new Class1.Point();
        public FormPruebaDbPlanning()
        {
            InitializeComponent();
        }
        public void Parcel(string Id, string Dir, string Center, string Body, string Layer, string Type)
        {
            // string Id = "id5", Dir= "501 SW 37 AVE", Center= "-81.3208553545442,28.4954432436744,0", Body= "-80.1947691870035,25.775053257623,0 -80.1947648179517,25.7750737534696,0 -80.1947773402624,25.7750835211053,0 -80.1947598068345,25.7750843590827,0 -80.1947539634934,25.7751026827394,0 -80.1947456180778,25.77508352113,0 -80.1947314804704,25.7750822208801,0 -80.1947445832936,25.775071581294,0 -80.1947389750874,25.7750533836448,0 -80.1947555842546,25.7750631107024,0 -80.1947691870035,25.775053257623,0", Layer="drop", Type = "MULTI-FAMILY";
            try
            {
                string query;

                if (!db.Existe("select * from Parcel where Parcel.Id = '" + Id + "' ") && !db.Existe("select * from Parcel where Parcel.Body ='" + Body + "' and Parcel.Layer='" + Layer + "'"))
                {
                    query = "INSERT INTO Parcel(id,Dir,Center,Body, Layer,Type) VALUES('" + Id + "','" + Dir + "','" + Center + "','" + Body + "','" + Layer + "','" + Type + "')";
                    db.Set(query);
                    MessageBox.Show("Insertado, no existe");
                }
                else
                {
                    if (db.Existe("select * from Parcel where Parcel.Id = '" + Id + "'"))
                    {
                        query = "UPDATE Parcel SET Id='" + Id + "', Dir= '" + Dir + "', Center= '" + Center + "', Body='" + Body + "', Layer='" + Layer + "',Type='" + Type + "' where Id='" + Id + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe id");
                    }
                    else
                    {
                        query = "UPDATE Parcel SET Id='" + Id + "', Dir= '" + Dir + "', Center= '" + Center + "', Body='" + Body + "', Layer='" + Layer + "',Type='" + Type + "' where Body='" + Body + "' and Layer='" + Layer + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe body");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Pole(string Id, string IdTer, string Body, string Block)
        {
            //string Id = "id4", IdTer="idTer", Body= "-80.1947691870035,25.775053257623,0 -80.1947648179517,25.7750737534696,0 -80.1947773402624,25.7750835211053,0 -80.1947598068345,25.7750843590827,0", Block = "HH";
            try
            {
                string query;

                if (!db.Existe("select * from Pole where Pole.Id = '" + Id + "' ") && !db.Existe("select * from Pole where Pole.Body ='" + Body + "' and Pole.Block='" + Block + "'"))
                {
                    query = "INSERT INTO Pole(Id,IdTer,Body,Block) VALUES('" + Id + "','" + IdTer + "','" + Body + "','" + Block + "')";
                    db.Set(query);
                    MessageBox.Show("Insertado, no existe");
                }
                else
                {
                    if (db.Existe("select * from Pole where Pole.Id = '" + Id + "'"))
                    {
                        query = "UPDATE Pole SET Id='" + Id + "', IdTer= '" + IdTer + "', Body='" + Body + "', Block='" + Block + "' where Id='" + Id + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe id");
                    }
                    else
                    {
                        query = "UPDATE Pole SET Id='" + Id + "',  IdTer= '" + IdTer + "', Body='" + Body + "', Block='" + Block + "' where Body='" + Body + "' and Block='" + Block + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe body");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Splice(string Id, string IdCable, string Env, string IdHH, string Body, string Block)
        {
            // string Id = "id", IdCable = "idCable", Env = "Burried", IdHH = "MULTI-FAMILY", Body = "-80.1947648179517,25.7750737534696,0 -80.1947773402624,25.7750835211053,0 -80.1947598068345,25.7750843590827,0 -80.1947539634934,25.7751026827394,0 -80.1947456180778,25.77508352113,0 -80.1947314804704,25.7750822208801,0 -80.1947445832936,25.775071581294,0 -80.1947389750874,25.7750533836448,0 -80.1947555842546,25.7750631107024,0 -80.1947691870035,25.775053257623,0", Block="splice";
            try
            {
                string query;

                if (!db.Existe("select * from Splice where Splice.Id = '" + Id + "' ") && !db.Existe("select * from Splice where Splice.Body ='" + Body + "' and Splice.Block='" + Block + "'"))
                {
                    query = "INSERT INTO Splice(id,IdCable, Env, IdHH, Body, Block) VALUES('" + Id + "','" + IdCable + "','" + Env + "','" + IdHH + "','" + Body + "','" + Block + "')";
                    db.Set(query);
                    MessageBox.Show("Insertado, no existe");
                }
                else
                {
                    if (db.Existe("select * from Splice where Splice.Id = '" + Id + "'"))
                    {
                        query = "UPDATE Splice SET Id='" + Id + "', IdCable= '" + IdCable + "', Env= '" + Env + "', IdHH='" + IdHH + "', Body='" + Body + "',Block='" + Block + "' where Id='" + Id + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe id");
                    }
                    else
                    {
                        query = "UPDATE Splice SET Id='" + Id + "', IdCable= '" + IdCable + "', Env= '" + Env + "', IdHH='" + IdHH + "', Body='" + Body + "', Block='" + Block + "' where Body='" + Body + "' and Block='" + Block + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe body");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Terminal(string Id, string Tam, string IdCasa, string Po, string Body, string Block)
        {
            //string Id = "002", Tam = "5656521", IdCasa = "id15", Po = "LY0", Body = "-80.1947598068345,25.7750843590827,0 -80.1947539634934,25.7751026827394,0 -80.1947456180778,25.77508352113,0 -80.1947314804704,25.7750822208801,0 -80.1947445832936,25.775071581294,0 -80.1947389750874,25.7750533836448,0 -80.1947555842546,25.7750631107024,0 -80.1947691870035,25.775053257623,0", Block = "block";
            try
            {
                string query;

                if (!db.Existe("select * from Terminal where Terminal.Id = '" + Id + "' ") && !db.Existe("select * from Terminal where Terminal.Body ='" + Body + "' and Terminal.Block='" + Block + "'"))
                {
                    query = "INSERT INTO Terminal(id,Tam, IdCasa, Po, Body, Block) VALUES('" + Id + "','" + Tam + "','" + IdCasa + "','" + Po + "','" + Body + "','" + Block + "')";
                    db.Set(query);
                    MessageBox.Show("Insertado, no existe");
                }
                else
                {
                    if (db.Existe("select * from Terminal where Terminal.Id = '" + Id + "'"))
                    {
                        query = "UPDATE Terminal SET Id='" + Id + "', Tam= '" + Tam + "', IdCasa= '" + IdCasa + "', Po='" + Po + "', Body='" + Body + "',Block='" + Block + "' where Id='" + Id + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe id");
                    }
                    else
                    {
                        query = "UPDATE Terminal SET Id='" + Id + "', Tam= '" + Tam + "', IdCasa= '" + IdCasa + "', Po='" + Po + "', Body='" + Body + "', Block='" + Block + "' where Body='" + Body + "' and Block='" + Block + "' ";
                        db.Set(query);
                        MessageBox.Show("Update existe body");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool SelectParcel(string Id, string Body, string Layer)
        {
            bool bool1;
            if (db.Existe("select * from Parcel where Parcel.Id = '" + Id + "'"))
            {
                string queryId = "select * from Parcel where Id='" + Id + "'";
                db.Set(queryId);
                //dataGridView1.DataSource = db.Datatable1(queryId);
                bool1 = true;
            }
            else
            {
                string queryBody = "select * from Parcel where Body='" + Body + "' and Layer='" + Layer + "' ";
                db.Set(queryBody);
                // dataGridView1.DataSource = db.Datatable1(queryBody);
                bool1 = false;
            }
            return bool1;
        }
        public bool SelectPole(string Id, string Body, string Block)
        {
            bool bool1;
            if (db.Existe("select * from Pole where Id = '" + Id + "'"))
            {
                string queryId = "select * from Pole where Id='" + Id + "'";
                db.Set(queryId);
                bool1 = true;
            }
            else
            {
                string queryBody = "select * from Pole where Body='" + Body + "' and Block='" + Block + "' ";
                db.Set(queryBody);
                bool1 = false;
            }
            return bool1;
        }
        public bool SelectSplice(string Id, string Body, string Block)
        {
            bool bool1;
            if (db.Existe("select * from Splice where Id = '" + Id + "'"))
            {
                string queryId = "select * from Splice where Id='" + Id + "'";
                db.Set(queryId); dataGridView1.DataSource = db.Datatable1(queryId);
                bool1 = true;
            }
            else
            {
                string queryBody = "select * from Splice where Body='" + Body + "' and Block='" + Block + "' ";
                db.Set(queryBody); dataGridView1.DataSource = db.Datatable1(queryBody);
                bool1 = false;
            }
            return bool1;
        }
        public bool SelectTerminal(string Id, string Body, string Block)
        {
            bool bool1;
            if (db.Existe("select * from Terminal where Id = '" + Id + "'"))
            {
                string queryId = "select * from Terminal where Id='" + Id + "'";
                db.Set(queryId);
                bool1 = true;
            }
            else
            {
                string queryBody = "select * from Terminal where Body='" + Body + "' and Block='" + Block + "' ";
                db.Set(queryBody);
                bool1 = false;
            }
            return bool1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Parcel("id6", "501 SW 37 AVE", "-81.3208553545442,28.4954432436744,0", "-80.1947691870035,25.775053257623,0 -80.1947648179517,25.7750737534696,0 -80.1947773402624,25.7750835211053,0 -80.1947598068345,25.7750843590827,0 -80.1947539634934,25.7751026827394,0 -80.1947456180778,25.77508352113,0 -80.1947314804704,25.7750822208801,0 -80.1947445832936,25.775071581294,0 -80.1947389750874,25.7750533836448,0 -80.1947555842546,25.7750631107024,0 -80.1947691870035,25.775053257623,0", "0", "MULTI-FAMILY");          
            // MessageBox.Show("Test");
            //bool result= SelectParcel("iddina", "Body", "drop");
            //Pole();
            // Terminal();
            //MessageBox.Show(result.ToString());
            //SelectSplice("00","0","block4");
            // bool result = SelectSplice("id", "-0.1947598068345,25.7750843590827,0 -80.1947539634934,25.7751026827394,0 -80.1947456180778,25.77508352113,0 -80.1947314804704,25.7750822208801,0 -80.1947445832936,25.775071581294,0 -80.1947389750874,25.7750533836448,0 -80.1947555842546,25.7750631107024,0 -80.1947691870035,25.775053257623,0", "block4");
            kml();
        }


        private void kml()
        {
            txtFile.Text = "";
            ArrayList data = new ArrayList();
            string Status = ""; string Length_FT = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "KML Files|*.kml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = "";
                fileName = openFileDialog.FileName;
                txtFile.SelectionStart = openFileDialog.FileName.Length;

                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line.Contains("<SimpleData name=\"STATUS\">"))
                        {
                            Status = p.getBetween(line, "<SimpleData name=\"STATUS\">", "</SimpleData>");
                            MessageBox.Show(Status, "Status");
                        }

                        if (line.Contains("<SimpleData name=\"LENGTH_FT\">"))
                        {
                            Length_FT = p.getBetween(line, "<SimpleData name=\"LENGTH_FT\">", "</SimpleData>");                           
                            MessageBox.Show(Length_FT, "Length_FT");
                        }

                    }
                }
            }
        }
    }
}
