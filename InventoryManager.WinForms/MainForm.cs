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
using InventoryManager.WinForms.ViewModels;
using Newtonsoft.Json;

namespace InventoryManager.WinForms
{
    public partial class MainForm : Form
    {
        private WorldViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                if (mViewModel != value)
                {
                    mViewModel = value;
                    worldViewModelBindingSource.DataSource = mViewModel;
                }
            }
        }
        public MainForm() {
            InitializeComponent();
            ViewModel = new WorldViewModel();
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void Label1_Click(object sender, EventArgs e) {

        }

        private void FileNameButton_Click(object sender, EventArgs e) 
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
            }
        }

        private WorldViewModel mViewModel;
    }
}
