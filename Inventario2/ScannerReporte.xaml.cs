using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerReporte : ContentPage
    {
        HistorialCompleto h;
        public ScannerReporte(HistorialCompleto t)
        {
            InitializeComponent();
            h = t;
        }

        public void ScanPage(ZXing.Result result)
        {
            Boolean x;
            Device.BeginInvokeOnMainThread(async () =>
            {
                //await DisplayAlert("Scanned result", result.Text, "OK");
                h.scantext = result.Text;
                await Navigation.PopAsync();
                //await DisplayAlert("","","oooo");
            });
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            //IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

           // IsScanning = false;
        }
    }
}