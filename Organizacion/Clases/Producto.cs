using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Organizacion.Clases
{
    public class Producto : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name; set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private int units;
        public int Units
        {
            get => units; set
            {
                if (units != value)
                {
                    units = value;
                    OnPropertyChanged();
                }
            }
        }

        private double price;
        public double Price
        {
            get => price; set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }
        
    public Producto(string Name, int Units, double Price)
        {
            this.Name = Name;
            this.Units = Units;
            this.Price = Price;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class List_de_Productos 
    {
        public static ObservableCollection<Producto> Lista_Global { get; set; } = new ObservableCollection<Producto>
        {
            new Producto("Cheese Tricks", 12, 700),
            new Producto("Galletita", 10, 450),
            new Producto("Macedonia", 12, 700)
        };
    }
}
