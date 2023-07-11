using BusinessObject.DataModel;
using CV_Maker.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using BusinessLogic.IServices;
using Razor.Templating.Core;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Text;
using iText.IO.Source;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using Microsoft.AspNetCore.Authorization;

namespace CV_Maker.Controllers
{
    [Authorize]
    public class CvController : Controller
    {
        private readonly IUnitOfService _unitOfService;
        public CvController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }
        public async Task<IActionResult> Index(long cvId = 0, string cvType = "")
        {
            var res = HttpContext.Session.GetInt32("cvId");
            if (res == null || res == 0)
            {
                HttpContext.Session.SetInt32("cvId", (int)cvId);
                HttpContext.Session.SetString("cvType", cvType);
            }
            cvId = (long)HttpContext.Session.GetInt32("cvId");
            var cv =await _unitOfService.CvService.GetFullCvByCvId(cvId);
            return View(cv);
        }
        public async Task<IActionResult> Check()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var cv =await _unitOfService.CvService.GetFullCvByCvId (cvId);
            return View(cv);
        }
        public async Task<IActionResult> Download()
        {
            var cvId = (long)HttpContext.Session.GetInt32("cvId");
            var cv =await _unitOfService.CvService.GetFullCvByCvId(cvId);
            var invoiceHtml = await RazorTemplateEngine.RenderAsync("/Views/Pdf/Index.cshtml", cv);
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(invoiceHtml)))
            {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(writer);
               // pdfDocument.SetDefaultPageSize(pageSize:1200px);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return File(byteArrayOutputStream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
        



        //patial webpage pdf conversion

        //Initialize HTML to PDF converter. 
        /*HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        //Convert URL to PDF document. 
        PdfDocument document = htmlConverter.ConvertPartialHtml(System.IO.File.ReadAllText("C:\\Users\\bs780\\Desktop\\Final Project\\CV Maker\\Views\\Pdf\\Index.cshtml"), "", "template-container");

        //Create the filestream to save the PDF document. 
        FileStream fileStream = new FileStream("Partial-webpage-to-PDF.pdf", FileMode.CreateNew, FileAccess.ReadWrite);

        //Save and closes the PDF document.
        document.Save(fileStream);
      // MemoryStream stream = new MemoryStream();

        document.Close(true);*/



        // instantiate a html to pdf converter object

        //SelectPdf html to pdf converter
        //HtmlToPdf converter = new HtmlToPdf();

        // set converter options
        /*  converter.Options.PdfPageSize = 100;
          converter.Options.PdfPageOrientation = pdfOrientation;
          converter.Options.WebPageWidth = webPageWidth;
          converter.Options.WebPageHeight = webPageHeight;*/
        // converter.Options.PdfPageOrientation= PdfPageOrientation.Portrait;
        //converter.Options.PdfPageSize = PdfPageSize.A4;
        //converter.Options.CustomCSS = "/css/Template.css";
        // converter.Options.CustomCSS = "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css";
        // converter.Options.CustomCSS = "https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css";
        // create a new pdf document converting an url
        // PdfDocument doc = converter.ConvertUrl("https://localhost:7179/Pdf/Index");

        // save pdf document
        //doc.Save( "Sample.pdf");
        /* MemoryStream memoryStream = new MemoryStream();
         doc.Save(memoryStream);
         memoryStream.Position = 0;

         doc.Close();    

         return File(memoryStream.ToArray(),"application/pdf");*/
        // close pdf document

    }

}

