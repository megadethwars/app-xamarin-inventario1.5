using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarReporte : ContentPage
    {
        Model.Reportes reporte;
        public bool isScanning = false;
        public string scanText;
        public ConsultarReporte()
        {
            reporte = new Model.Reportes();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            if (isScanning)
            {
                nombreID.Text = "";
                nombreID.Text = scanText;

                //search device
                // consulta de reportes y llenado de tabla
                List<Model.Reportes> listareportes = await QueryReport(scanText);
                
                if (listareportes.Count!=0)
                {
                    postListView.ItemsSource = listareportes;
                }
                else
                {
                    await DisplayAlert("Buscando", "Reportes de codigo encontrados", "Aceptar");
                }

                isScanning = false;

            }

        }


        private void OnEnterPressed(object sender,EventArgs e)
        {
            if (nombreID != null)
            {
                //consulta de reportes y llenado en tabla
            }
        }

        private void Scan(object sender,EventArgs e)
        {
            Navigation.PushAsync(new ScannerConsultaReporte(this));
        }

        private void PostListView_ItemSelected(object sender,EventArgs e)
        {

        }

        private async Task<List<Model.Reportes>> QueryReport(string codigo)
        {

            try
            {
                var table = await App.MobileService.GetTable<Model.Reportes>().Where(u => u.codigo == codigo).ToListAsync();

                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        
    }
}