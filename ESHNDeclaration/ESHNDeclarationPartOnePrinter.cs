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
    public class ESHNDeclarationPartOnePrinter
    {
        ESHNDeclarationPartOne initialData;

        public ESHNDeclarationPartOnePrinter(ESHNDeclarationPartOne initialData)
        {
            this.initialData = initialData;
        }

        public void PrintIntoPdf()
        {
            PdfReader reader = new PdfReader(Constants.ESHNDeclarationFullPath);
            var size = reader.GetPageSizeWithRotation(1);

            Document document = new Document(size);
            FileStream fs = new FileStream(Constants.CompletedESHNDeclarationPartOneFullPath, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            PdfContentByte cb = writer.DirectContentUnder;
            BaseFont baseFont = BaseFont.CreateFont(Constants.ESHNDeclarationFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(baseFont, 16);

            ESHNDeclarationPrinter.WriteINN(cb, initialData.Requisites.налогоплательщик.ИНН);
            ESHNDeclarationPrinter.WriteKPP(cb, "");

            WritePartOneData(cb);

            cb.AddTemplate(page, 0, 0);
            document.NewPage();

            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }

        private void WritePartOneData(PdfContentByte cb)
        {
            DateTime dateTime = DateTime.Now;
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Day.ToString("00"), 168, Constants.ESHNDeclarationHeight - 702, 2);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Month.ToString("00"), 211, Constants.ESHNDeclarationHeight - 702, 2);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Year.ToString("0000"), 253, Constants.ESHNDeclarationHeight - 702, 4);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ПредставляетсяВНалоговыйОрган, 200, Constants.ESHNDeclarationHeight - 149, Constants.maximumПредставляетсяВНалоговыйОрганLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ОтчетныйГод, 531, Constants.ESHNDeclarationHeight - 126, 4);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ДостоверностьИПолнотуПодтверждает, 41, Constants.ESHNDeclarationHeight - 401, 1);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ФормаРеорганизации, 137, Constants.ESHNDeclarationHeight - 299, 1);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.НомерКорректировки, 120, Constants.ESHNDeclarationHeight - 126, 3);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.НалоговыйПериод, 333, Constants.ESHNDeclarationHeight - 126, 2);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ПоМестуУчета, 545, Constants.ESHNDeclarationHeight - 148, 3);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.ИННРеорганизованнойОрганизации, 299, Constants.ESHNDeclarationHeight - 299, Constants.requiredReorganisedINNLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.КППРеорганизованнойОрганизации, 455, Constants.ESHNDeclarationHeight - 299, Constants.requiredKPPLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.НаименованиеДокументаПодтверждающегоПолномочия, 27, Constants.ESHNDeclarationHeight - 762, Constants.maximumНаименованиеПодтверждающегоLength);
            ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, 27, Constants.ESHNDeclarationHeight - 786, Constants.maximumНаименованиеПодтверждающегоLength);
        }
    }
}
