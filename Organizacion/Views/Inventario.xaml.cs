using Organizacion.Clases;
using System.Collections.ObjectModel;

namespace Organizacion.Views;

public partial class Inventario : ContentPage
{
	public ObservableCollection <Producto> Lista_de_Productos { get; set; } = new ObservableCollection<Producto>();

    private List<Producto> Lista_P_Completa = new List<Producto>();
	public Inventario()
	{
		InitializeComponent();

		Lista_P_Completa = List_de_Productos.Lista_Global.ToList();
		Lista_de_Productos.Clear();
		foreach(var item in Lista_P_Completa) 
		{
			Lista_de_Productos.Add(item);
		}
		BindingContext = this;

	}

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		string Producto_Deseado = e.NewTextValue;

		if (string.IsNullOrEmpty(Producto_Deseado)) 
		{
			Lista_de_Productos.Clear();
			foreach (var item in Lista_P_Completa) 
			{
				Lista_de_Productos.Add(item);
			}
		}
		else
		{
			var Resultado = Lista_P_Completa
				.Where(x => x.Name.Contains(Producto_Deseado, StringComparison.OrdinalIgnoreCase))
				.ToList();

			if (Resultado.Count == 0) 
			{
				await DisplayAlertAsync("Aviso", "No hay resultados", "Ok"); 
			}

			Lista_de_Productos.Clear();
			foreach(var item in Resultado)
			{
				Lista_de_Productos.Add(item);
			}
		}
    }
}