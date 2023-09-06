using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Viajes_app2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cara : ContentPage
    {
        public cara()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            // Elimina la página de inicio de sesión de la pila de navegación
            var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page is LoginPage)
                {
                    Navigation.RemovePage(page);
                }
            }
        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            // Elimina la página actual (cara) de la pila de navegación
            Navigation.RemovePage(this);

            // Navega de regreso a la página de inicio de sesión (LoginPage)
            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // Evita que el botón de retroceso en la barra de navegación funcione
            return true;
        }
    }
}