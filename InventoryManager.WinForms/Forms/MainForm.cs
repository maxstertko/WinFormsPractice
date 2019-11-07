using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManager.Data;
using InventoryManager.WinForms.ViewModels;
using Newtonsoft.Json;

namespace InventoryManager.WinForms.Forms
{
    public partial class MainForm : Form
    {
        public static string AssemblyTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        private WorldViewModel ViewModel {
            get => mViewModel;
            set {
                if (mViewModel != value) {
                    mViewModel = value;
                    worldViewModelBindingSource.DataSource = mViewModel;
                }
            }
        }

        private bool IsWorldLoaded {
            get => mIsWorldLoaded;
            set 
            {
                mIsWorldLoaded = value;
                mainTabControl.Enabled = mIsWorldLoaded;
            }
        }

        public MainForm() {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void AddPlayerButton_Click(object sender, EventArgs e) {
            using (AddPlayerForm addPlayerForm = new AddPlayerForm()) {
                if (addPlayerForm.ShowDialog() == DialogResult.OK) 
                {
                    Player player = new Player { Name = addPlayerForm.PlayerName };
                    ViewModel.Players.Add(player);
                }
            }

        }

        private void PlayerListBox_SelectedIndexChanged(object sender, EventArgs e) {
            deletePlayerButton.Enabled = playerListBox.SelectedItem != null;
        }
        private void DeletePlayerButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Delete this player?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                ViewModel.Players.Remove((Player)playerListBox.SelectedItem);
                playerListBox.SelectedItem = ViewModel.Players.FirstOrDefault();
            }

        }
        #region Main Menu
        private void OpenWorldToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
                IsWorldLoaded = true;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => ViewModel.SaveWorld();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.SaveWorld();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Close();
        }
        #endregion Main Menu

        private WorldViewModel mViewModel;
        private bool mIsWorldLoaded;
    }
}
