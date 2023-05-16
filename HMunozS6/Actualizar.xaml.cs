using HMunozS6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMunozS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        /// <summary>
        /// Metodo contructor Principal
        /// </summary>
        /// <param name="estudiante"></param>
        public Actualizar( Estudiante estudiante)
        {
            InitializeComponent();

            txtCodigo.Text =estudiante.codigo.ToString();
            txtxNombre.Text =estudiante.nombre.ToString();
            txtxApellido.Text =estudiante.apellido.ToString();
            txtxEdad.Text =estudiante.edad.ToString();
        }

        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Metodo para Actualizar DAtos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            //SearchBar envia como parametro necesario , se inicializa y se envia vacio
            var parametros = new System.Collections.Specialized.NameValueCollection();

            //Para ejecutar el consumo , se contruira la url y se enviara asi
            //
            string url = "http://192.168.100.124:80/Moviles/post.php"
                + "?codigo=" + txtCodigo.Text
                + "&nombre=" + txtxNombre.Text
                + "&apellido=" + txtxApellido.Text
                + "&edad=" + txtxEdad.Text;

            byte[] response = client.UploadValues(url, "PUT", parametros);

            // Decodificar la respuesta a una cadena de texto
            string result = Encoding.UTF8.GetString(response);

            //Label respuesta es ok  
            if (result != "")
            {
                // Ocurrió un error en la solicitud
                await DisplayAlert("Error", "Ocurrió un error en la solicitud.", "OK");
               

            }
            else
            {
              

                // La solicitud PUT fue exitosa
                await DisplayAlert("Actualización exitosa", "Los datos se actualizaron correctamente.", "OK");
            }


        }
        /// <summary>
        /// Metodo Para eliminar Datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void BtnEliminar_Clicked_1(object sender, EventArgs e)
        {
            // Obtener los datos actualizados de los campos de entrada
            var codigo = int.Parse(txtCodigo.Text);


            WebClient client = new WebClient();
            //SearchBar envia como parametro necesario , se inicializa y se envia vacio
            var parametros = new System.Collections.Specialized.NameValueCollection();

            //Para ejecutar el consumo , se contruira la url y se enviara asi
            //
            string url = "http://192.168.100.124:80/Moviles/post.php"
                + "?codigo=" + txtCodigo.Text;

            byte[] response = client.UploadValues(url, "DELETE", parametros);

            // Decodificar la respuesta a una cadena de texto
            string result = Encoding.UTF8.GetString(response);

            //Label respuesta es ok 
            if (result == "")
            {
                string status = client.ResponseHeaders["Status"];

                // La solicitud PUT fue exitosa
                await DisplayAlert("Eliminacion exitosa", "Los datos se eliminaron correctamente.", "OK");

            }
            else
            {
                // Ocurrió un error en la solicitud
                await DisplayAlert("Error", "Ocurrió un error en la solicitud.", "OK");
            }
        }


    }
}