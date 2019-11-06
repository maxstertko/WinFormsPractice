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
using InventoryManager.Data;
using Newtonsoft.Json;

namespace InventoryManager.WinForms
{
    public partial class MainForm : Form
    {
        private World World 
        {
            get => mWorld;
            set => mWorld = value;
        }
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void Label1_Click(object sender, EventArgs e) {

        }

        private void FileNameButton_Click(object sender, EventArgs e) 
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                fileNameTextBox.Text = openFileDialog.FileName;
            }
        }

        private World mWorld;
    }
}
