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

namespace FileNameParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {       
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {     
                foreach(var i in openFileDialog.FileNames)
                {                    
                    FileList.Items.Add(Path.GetFileName(i));
                }                
            }            
        }

        private void ListClearButton_Click(object sender, EventArgs e)
        {
            FileList.Items.Clear();
        }

        private void ListCopybutton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            foreach(var i in FileList.Items)
            {
                fileName += i.ToString()+"\n";
            }
            Clipboard.SetText(fileName);
        }
    }
}
