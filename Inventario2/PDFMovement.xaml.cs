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
using System.Data;

namespace Inventario2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFMovement : ContentPage
    {
        DataTable table;
        public PDFMovement()
        {
            table = new DataTable();
            table.Columns.Add("CANT", typeof(int));
            table.Columns.Add("SERIE", typeof(string));
            table.Columns.Add("ID-PROD", typeof(string));
            table.Columns.Add("DESCRP", typeof(string));
            table.Columns.Add("MARCA", typeof(string));
            table.Columns.Add("MODELO", typeof(string));


            table.Rows.Add(10, "00199123", "01234567","esta bien chido","siemens","39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");
            table.Rows.Add(10, "00199123", "01234567", "esta bien chido", "siemens", "39234");


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

            //create table

            //Creates the datasource for the table
            DataTable invoiceDetails = table;
            //Creates a PDF grid
            PdfGrid grid = new PdfGrid();
            //Adds the data source
            grid.DataSource = invoiceDetails;
            //Creates the grid cell styles
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];
            //Creates the header style
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16f, PdfFontStyle.Regular);

            //Adds cell customizations
            for (int i = 0; i < header.Cells.Count; i++)
            {
                if (i == 0 || i == 1)
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }

            //Applies the header style
            header.ApplyStyle(headerStyle);
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman,10f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            // Creates layout format settings to allow the table pagination
            layoutFormat.Layout = PdfLayoutType.Paginate;
           
            //Draws the grid to the PDF page.
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 150), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);



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