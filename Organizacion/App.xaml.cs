using Microsoft.Extensions.DependencyInjection;
using Organizacion.Views;

namespace Organizacion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var NuevaPagina = new NavigationPage(new Principal());

            NuevaPagina.BarBackgroundColor = Color.FromArgb("#E7C0FF");
            NuevaPagina.BarTextColor = Colors.Black;

            return new Window(NuevaPagina);
        }
    }
}