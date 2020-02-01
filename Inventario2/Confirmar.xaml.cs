using Inventario2.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Confirmar : ContentPage
    {
        string p;
        public Carrito rp;
        public Confirmar(Carrito x)
        {
            InitializeComponent();
            rp = x;
            p = Guid.NewGuid().ToString("D");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Boolean v = true;
            Boolean password = false;
            if (Usuario.Text != null && Contra.Text != null)
            {
                var usuarios = await App.MobileService.GetTable<Usuario>().Where(u => u.nombre == Usuario.Text).ToListAsync();
                if (usuarios.Count() != 0)
                {
                    for (int x = 0; x < usuarios.Count(); x++)
                    {
                        if (usuarios[x].contrasena == Contra.Text)
                        {
                            password = true;
                            for (int y = 0; y < rp.re.mv.Count(); y++)
                            {
                                try
                                {
                                    rp.re.mv[y].ID = p;
                                    rp.re.mv[y].usuario = usuarios[x].nombre;
                                    rp.re.mv[y].lugar = Destino.Text;
                                    await App.MobileService.GetTable<Movimientos>().InsertAsync(rp.re.mv[y]);
                                    //UploadFile(f.GetStream());
                                    //DisplayAlert("Agregado", re.mv.Count().ToString(), "Aceptar");
                                    //re.mv.Clear();
                                    //await Navigation.PopAsync();
                                    v = true;
                                    if (rp.re.f1[y] != null)
                                        UploadFile(rp.re.f1[y].GetStream(), rp.re.mv[y].ID);

                                }
                                catch (MobileServiceInvalidOperationException ms)
                                {
                                    var response = await ms.Response.Content.ReadAsStringAsync();
                                    await DisplayAlert("Error", response, "Aceptar");
                                    v = false;
                                    break;
                                }
                            }
                            if (v)
                            {
                                //agregar el pdf
                                rp.re.mv.Clear();
                                rp.re.f1.Clear();
                                await DisplayAlert("Agregado", "Carrito Agregado correctamente", "Aceptar");
                                await Navigation.PushAsync(new PDFMovement(p));
                                //await Navigation.PopAsync();
                            }
                        }
                    }
                    if (password == false)
                        DisplayAlert("Error", "Usuario o contraseña incorrecto(s)", "Aceptar");
                }
                else
                {
                    DisplayAlert("Error", "Usuario o contraseña incorrecto(s)", "Aceptar");
                }

            }
            else
            {
                DisplayAlert("Error", "Usuario o contraseña no ingresado(s)", "Aceptar");
            }

        }

        private async void UploadFile(Stream stream, string PathFoto)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=fotosavs;AccountKey=kS7YxHQSBtu6kDpa2sG7OVidbxcJq1Dip7+KnNjQA5SHn9N7loT2/Ul9HkdN0R5UPDWeKy0WpWQprGgnjIrbdA==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("fotosinventario");
            await container.CreateIfNotExistsAsync();

            var block = container.GetBlockBlobReference($"{PathFoto}.jpg");
            await block.UploadFromStreamAsync(stream);
            string url = block.Uri.OriginalString;

        }
    }
}