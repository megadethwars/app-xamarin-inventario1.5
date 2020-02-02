using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public LevantarReporte(string c)
        {
            
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
                isScanning = false;
                
            }
           
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
        private void Enviar_Reporte(object sender, EventArgs e)
        {

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

    }
}