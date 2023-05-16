using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMunozS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void BtnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtxNombre.Text);
                parametros.Add("apellido", txtxApellido.Text);
                parametros.Add("edad", txtxEdad.Text); 
 

                cliente.UploadValues("http://192.168.100.124:80/Moviles/post.php", "POST", parametros);
                DisplayAlert("Alerta!", "Dato ingresado correctamente", "Aceptar");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Aceptar");
            }
        }

        private void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}