using HMunozS6.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMunozS6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.124:80/Moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Estudiante> _post;

        /// <summary>
        /// Constructor Principal
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            ConsultarDatos();
        }
        /// <summary>
        /// navegacion dePagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Registro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
        /// <summary>
        /// boton pra refrescar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnGet_Clicked(object sender, EventArgs e)
        {
            ConsultarDatos();
        }
        /// <summary>
        /// metodo de consulta de Datos
        /// </summary>
        private async void ConsultarDatos()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                string var;
                List<Estudiante> response = JsonConvert.DeserializeObject<List<Estudiante>>(content);
                _post = new ObservableCollection<Estudiante>(response);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                string exx;
                exx = ex.Message;
            }
          
        }

        /// <summary>
        /// Metodo de toma de datos de Un List View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var v = MyListView.SelectedItem;

            Estudiante estudiantes = ((Estudiante)MyListView.SelectedItem);


            Navigation.PushAsync(new Actualizar(estudiantes));
     
        }
    }
}