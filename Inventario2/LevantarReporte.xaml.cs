using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LevantarReporte : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile f;
        public bool isScanning = false;
        public string scanText;
        private InventDB device;
        private Model.Reportes reporte;
        private string ID = Guid.NewGuid().ToString();

       
        public string PathFoto;
        public string stringphoto;
        public LevantarReporte(string c)
        {
            reporte = new Model.Reportes();
            device = new InventDB();
            InitializeComponent();
            nombreID.Text = c;
            
            
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();
            if (isScanning)
            {
                nombreID.Text = "";
                nombreID.Text = scanText;

                //search device
                List<InventDB> tabladevice = await QueryDevice(scanText);
                fillDevice(tabladevice);
                isScanning = false;
                
            }
           
        }

        private void fillDevice(List<InventDB> tabla)
        {

            device = tabla[0];
            lbNombre.Text = device.nombre;
            lbMarca.Text = device.marca;
            lbSerie.Text = device.serie;
            lbModelo.Text = device.modelo;
            lbAccDe.Text = device.pertenece;
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            
        }

        public async void Button_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable ||
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ": No camera available", "OK");
                return;
            }
            
             f = await CrossMedia.Current.TakePhotoAsync(
               new Plugin.Media.Abstractions.StoreCameraMediaOptions
               {
                   Directory = "Sample",

                   Name = "test.jpg"
               });
            if (f == null)
                return;
            await DisplayAlert("File Location", f.Path, "OK");
            
        }
        private void ScanFotos(object sender, EventArgs e)
        {

        }

        private void Scan(object sender, EventArgs e)
        { //Declarada en inventario principal
            Navigation.PushAsync(new ScannerReporte(this));
        }

        private async void  OnEnterPressed(object sender,EventArgs e)
        {
            if (nombreID!=null)
            {
                List<InventDB> tabladevice = await QueryDevice(scanText);
            }
        }
        private async void Enviar_Reporte(object sender, EventArgs e)
        {
            reporte.foto = "url to post";
            reporte.codigo = device.codigo;
            reporte.marca = device.marca;
            reporte.serie = device.serie;
            reporte.modelo = device.modelo;
            reporte.producto = device.nombre;
            reporte.comentario = editor.Text;
            reporte.ID = Guid.NewGuid().ToString();

            bool res =await PostReport(reporte);
            editor.Text = "";
        }

        private async Task<List<InventDB>> QueryDevice(string codigo)
        {

            try
            {
                var table = await App.MobileService.GetTable<InventDB>().Where(u => u.codigo == codigo).ToListAsync();

                return table;
            }
            catch(Exception ex)
            {

                return null;
            }
            
        }


        private async Task<bool> PostReport(Model.Reportes reporte)
        {
            

            try
            {
                await App.MobileService.GetTable<Model.Reportes>().InsertAsync(reporte);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }


        public  bool PostImage()
        {           
            return   false;
        }


        private async void UploadFile(Stream stream)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=fotosavs;AccountKey=NLazg0RjiUxSF9UvkeSWvNYicNDSUPn4IoXp4KSKXx0qe+W2bt40BrGFK6M+semkKHHOV5T4Ya2eNKDDQNY57A==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("fotosinventario");
            await container.CreateIfNotExistsAsync();



            var block = container.GetBlockBlobReference($"{PathFoto}.jpg");
            await block.UploadFromStreamAsync(stream);
            string url = block.Uri.OriginalString;
        }

    }
}