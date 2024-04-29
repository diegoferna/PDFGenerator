using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GerarPDFTeste
{
    public class PDFGenerator
    {
        public MemoryStream GerarRelatorioEmPDF()
        {
            // Cria um documento PDF
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer =  PdfWriter.GetInstance(document, memoryStream);
          
            // Abre o documento
            document.Open();

            // Cria uma tabela para simular a <div> externa
            PdfPTable outerTable = new PdfPTable(1);
            outerTable.WidthPercentage = 100;
            outerTable.SpacingAfter = 50; // Margem inferior

            // Cria uma célula para a <div> externa
            PdfPCell outerCell = new PdfPCell();
            outerCell.Border = 10; // Sem borda
            outerCell.Padding = 0; // Sem preenchimento

            // Define o raio da borda
            float radius = 5f;

            // Obtém o ContentByte para desenhar na célula
            PdfContentByte canvas = writer.DirectContent;

            // Define a cor da borda
            canvas.SetColorStroke(BaseColor.GRAY);

            // Desenha os cantos arredondados
            canvas.MoveTo(outerCell.Left, outerCell.Bottom + radius);
            canvas.LineTo(outerCell.Left, outerCell.Top - radius);
            canvas.CurveTo(outerCell.Left, outerCell.Top, outerCell.Left + radius, outerCell.Top);
            canvas.LineTo(outerCell.Right - radius, outerCell.Top);
            canvas.CurveTo(outerCell.Right, outerCell.Top, outerCell.Right, outerCell.Top - radius);
            canvas.LineTo(outerCell.Right, outerCell.Bottom + radius);
            canvas.CurveTo(outerCell.Right, outerCell.Bottom, outerCell.Right - radius, outerCell.Bottom);
            canvas.LineTo(outerCell.Left + radius, outerCell.Bottom);
            canvas.CurveTo(outerCell.Left, outerCell.Bottom, outerCell.Left, outerCell.Bottom + radius);

            // Fecha o caminho
            canvas.ClosePathStroke();

            // Cria uma tabela para a <div> interna
            PdfPTable innerTable = new PdfPTable(2);
            innerTable.WidthPercentage = 100;

            // Cria uma célula para o logo
            PdfPCell logoCell = new PdfPCell();
            logoCell.Border = Rectangle.NO_BORDER; // Sem borda
            logoCell.PaddingRight = 10; // Preenchimento à direita

            // Adiciona a imagem do logo à célula do logo
            /*
            string logoPath = "./img/logo-sus-ficha.png";
            Image logoImage = Image.GetInstance(logoPath);
            logoCell.AddElement(logoImage);*/

            // Cria uma célula para o conteúdo
            PdfPCell contentCell = new PdfPCell();
            contentCell.Border = 10; // Sem borda

            // Adiciona os textos ao conteúdo
            Paragraph labelProfissional = new Paragraph("{0}", FontFactory.GetFont("dinregular", 10));
            Paragraph info1 = new Paragraph("Documento assinado digitalmente via GovBr no dia {0}", FontFactory.GetFont("dinregular", 10));
            Paragraph info2 = new Paragraph("Para validar estas informações, favor acessar {0}", FontFactory.GetFont("dinregular", 10));

            // Adiciona os elementos à célula do conteúdo
            contentCell.AddElement(labelProfissional);
            contentCell.AddElement(info1);
            contentCell.AddElement(info2);

            // Adiciona as células à tabela interna
            innerTable.AddCell(logoCell);
            innerTable.AddCell(contentCell);

            // Adiciona a tabela interna à célula da <div> externa
            outerCell.AddElement(innerTable);

            // Adiciona a célula da <div> externa à tabela externa
            outerTable.AddCell(outerCell);

            // Adiciona a tabela externa ao documento
            document.Add(outerTable);

            // Fecha o documento
            document.Close();

            // Retorna o MemoryStream contendo o PDF
            return memoryStream;
        }
    }
}