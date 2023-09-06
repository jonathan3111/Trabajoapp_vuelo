using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Viajes_app2.Views;
using Xamarin.Forms;

namespace Viajes_app2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private List<Usuario> usuarios; // Lista de usuarios

        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public ICommand IniciarSesionCommand { get; }

        public LoginViewModel()
        {
            IniciarSesionCommand = new Command(IniciarSesion);

            // Inicializa la lista de usuarios con algunos ejemplos
            usuarios = new List<Usuario>
            {
                new Usuario { Email = "jonathan@gmail.com", Contraseña = "123456" },
                new Usuario { Email = "Dylan@gmail.com", Contraseña = "789456" },
                // Agrega más usuarios según sea necesario
            };
        }

        private void IniciarSesion()
        {
            bool inicioDeSesionExitoso = false;

            foreach (var usuario in usuarios)
            {
                if (usuario.Email == Usuario && usuario.Contraseña == Contraseña)
                {
                    inicioDeSesionExitoso = true;
                    break; // Se encontró una coincidencia, salir del bucle
                }
            }

            if (inicioDeSesionExitoso)
            {
                // Inicio de sesión exitoso, navega a la página en cara
                Application.Current.MainPage.Navigation.PushAsync(new Viajes_app2.Views.cara());
            }
            else
            {
                // Inicio de sesión fallido
                MessagingCenter.Send(this, "LoginFailed");
            }
        }
    }

    public class Usuario
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}