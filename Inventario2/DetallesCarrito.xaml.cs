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
    public partial class DetallesCarrito : ContentPage
    {
        public RetirarProducto ca;
        public Movimientos ma;
        public DetallesCarrito(Movimientos m, RetirarProducto r)
        {
            InitializeComponent();
            nameProd.Text = m.producto;
            marcatxt.Text = m.marca;
            modeltxt.Text = m.modelo;
            cantidadtxt.Text = m.cantidad;
            observtxt.Text = m.observ;
            ma = m;
            ca = r;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!(observ.Text == null))
            {
                ma.observ = observ.Text;
                observtxt.Text = observ.Text;
            }
            if (!(cantidad.Text == null))
            {
                ma.cantidad = cantidad.Text;
                cantidadtxt.Text = cantidad.Text;
            }
            if (observ.Text != null || cantidad.Text != null)
                DisplayAlert("Aceptar", "Producto Actualizado Correctamente", "Aceptar");

        }
    }
}