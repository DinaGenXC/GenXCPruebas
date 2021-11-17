using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenXCPruebas.Clases
{
    public class PruebaSqlite
    {
        static SQLiteConnection Con;
        //static SQLiteDataAdapter Da;
        static SQLiteDataReader Dr;
        static SQLiteCommand Com;
        //static String DataSource = @"C:\GenXCTool\DB\dbPrueba.db";
        static String DataSource = @"C:\GenXCTool\DB\KmlConf.db";
        static string DataSource1 = @"C:\Users\genxc\OneDrive - GenXC Group\Documents - IT\GenXC Apps\Dinanyeli\Planning.db";

        public static void Ds(string Ds)
        {
            DataSource = Ds;
        }

        public void Conectar()
        {
            try
            {
                string Coneccion = ("Data Source = " + DataSource1);
                Con = new SQLiteConnection(Coneccion);
                Con.Open();
                //MessageBox.Show("done");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al conectar con la base de datos= " + Ex.ToString());
            }
        }
        public bool LastLoguin()
        {
            try
            {
                Conectar();
                Com = new SQLiteCommand("Select Max(Last) from LastLoguin ", Con);
                Dr = Com.ExecuteReader();
                Dr.Read();
                if (DateTime.Now > Convert.ToDateTime(Dr[0]))
                {
                    Com = new SQLiteCommand("insert into lastLoguin (Last) values ('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", Con);
                    Com.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al Conectar en la base de datos = " + Ex.ToString());
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        public void Set(String Cod)
        {
            try
            {
                Conectar();
                Com = new SQLiteCommand(Cod, Con);
                Com.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar en la base de datos= " + Ex.ToString());
            }
            finally
            {
                Con.Close();
            }
        }
        public void Guardar(String Cod)
        {
            try
            {
                Conectar();
                Com = new SQLiteCommand(Cod, Con);
                Com.ExecuteNonQuery();
                MessageBox.Show("Cambios guardados Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar en la base de datos= " + Ex.ToString());
            }
            finally
            {
                Con.Close();
            }
        }
        public Boolean Existe(string Cod)
        {
            try
            {
                int q = 0;
                Conectar();
                Com = new SQLiteCommand(Cod, Con);
                Dr = Com.ExecuteReader();
                while (Dr.Read())
                {
                    q++;
                }
                if (q == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al Cargar datos de la base de datos = " + Ex.ToString());
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        #region Foto

        public Byte[] Get(String Cod)
        {
            Byte[] Dat = null;

            try
            {
                Conectar();
                Com = new SQLiteCommand(Cod, Con);
                Dr = Com.ExecuteReader();
                while (Dr.Read())
                {
                    Dat = (byte[])Dr[0];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al Conectar en la base de datos= " + Ex.ToString());
            }
            finally
            {
                Con.Close();
            }
            return Dat;
        }
        public void GuardarFoto(byte[] B)
        {
            try
            {
                Conectar();
                Com = new SQLiteCommand("Insert into Imagen Values(@imagen)", Con);
                Com.Parameters.AddWithValue("@imagen", B);
                Com.ExecuteNonQuery();
                MessageBox.Show("Cambios guardados Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar en la base de datos= " + Ex.ToString());
            }
            finally
            {
                Con.Close();
            }
        }
        #endregion
        public SQLiteCommand select(String Cod)
        {
            try
            {
                Conectar();
                Com = new SQLiteCommand(Cod, Con);
                Com.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al guardar en la base de datos= " + Ex.ToString());
            }
            finally
            {
                //Con.Close();
            }

            return Com;
        }

        public void ExecuteQuery(string txtQuery)
        {
            Conectar();
            Com = Con.CreateCommand();
            Com.CommandText = txtQuery;
            Com.ExecuteNonQuery();
            Con.Close();
        }

        public DataTable Datatable1(string cod)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            Conectar();
            Com = Con.CreateCommand();

            SQLiteDataAdapter DB = new SQLiteDataAdapter(cod, Con);
            ds.Reset();
            DB.Fill(ds);
            dt = ds.Tables[0];
            Con.Close();

            return dt;
        }
    }
}

