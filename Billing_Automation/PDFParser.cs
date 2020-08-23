namespace Billing_Automation
{
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System;

    public class PDFParser
    {
        public string ExtractText(string inFileName)
        {
            PdfReader reader = null;
            string textFromPage;
            try
            {
                textFromPage = PdfTextExtractor.GetTextFromPage(new PdfReader(inFileName), 1);
            }
            catch
            {
                textFromPage = null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }
            return textFromPage;
        }
    }
}

