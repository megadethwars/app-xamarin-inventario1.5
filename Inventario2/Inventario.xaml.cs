﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inventario : ContentPage
    {
        //string codigo;
        public List<InventDB> users;
        public string stringcode;
        public int cont = 0;
        public string tipoBusqueda;
        public Inventario()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            search.Text = stringcode;
            var usuario = await App.MobileService.GetTable<InventDB>().ToListAsync();
            postListView.ItemsSource = usuario;
            
        }

        
        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as InventDB;
            if (selectedPost != null)
                Navigation.PushAsync(new DetallesProducto(selectedPost));
        }

        public async void buscar()
        {
            string cadena = "";
            if (search.Text.Length > 3)
                cadena = search.Text.Substring(search.Text.Length - 3);
            var isNumeric = long.TryParse(cadena, out long n);


            if (tipoBusqueda=="Nombre")
            {
                //SQLiteConnection conn = new SQLiteConnection(App.DtabaseLocation);
                //conn.CreateTable<InventDB>();
                //var users1 = conn.Query<InventDB>("select * from InventDB where Nombre= ?", search.Text);
                //conn.Close();
                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.nombre == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", "Producto no encontrado", "Aceptar");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
            if(tipoBusqueda=="QR")
            {

                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.codigo == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", " no encontrado" + search.Text, "OK");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
            if (tipoBusqueda == "Marca")
            {

                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.marca == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", " no encontrado" + search.Text, "OK");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
            if (tipoBusqueda == "Modelo")
            {

                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.modelo == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", " no encontrado" + search.Text, "OK");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
            if (tipoBusqueda == "Proveedor")
            {

                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.proveedor == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", " no encontrado" + search.Text, "OK");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
<<<<<<< Updated upstream

=======
            if (tipoBusqueda == "Serie")
            {

                var users1 = await App.MobileService.GetTable<InventDB>().Where(u => u.serie == search.Text).ToListAsync();
                if (users1.Count != 0)
                {
                    //DisplayAlert("Buscando", "encontrado", "OK");
                    postListView.ItemsSource = users1;
                }
                else
                {
                    DisplayAlert("Buscando", " no encontrado" + search.Text, "OK");
                    var usuarios = await App.MobileService.GetTable<InventDB>().ToListAsync();

                    postListView.ItemsSource = usuarios;
                }
            }
>>>>>>> Stashed changes
        }
        private  void SearchBar(object sender, EventArgs e)
        {
            buscar();
        }

        private void Scan(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Escanear(this));
        }

        private async void MenuOp(object sender, EventArgs e)
        { //Despegar menu de  3 opciones Ingresar, Retirar, Detalles
<<<<<<< Updated upstream
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Nuevo Producto", "Reingresar Producto", "Retirar Producto");
=======
            string res = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Nuevo Producto", "Reingresar Producto", "Salida");
>>>>>>> Stashed changes
            switch (res)
            {
                case "Agregar Nuevo Producto":
                    //Abrir vista/pagina Detalles del Producto
                    Navigation.PushAsync(new NuevoProducto());
<<<<<<< Updated upstream
=======
                    
>>>>>>> Stashed changes
                    break;
                case "Reingresar Producto":
                    //Abrir vista/pagina Ingresar Producto
                    Navigation.PushAsync(new IngresarProducto(  ));
                    break;
<<<<<<< Updated upstream
                case "Retirar Producto":
=======
                case "Salida":
>>>>>>> Stashed changes
                    //Abrir vista/pagina Retirar Producto
                    Navigation.PushAsync(new RetirarProducto());
                    break;

                
            }
        }

        private void pickerBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoBusqueda = pickerBuscar.SelectedItem as string;
        }
    }
}