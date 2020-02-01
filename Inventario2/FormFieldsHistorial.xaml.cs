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
    public partial class FormFieldsHistorial : ContentPage
    {
        bool NoDate = true;

        public delegate void ONFieldEventHandler(Object sender);
        public event ONFieldEventHandler OnEventSender;

        public delegate void ONstatusQueryEventHandler(Object sender);
        public event ONstatusQueryEventHandler OnStatusQuerySender;


        ModelHistorialCompleto modelhistorial;
        public FormFieldsHistorial()
        {
            InitializeComponent();
            modelhistorial = new ModelHistorialCompleto();
        }


        private int validatefields() {

            
            

            ////////first combination
            ///
            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 0 0 0 0 0
                return 0;
            }


            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 0 0 0 0 1
                return 1;
            }


            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 0 0 0 1 0
                return 2;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 0 0 0 1 1
                return 3;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 0 0 1 0 0
                return 4;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 0 0 1 0 1
                return 5;
            }


            ////////second combination

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 0 0 1 1 0
                return 6;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 0 0 1 1 1
                return 7;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 0 1 0 0 0
                return 8;
            }


            //////second combination

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 0 1 0 0 1
                return 9;
            }


            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 0 1 0 1 0
                return 10;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 0 1 0 1 1
                return 11;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 0 1 1 0 0
                return 12;
            }



            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 0 1 1 0 1
                return 13;
            }

            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 0 1 1 1 0
                return 14;
            }


            if (InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 0 1 1 1 1
                return 15;
            }

            ////////////////third combination
            ///

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 1 0 0 0 0
                return 16;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 1 0 0 0 1
                return 17;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 1 0 0 1 0
                return 18;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 1 0 0 1 1
                return 19;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 1 0 1 0 0
                return 20;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 1 0 1 0 1
                return 21;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 1 0 1 1 0
                return 22;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 1 0 1 1 1
                return 23;
            }


            ////////////////fourth combination

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 1 1 0 0 0
                return 24;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 1 1 0 0 1
                return 25;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") &&!InModel.Text.Equals("") && NoDate)
            {
                //0 1 1 0 1 0
                return 26;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 1 1 0 1 1
                return 27;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //0 1 1 1 0 0
                return 28;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //0 1 1 1 0 1
                return 29;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //0 1 1 1 1 0
                return 30;
            }

            if (InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //0 1 1 1 1 1
                return 31;
            }


            //////fifth combination
            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 0 0 0 0 0
                return 32;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 0 0 0 0 1
                return 33;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 0 0 0 1 0
                return 34;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 0 0 0 1 1
                return 35;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 0 0 1 0 0
                return 36;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 0 0 1 0 1
                return 37;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 0 0 1 1 0
                return 38;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 0 0 1 1 1
                return 39;
            }


            //////sixth combination
            ///

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 0 1 0 0 0
                return 40;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 0 1 0 0 1
                return 41;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 0 1 0 1 0
                return 42;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 0 1 0 1 1
                return 43;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 0 1 1 0 0
                return 44;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 0 1 1 0 1
                return 45;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 0 1 1 1 0
                return 46;
            }

            if (!InUsuario.Text.Equals("") && InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 0 1 1 1 1
                return 47;
            }

            /////seventth combination

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 1 0 0 0 0
                return 48;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 1 0 0 0 1
                return 49;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 1 0 0 1 0
                return 50;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 1 0 0 1 1
                return 51;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 1 0 1 0 0
                return 52;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 1 0 1 0 1
                return 53;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 1 0 1 1 0
                return 54;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 1 0 1 1 1
                return 55;
            }

            //////eigth  combination
            ///
            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") &&!InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 1 1 0 0 0
                return 56;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 1 1 0 0 1
                return 57;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 1 1 0 1 0
                return 58;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 1 1 0 1 1
                return 59;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && NoDate)
            {
                //1 1 1 1 0 0
                return 60;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && InModel.Text.Equals("") && !NoDate)
            {
                //1 1 1 1 0 1
                return 61;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && NoDate)
            {
                //1 1 1 1 1 0
                return 62;
            }

            if (!InUsuario.Text.Equals("") && !InIDProduct.Text.Equals("") && !InMove.Text.Equals("") && !InProd.Text.Equals("") && !InModel.Text.Equals("") && !NoDate)
            {
                //1 1 1 1 1 1
                return 63;
            }

            return 0;
        }

       

        private void FillFieldsOnModel(int res) {
            int day = datePickerStart.Date.Day;
            int month = datePickerStart.Date.Month;
            string year = datePickerStart.Date.Year.ToString();

            string zeroday = "";
            string zeromonth = "";

            if (day < 10)
            {
                zeroday = "0";
            }

            if (month < 10)
            {
                zeromonth = "0";
            }

            string AllDate = zeroday + day.ToString() + "/" + zeromonth + month.ToString() + "/" + year;

            modelhistorial.usuario = InUsuario.Text;
            modelhistorial.IdProducto = InIDProduct.Text;
            modelhistorial.movimiento = InMove.Text;
            modelhistorial.producto = InProd.Text;
            modelhistorial.modelo = InModel.Text;
            modelhistorial.fecha = AllDate;
            
            modelhistorial.QueryStatus = res;
        }


        private async void OnAccept(object sender, EventArgs e)
        {
            Console.WriteLine("testing..");
            int res = validatefields();

            if (res == 0)
            {
                
                await DisplayAlert("error", "Campos de busqueda vacios", "Aceptar");
            }
            else {

                FillFieldsOnModel(res);
                
               
                await Navigation.PopAsync();
                OnEventSender(modelhistorial);
            }
           
        }

        private async void OnCancel(object sender, EventArgs e)
        {
            Console.WriteLine("testing..");
            await Navigation.PopAsync();
        }

        private void DateSwitch_Toggled(object sender, EventArgs e)
        {
            if (DateSwitch.IsToggled) {
                NoDate = false;
            }
            else
            {
                NoDate = true;
            }
        }
    }
}