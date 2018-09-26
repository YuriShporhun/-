using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public class ESHNDeclarationPartFourPrinter
    {
        ESHNDeclarationPartFour initialData;
        public ESHNDeclarationPartFourPrinter(ESHNDeclarationPartFour initialData)
        {
            this.initialData = initialData;
        }

        public void PrintIntoPdf()
        {
            PdfReader reader = new PdfReader(Constants.ESHNDeclarationFullPath);
            var size = reader.GetPageSizeWithRotation(1);

            Document document = new Document(size);
            FileStream fs = new FileStream(Constants.CompletedESHNDeclarationPartFourFullPath , FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //for (int pageNumber = 1; pageNumber <= reader.NumberOfPages; pageNumber++)
            //{
            PdfImportedPage page = writer.GetImportedPage(reader, 4);
            PdfContentByte cb = writer.DirectContentUnder;
            BaseFont baseFont = BaseFont.CreateFont(Constants.ESHNDeclarationFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(baseFont, 16);

            ESHNDeclarationPrinter.WritePageNumber(cb, 4);
            ESHNDeclarationPrinter.WriteINN(cb, initialData.Requisites.налогоплательщик.ИНН);
            ESHNDeclarationPrinter.WriteKPP(cb, "");

            WriteIncomeData(cb);

            cb.AddTemplate(page, 0, 0);
            document.NewPage();
            //}

            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
        }

        private void WriteIncomeData(PdfContentByte cb)
        {
            float Y = Constants.ESHNDeclarationHeight - 190;
            for (int i = 0; i < Constants.ESHNDeclarationPartFourRowCount; i++)
            {
                float incomeTypeCodeX = 21;
                float secondRowY = Y - 25;
                float goodsReceiptDateDayX = 78;
                float goodsReceiptDateMonthX = 120;
                float goodsReceiptDateYearX = 163;
                float periodOfUseDayX = 78;
                float periodOfUseMonthX = 120;
                float periodOfUseYearX = 163;
                float valueOfPropertyX = 234;
                float amountOfUsedFundsX = 418;
                float amountOfFundsWherePeriodHasNotExpiredX = 234;
                float amountOfBadUsedOrNotUsedFundsX = 418;

                if (i < initialData.useOfProperty.Count)
                {
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.useOfProperty[i].IncomeTypeCode, incomeTypeCodeX, Y, Constants.requiredIncomeTypeCodeLength);
                    DateTime dateTime = DateTime.Parse(initialData.useOfProperty[i].GoodsReceiptDate);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Day.ToString("00"), goodsReceiptDateDayX, Y, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Month.ToString("00"), goodsReceiptDateMonthX, Y, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Year.ToString(), goodsReceiptDateYearX, Y, 4);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.useOfProperty[i].ValueOfProperty, valueOfPropertyX, Y, Constants.maximumESHNPartFourIncomeFieldLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.useOfProperty[i].AmountOfUsedFunds, amountOfUsedFundsX, Y, Constants.maximumESHNPartFourIncomeFieldLength);
                    dateTime = DateTime.Parse(initialData.useOfProperty[i].PeriodOfUse);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Day.ToString("00"), periodOfUseDayX, secondRowY, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Month.ToString("00"), periodOfUseMonthX, secondRowY, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, dateTime.Year.ToString("00"), periodOfUseYearX, secondRowY, 4);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.useOfProperty[i].AmountOfFundsWherePeriodHasNotExpired, amountOfFundsWherePeriodHasNotExpiredX, secondRowY, Constants.maximumESHNPartFourIncomeFieldLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, initialData.useOfProperty[i].AmountOfBadUsedOrNotUsedFunds, amountOfBadUsedOrNotUsedFundsX, secondRowY, Constants.maximumESHNPartFourIncomeFieldLength);
                }
                else
                {
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, incomeTypeCodeX, Y, Constants.requiredIncomeTypeCodeLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, goodsReceiptDateDayX, Y, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, goodsReceiptDateMonthX, Y, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, goodsReceiptDateYearX, Y, 4);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, valueOfPropertyX, Y, Constants.maximumESHNPartFourIncomeFieldLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfUsedFundsX, Y, Constants.maximumESHNPartFourIncomeFieldLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, periodOfUseDayX, secondRowY, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, periodOfUseMonthX, secondRowY, 2);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, periodOfUseYearX, secondRowY, 4);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfFundsWherePeriodHasNotExpiredX, secondRowY, Constants.maximumESHNPartFourIncomeFieldLength);
                    ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfBadUsedOrNotUsedFundsX, secondRowY, Constants.maximumESHNPartFourIncomeFieldLength);
                }
                Y -= 59.5f;
            }

            Int64 valueOfPropertySum = 0;
            Int64 amountOfFundsWherePeriodHasNotExpiredSum = 0;
            Int64 amountOfUsedFundsSum = 0;
            Int64 amountOfBadUsedOrNotUsedFundsSum = 0;

            foreach(var item in initialData.useOfProperty)
            {
                if(item.ValueOfProperty != String.Empty)
                {
                    valueOfPropertySum += Convert.ToInt64(item.ValueOfProperty);
                }
                if(item.AmountOfFundsWherePeriodHasNotExpired != String.Empty)
                {
                    amountOfFundsWherePeriodHasNotExpiredSum += Convert.ToInt64(item.AmountOfFundsWherePeriodHasNotExpired);
                }
                if(item.AmountOfUsedFunds != String.Empty)
                {
                    amountOfUsedFundsSum += Convert.ToInt64(item.AmountOfUsedFunds);
                }
                if(item.AmountOfBadUsedOrNotUsedFunds != String.Empty)
                {
                    amountOfBadUsedOrNotUsedFundsSum += Convert.ToInt64(item.AmountOfBadUsedOrNotUsedFunds);
                }
            }

            float valueOfPropertySumY = Constants.ESHNDeclarationHeight - 725;
            float valueOfPropertySumX = 234;
            float amountOfFundsWherePeriodHasNotExpiredSumY = Constants.ESHNDeclarationHeight - 750;
            float amountOfFundsWherePeriodHasNotExpiredSumX = 234;
            float amountOfUsedFundsSumY = Constants.ESHNDeclarationHeight - 725;
            float amountOfUsedFundsSumX = 418;
            float amountOfBadUsedOrNotUsedFundsSumY = Constants.ESHNDeclarationHeight - 750;
            float amountOfBadUsedOrNotUsedFundsSumX = 418;

            if(valueOfPropertySum != 0)
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, valueOfPropertySum.ToString(), valueOfPropertySumX, valueOfPropertySumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }
            else
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, valueOfPropertySumX, valueOfPropertySumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }

            if (amountOfFundsWherePeriodHasNotExpiredSum != 0)
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, amountOfFundsWherePeriodHasNotExpiredSum.ToString(), amountOfFundsWherePeriodHasNotExpiredSumX, amountOfFundsWherePeriodHasNotExpiredSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }
            else
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfFundsWherePeriodHasNotExpiredSumX, amountOfFundsWherePeriodHasNotExpiredSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }

            if(amountOfUsedFundsSum != 0)
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, amountOfUsedFundsSum.ToString(), amountOfUsedFundsSumX, amountOfUsedFundsSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }
            else
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfUsedFundsSumX, amountOfUsedFundsSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }

            if(amountOfBadUsedOrNotUsedFundsSum != 0)
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, amountOfBadUsedOrNotUsedFundsSum.ToString(), amountOfBadUsedOrNotUsedFundsSumX, amountOfBadUsedOrNotUsedFundsSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }
            else
            {
                ESHNDeclarationPrinter.WriteStringIntoTemplate(cb, String.Empty, amountOfBadUsedOrNotUsedFundsSumX, amountOfBadUsedOrNotUsedFundsSumY, Constants.maximumESHNPartFourIncomeFieldLength);
            }
        }
    }
}
