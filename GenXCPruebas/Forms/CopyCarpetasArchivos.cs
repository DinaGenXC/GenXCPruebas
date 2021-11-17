using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenXCPruebas.Forms
{
    public partial class CopyCarpetasArchivos : Form
    {
        public CopyCarpetasArchivos()
        {
            InitializeComponent();
        }

        private static void DirectoryCopy(string source, string CopyDir, bool copySubDirs)
        {
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(source);

                DirectoryInfo Copdir = Directory.CreateDirectory(CopyDir);
                Copdir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                DirectoryInfo[] Arraydir = dir.GetDirectories();

                //Directory.CreateDirectory(CopyDir);

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(CopyDir, file.Name);
                    file.CopyTo(tempPath, false);
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in Arraydir)
                    {
                        string tempPath = Path.Combine(CopyDir, subdir.Name);
                        //if (subdir.Name.Contains("UPDATER") || subdir.Name.Contains("SIGN-IN"))
                        //{
                            DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                       // }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            string sourceDirectory = @"C:\GenXCToolCopy";
            string targetDirectory = @"C:\GenXC Temp";

            DirectoryCopy(sourceDirectory, targetDirectory, true);
            MessageBox.Show("completed");
            // Directory.Delete(@"C:\GenXCToolCopy", true);
            MessageBox.Show("deleted");
        }

        private void CopyCarpetasArchivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
                
    }
}
