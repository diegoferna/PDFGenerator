using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GerarPDFTeste
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GerarPdf_Click(object sender, EventArgs e)
        {
            PDFGenerator pdf = new PDFGenerator();

            MemoryStream documentoAssinado = null;

            documentoAssinado = pdf.GerarRelatorioEmPDF();

            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=documento-assinado-gov.pdf");
            HttpContext.Current.Response.BinaryWrite(documentoAssinado.GetBuffer());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}