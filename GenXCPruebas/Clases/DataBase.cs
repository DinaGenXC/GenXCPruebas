using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace GenXCPruebas.Clases
{
    class DataBase
    {

        static SQLiteConnection Con;
        //static SQLiteDataAdapter Da;
       // static SQLiteDataReader Dr;
       // static SQLiteCommand Com;
        static String DataSource = @"C:\GenXCTool\DB\dbPrueba.db";
        public static void Conectar()
        {
            try
            {
                string Coneccion = ("Data Source = " + DataSource);
                Con = new SQLiteConnection(Coneccion);
                Con.Open();
                MessageBox.Show("DONE");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al conectar con la base de datos= " + Ex.ToString());
            }
        }
    }
}
