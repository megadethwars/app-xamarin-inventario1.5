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
    public partial class DetallesCarrito2 : ContentPage
    {
        public IngresarProducto ca;
        public Movimientos ma;
        public DetallesCarrito2(Movimientos m, IngresarProducto r)
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

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            int aux = 2;
            var lista = Navigation.NavigationStack;
            for (int x = 0; x < lista.Count; x++)
            {
                if (lista.Count > 3)
                {
                    if (x == 2)
                    {
                        x--;
                        Navigation.RemovePage(lista[aux]);
                    }

                }
            }
            Navigation.PopAsync();
        }
    }
}