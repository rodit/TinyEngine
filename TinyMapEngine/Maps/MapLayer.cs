using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace TinyMapEngine.Maps
{
    public class MapLayer : INotifyPropertyChanged
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Load(BinaryReader reader)
        {
            Name = reader.ReadStringBE();
        }

        public virtual void Save(BinaryWriter writer)
        {
            writer.WriteString(Name);
        }
    }
}
