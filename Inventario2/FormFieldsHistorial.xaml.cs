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
    public partial class FormFieldsHistorial : ContentPage
    {
        public FormFieldsHistorial()
        {
            InitializeComponent();
        }

        private void OnAccept(object sender, EventArgs e)
        {
            Console.WriteLine("testing..");
           
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Console.WriteLine("testing..");

        }
    }
}