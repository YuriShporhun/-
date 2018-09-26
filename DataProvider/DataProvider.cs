using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    internal static class DataProvider
    {
        public static string SQLiteConnectionString = "Data Source=" + Constants.SQLiteDataBaseFullPath + ";Version=3;";

        public static void AddCommandTextInsert(StringBuilder commandText, string variable, bool last = false)
        {
            commandText.Append("'");
            commandText.Append(variable);
            if (!last)
            {
                commandText.Append("',");
            }
            else
            {
                commandText.Append("'");
            }
        }

        public static void AddCommandTextUpdate(StringBuilder commandText, string fieldToUpdate, string variable, bool last = false)
        {
            commandText.Append("[" + fieldToUpdate + "] = '");
            commandText.Append(variable);
            if (!last)
            {
                commandText.Append("',");
            }
            else
            {
                commandText.Append("'");
            }
        }

        public static void AddCommandTextDelete(StringBuilder commandText, string index)
        {
            commandText.Append(index);
            commandText.Append(";");
        }

        public static string ConvertDateToSQLiteFormat(string date)
        {
            if (date == String.Empty || date == "Не задано") return "Не задано";

            string timeFormat = "dd.MM.yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime temporaryTimeString = DateTime.ParseExact(date, timeFormat, provider);
            return temporaryTimeString.ToString("yyyy-MM-dd");
        }

        public static string ConvertDateToProgramFormat(string date)
        {
            if (date == String.Empty || date == "Не задано") return "Не задано";

            string timeFormat = "yyyy-MM-dd";
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(date, timeFormat, provider).ToShortDateString();
        }

        public static string ConvertDateThatCantBeEmpty(string date)
        {
            string result = String.Empty;

            if (date != String.Empty)
            {
                result = DataProvider.ConvertDateToProgramFormat(date);
            }
            else
            {
                result = "Не задано";
            }

            return result;
        }
    }
}
