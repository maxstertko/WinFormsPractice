﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManager.WinForms.Forms
{
    public partial class AddPlayerForm : Form
    {
        public string PlayerName {
            get => playerNameTextBox.Text;
            set => playerNameTextBox.Text = value;
        }
        public AddPlayerForm() {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e) {

        }

        private void PlayerNameTextBox_TextChanged(object sender, EventArgs e) {
            okButton.Enabled = !string.IsNullOrEmpty(PlayerName);
        }
    }
}
