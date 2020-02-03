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

   
    public partial class DetallesReporte : ContentPage
    {
        private string urlImage = "";

        private Model.Reportes reporte;
        public DetallesReporte(Model.Reportes Reporte)
        {
            InitializeComponent();
            this.reporte = Reporte;
            nameProd.Text = reporte.producto;
            idcodigo.Text = reporte.codigo;
            idmarca.Text = reporte.marca;
            idmodelo.Text = reporte.modelo;
            idSerie.Text = reporte.serie;
            idobserv.Text = reporte.comentario;
            try
            {
                imagen.Source = "https://fotosavs.blob.core.windows.net/fotosreporte/" + reporte.foto+".jpg";
            }
            catch
            {
               
            }

            
            
        }

        

        private void OnAccept(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}