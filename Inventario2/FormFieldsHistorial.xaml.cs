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


        private int validatefields() {

            if (InUsuario==null || InUsuario.Equals("")) {
                return 1;
            }

            if (InIDUser == null || InIDUser.Equals(""))
            {
                return 2;
            }


            if (InMove == null || InMove.Equals(""))
            {
                return 3;
            }

            if (InProd == null || InProd.Equals(""))
            {
                return 4;
            }

            if (InModel == null || InModel.Equals(""))
            {
                return 5;
            }




            return 0;
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