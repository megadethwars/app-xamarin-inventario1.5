using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.Reflection;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFMovement : ContentPage
    {
        public PDFMovement()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //CreatePDF();
            TestPDF();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


        public void TestPDF() {


            PdfDocument document = new PdfDocument();
            //Adds page settings
            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 50;
            //Adds a page to the document
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            //Loads the image from disk
            //PdfImage image = PdfImage.FromFile("Logo.png");

            Stream imageStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Inventario2.Assets.Logo.png");
            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            RectangleF bounds = new RectangleF(0, 0, 110, 110);
            //Draws the image to the PDF page
            page.Graphics.DrawImage(image, bounds);


            //DRAW THE MAIN TITLE
            PdfFont Headfont = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Creates a text element to add the invoice number
            PdfTextElement headelement = new PdfTextElement("AUDIO VIDEO STUDIOS ", Headfont);
            headelement.Brush = PdfBrushes.Red;
            PdfLayoutResult result = headelement.Draw(page, new PointF(graphics.ClientSize.Width - 350, graphics.ClientSize.Height - 740));


            PdfFont Subtitle = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            //Creates a text element to add the invoice number
            PdfTextElement subtitelement = new PdfTextElement("ORDEN DE SALIDA ", Subtitle);
            subtitelement.Brush = PdfBrushes.Red;
            PdfLayoutResult Subresult = subtitelement.Draw(page, new PointF(graphics.ClientSize.Width - 350, graphics.ClientSize.Height - 710));


            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(222, 237, 242));
            bounds = new RectangleF(bounds.Right, Subresult.Bounds.Bottom, graphics.ClientSize.Width - 300, 50);
            //Draws a rectangle to place the heading in that region.
            graphics.DrawRectangle(solidBrush, bounds);

            //creating fields, folio, fecha, lugar
            PdfFont campofont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement lblugar = new PdfTextElement("EVENTO: ", campofont);
            lblugar.Brush = PdfBrushes.Black;
            PdfLayoutResult reslblugar = lblugar.Draw(page, new PointF(bounds.Left + 40, bounds.Top));

            PdfTextElement lbfecha = new PdfTextElement("FECHA: ", campofont);
            lbfecha.Brush = PdfBrushes.Black;
            PdfLayoutResult reslbfecha = lbfecha.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 16));

            PdfTextElement lbfolio = new PdfTextElement("FOLIO: ", campofont);
            lbfolio.Brush = PdfBrushes.Black;
            PdfLayoutResult reslbfolio = lbfolio.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 32));


            PdfBrush solidBrush2 = new PdfSolidBrush(new PdfColor(190, 220, 228));
            bounds = new RectangleF(bounds.Right, Subresult.Bounds.Bottom, graphics.ClientSize.Width - 350, 50);
            //Draws a rectangle to place the heading in that region.
            graphics.DrawRectangle(solidBrush2, bounds);


            //variables de campos
            PdfTextElement lugar = new PdfTextElement("Naucalpan ", campofont);
            lugar.Brush = PdfBrushes.Black;
            PdfLayoutResult reslugar = lugar.Draw(page, new PointF(bounds.Left + 40, bounds.Top));

            PdfTextElement fecha = new PdfTextElement("20/02/2020 ", campofont);
            fecha.Brush = PdfBrushes.Black;
            PdfLayoutResult resfecha = fecha.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 16));

            PdfTextElement folio = new PdfTextElement("F5463 ", campofont);
            folio.Brush = PdfBrushes.Black;
            PdfLayoutResult resfolio = folio.Draw(page, new PointF(bounds.Left + 40, bounds.Top + 32));

            MemoryStream stream = new MemoryStream();
            //Save the document.
            document.Save(stream);
            //Close the document.
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            //The operation in Save under Xamarin varies between Windows Phone, Android and iOS platforms. Please refer PDF/Xamarin section for respective code samples.
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                //   Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Output.pdf", "application/pdf", stream);
                Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            }
        }

        public void CreatePDF() {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page to the document.
            PdfPage page = doc.Pages.Add();
            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            //Load the image as stream
            Stream imageStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Inventario2.Assets.Logo.png");
            //Load the image from the disk.
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 0, 0);
            ////Save the document to the stream
            MemoryStream stream = new MemoryStream();
            //Save the document.
            doc.Save(stream);
            //Close the document.
            doc.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            //The operation in Save under Xamarin varies between Windows Phone, Android and iOS platforms. Please refer PDF/Xamarin section for respective code samples.
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                //   Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Output.pdf", "application/pdf", stream);
                Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            }

        }
    }
}