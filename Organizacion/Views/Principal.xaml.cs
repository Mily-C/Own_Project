using Organizacion.Clases;

namespace Organizacion.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void Precios_Inventario_Clicked(object sender, EventArgs e)
    {
		Abrir_Inventario();
    }

    private async void Abrir_Inventario()
    {
        await Navigation.PushAsync(new Inventario());
    }

    private void Lista_Negra_Clicked(object sender, EventArgs e)
    {
        Abrir_Lista_Negra();
    }

    private async void Abrir_Lista_Negra() 
    {
        await Navigation.PushAsync(new La_Lista_Negra_Muajajaja());
    }

    private async void Edicion_Inventario_Clicked(object sender, EventArgs e)
    {
        Abrir_Modificacion();
    }

    private async void Abrir_Modificacion() 
    {
        await Navigation.PushAsync(new Modificacion_Inventario());
  
    }
}