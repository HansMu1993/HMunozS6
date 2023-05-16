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

        public MainPage()
        {
            InitializeComponent();
            ConsultarDatos();
        }

        private void Registro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void BtnGet_Clicked(object sender, EventArgs e)
        {
            ConsultarDatos();
        }

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
            //var content = await client.GetStringAsync(Url);
            //List<VehicleResponse> response = JsonConvert.DeserializeObject<List<VehicleResponse>>(content);
            //_post = new ObservableCollection<VehicleResponse>(response);

            //MyListView.ItemsSource = _post;
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var v = MyListView.SelectedItem;

            Estudiante estudiantes = ((Estudiante)MyListView.SelectedItem);


            Navigation.PushAsync(new Actualizar(estudiantes));
     
        }
    }
}