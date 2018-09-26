using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public static class ESHNDeclarationPrinter
    {
        public static void WriteCharIntoTemplate(PdfContentByte cb, string text, float x, float y)
        {
            cb.BeginText();
            cb.ShowTextAligned(1, text, x, y, 0);
            cb.EndText();
        }

        public static void WriteStringIntoTemplate(PdfContentByte cb, string text, float x, float y, int fieldLength)
        {
            for (int i = 0; i < fieldLength; i++)
            {
                if (i < text.Length)
                {
                    WriteCharIntoTemplate(cb, text[i].ToString(), x, y);
                }
                else
                {
                    WriteCharIntoTemplate(cb, "\u2014", x, y);
                }
                x += Constants.distanceBetweenESHNDeclarationCells;
            }
        }

        public static void WriteINN(PdfContentByte cb, string INN)
        {
            float x = 206;
            const float y = Constants.ESHNDeclarationHeight - 31;
            foreach (var c in INN)
            {
                WriteCharIntoTemplate(cb, c.ToString(), x, y);
                x += Constants.distanceBetweenESHNDeclarationCells;
            }
        }

        public static void WritePageNumber(PdfContentByte cb, int pageNumber)
        {
            WriteStringIntoTemplate(cb, pageNumber.ToString("000"), 362, Constants.ESHNDeclarationHeight - 54, 3);
        }

        public static void WriteKPP(PdfContentByte cb, string KPP)
        {
            WriteStringIntoTemplate(cb, KPP, 206, Constants.ESHNDeclarationHeight - 54, Constants.requiredKPPLength);
        }
    }
}
