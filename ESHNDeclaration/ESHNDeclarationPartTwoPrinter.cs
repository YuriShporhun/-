using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class ESHNDeclarationPartTwoPrinter
    {
        ESHNDeclarationPartTwo initialData;

        public ESHNDeclarationPartTwoPrinter(ESHNDeclarationPartTwo initialData)
        {
            this.initialData = initialData;
        }

        public void PrintIntoPdf()
        {
            PdfReader reader = new PdfReader(Constants.ESHNDeclarationFullPath);
            var size = reader.GetPageSizeWithRotation(1);

            Document document = new Document(size);
            FileStream fs = new FileStream(Constants.CompletedESHNDeclarationPartTwoFullPath, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfImportedPage page = writer.GetImportedPage(reader, 2);
            PdfContentByte cb = writer.DirectContentUnder;
            BaseFont baseFont = BaseFont.CreateFont(Constants.ESHNDeclarationFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(baseFont, 16);

            ESHNDeclarationPrinter.WritePageNumber(cb, 2);
            ESHNDeclarationPrinter.WriteINN(cb, initialData.Requisites.налогоплательщик.ИНН);
            ESHNDeclarationPrinter.WriteKPP(cb, "");

            WritePartTwoData(cb);

            cb.AddTemplate(page, 0, 0);
            document.NewPage();

            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }

        private void WritePartTwoData(PdfContentByte cb)
        {
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ПервыйКодПоОКТМО, 361, Constants.ESHNDeclarationHeight - 165, Constants.maximumOKTMOLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаАвансовогоПлатежа, 361, Constants.ESHNDeclarationHeight - 205, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ВторойКодПоОКТМО, 361, Constants.ESHNDeclarationHeight - 248, Constants.maximumOKTMOLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаДоходовЗаНалоговыйПериод, 361, Constants.ESHNDeclarationHeight - 455, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаРасходовЗаНалоговыйПериод, 361, Constants.ESHNDeclarationHeight - 498, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.НалоговаяБазаПоНалогу, 361, Constants.ESHNDeclarationHeight - 541, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.НалоговаяБазаПоНалогу, 361, Constants.ESHNDeclarationHeight - 541, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаУбытка, 361, Constants.ESHNDeclarationHeight - 582, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаНалогаИсчисленногоЗаНалоговыйПериод, 361, Constants.ESHNDeclarationHeight - 636, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаНалогаПодлежащаяДоплате, 361, Constants.ESHNDeclarationHeight - 288, Constants.mamimumESHNPartTwoLongestFieldLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.СуммаНалогаКУменьшению, 361, Constants.ESHNDeclarationHeight - 350, Constants.mamimumESHNPartTwoLongestFieldLength);
        }
    }
}
