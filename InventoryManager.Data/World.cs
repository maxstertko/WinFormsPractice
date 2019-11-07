using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InventoryManager.Data
{
    public class World : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Work
        public List<Player> Players { get; set; }
        public List<Item> Items { get; set; }

        public World() 
        {
            Players = new List<Player>();
            Items = new List<Item>();
        }
    }
}
