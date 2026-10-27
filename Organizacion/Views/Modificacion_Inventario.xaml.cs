using System.Collections.ObjectModel;
using Organizacion.Clases;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Organizacion.Views;

public partial class Modificacion_Inventario : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Producto> Lista_de_Productos => List_de_Productos.Lista_Global;

    private Producto? Tar_Seleccionada;
    public Producto? Tarjetita_Seleccionada
    {
        get => Tar_Seleccionada; set
        {
            if (Tar_Seleccionada != value)
            {
                Tar_Seleccionada = value;
                OnPropertyChanged();
            }
        }
    }

    public Modificacion_Inventario()
    {
        InitializeComponent();
        BindingContext = this;

        if (Lista_de_Productos.Count > 0)
        {
            Tarjetita_Seleccionada = Lista_de_Productos[0];
        }
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Campo_Nombre_Producto.Text) && !string.IsNullOrWhiteSpace(Campo_Unidades_Producto.Text) && !string.IsNullOrWhiteSpace(Campo_Precio_Producto.Text))
        {
            bool Objeto_Existente = List_de_Productos.Lista_Global.Any(p => p.Name.Equals(Campo_Nombre_Producto.Text, StringComparison.OrdinalIgnoreCase));

            if (Objeto_Existente)
            {
                await DisplayAlertAsync("Oh no...", "Al parecer ya existe algo con ese nombre", "OK");
                Campo_Nombre_Producto.Text = string.Empty;
                Campo_Unidades_Producto.Text = string.Empty;
                Campo_Precio_Producto.Text = string.Empty;
            }
            else
            {
                int.TryParse(Campo_Unidades_Producto.Text, out var Units_Parsed);
                double.TryParse(Campo_Precio_Producto.Text, out var Price_Parsed);
                Producto New_Producto = new Producto(Campo_Nombre_Producto.Text, Units_Parsed, Price_Parsed);
                List_de_Productos.Lista_Global.Add(New_Producto);

                Campo_Nombre_Producto.Text = string.Empty;
                Campo_Unidades_Producto.Text = string.Empty;
                Campo_Precio_Producto.Text = string.Empty;

                await DisplayAlertAsync("Muy bien!", "Haz agregado un nuevo producto a la lista!", "OK");
            }
        }
        else
        {
            await DisplayAlertAsync("Oh no...", "Se necesitan todos los campos para agregar algo nuevo", "OK");
        }
        
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void Editar_Clicked(object? sender, EventArgs e)
    {
        if (Check_de_Seleccion.IsChecked == false)
        {
            await DisplayAlertAsync("Ñao Ñao", "Presiona el botoncito para seleccionar un producto", "OK");
        }
        else if (!string.IsNullOrWhiteSpace(Campo_Nombre_Producto.Text) && Check_de_Seleccion.IsChecked != false)
        {
            if (Carrosel_Productos.CurrentItem is Producto P_Seleccionado)
            {
                Tarjetita_Seleccionada = P_Seleccionado;
                Tarjetita_Seleccionada.Name = Campo_Nombre_Producto.Text;

                int index = List_de_Productos.Lista_Global.IndexOf(Tarjetita_Seleccionada);
                if (index != -1)
                {
                    var Tar_Editada = Tarjetita_Seleccionada;
                    List_de_Productos.Lista_Global.RemoveAt(index);
                    List_de_Productos.Lista_Global.Insert(index, Tar_Editada);

                    Carrosel_Productos.CurrentItem = null;
                    Carrosel_Productos.CurrentItem = Tar_Editada;

                    await DisplayAlertAsync("Que bien!", "Haz modificado informacion de un producto!", "OK");
                    Check_de_Seleccion.IsChecked = false;
                    Campo_Nombre_Producto.Text = string.Empty;
                }
            }
        }
        else if (!string.IsNullOrWhiteSpace(Campo_Precio_Producto.Text) && Check_de_Seleccion.IsChecked != false)
        {
            if (Carrosel_Productos.CurrentItem is Producto P_Seleccionado1)
            {
                Tarjetita_Seleccionada = P_Seleccionado1;

                Tarjetita_Seleccionada.Price = double.TryParse(Campo_Precio_Producto.Text, out var a) ? a : Tarjetita_Seleccionada.Price;

                int index = List_de_Productos.Lista_Global.IndexOf(Tarjetita_Seleccionada);
                if (index != -1)
                {
                    var Tar_Editada = Tarjetita_Seleccionada;
                    List_de_Productos.Lista_Global.RemoveAt(index);
                    List_de_Productos.Lista_Global.Insert(index, Tar_Editada);

                    Carrosel_Productos.CurrentItem = null;
                    Carrosel_Productos.CurrentItem = Tar_Editada;

                    await DisplayAlertAsync("Que bien!", "Has modificado informacion de un producto!", "OK");
                    Check_de_Seleccion.IsChecked = false;
                    Campo_Precio_Producto.Text = string.Empty;
                }
            }
        }
        else if (!string.IsNullOrWhiteSpace(Campo_Unidades_Producto.Text) && Check_de_Seleccion.IsChecked != false)
        {
            if (Carrosel_Productos.CurrentItem is Producto P_Seleccionado2)
            {
                Tarjetita_Seleccionada = P_Seleccionado2;

                Tarjetita_Seleccionada.Units = int.TryParse(Campo_Unidades_Producto.Text, out var u) ? u : Tarjetita_Seleccionada.Units;

                int index = List_de_Productos.Lista_Global.IndexOf(Tarjetita_Seleccionada);
                if (index != -1)
                {
                    var Tar_Editada = Tarjetita_Seleccionada;
                    List_de_Productos.Lista_Global.RemoveAt(index);
                    List_de_Productos.Lista_Global.Insert(index, Tar_Editada);

                    Carrosel_Productos.CurrentItem = null;
                    Carrosel_Productos.CurrentItem = Tar_Editada;

                    await DisplayAlertAsync("Que bien!", "Has modificado informacion de un producto!", "OK");
                    Check_de_Seleccion.IsChecked = false;
                    Campo_Unidades_Producto.Text = string.Empty;
                }

            }
        }
        else if (!string.IsNullOrEmpty(Campo_Nombre_Producto.Text) && !string.IsNullOrEmpty(Campo_Precio_Producto.Text) && !string.IsNullOrEmpty(Campo_Unidades_Producto.Text) && Check_de_Seleccion.IsChecked != false)
        {
            if (Carrosel_Productos.CurrentItem is Producto P_Seleccionado)
            {
                Tarjetita_Seleccionada = P_Seleccionado;

                Tarjetita_Seleccionada.Name = Campo_Nombre_Producto.Text;
                Tarjetita_Seleccionada.Units = int.TryParse(Campo_Unidades_Producto.Text, out var ee) ? ee : Tarjetita_Seleccionada.Units;
                Tarjetita_Seleccionada.Price = double.TryParse(Campo_Precio_Producto.Text, out var a) ? a : Tarjetita_Seleccionada.Price;

                int index = List_de_Productos.Lista_Global.IndexOf(Tarjetita_Seleccionada);
                if (index != -1)
                {
                    var Tar_Editada = Tarjetita_Seleccionada;
                    List_de_Productos.Lista_Global.RemoveAt(index);
                    List_de_Productos.Lista_Global.Insert(index, Tar_Editada);

                    Carrosel_Productos.CurrentItem = null;
                    Carrosel_Productos.CurrentItem = Tar_Editada;

                    await DisplayAlertAsync("Que bien!", "Has modificado informacion de un producto!", "OK");
                    Check_de_Seleccion.IsChecked = false;
                    Campo_Nombre_Producto.Text = string.Empty;
                    Campo_Precio_Producto.Text = string.Empty;
                    Campo_Unidades_Producto.Text = string.Empty;
                }

            }
        }
    }

    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        if(Check_de_Seleccion.IsChecked != false) 
        {
            if(Carrosel_Productos.CurrentItem is Producto Para_Borrar) 
            {
                List_de_Productos.Lista_Global.Remove(Para_Borrar);
                Carrosel_Productos.CurrentItem = null;
                Check_de_Seleccion.IsChecked = false;

                await DisplayAlertAsync("Heeey!", "Acabas de borrar... {0}", "OK");
            }
        }
        else 
        {
            await DisplayAlertAsync("Oh no...", "Si quieres borrar algo, dale al botoncito para seleccionar", "OK");
        }
    }
}