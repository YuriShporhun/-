using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public static class Constants
    {
        public const string currentProgramVersion = "v15.08.001";

        public const int maximumTaxPeriodLength = 2;
        public const int maximumПоМестуУчетаLength = 3;
        public const int maximumFormOfReorganisationLength = 1;
        public const int requiredINNLength = 12;
        public const int requiredReorganisedINNLength = 10;
        public const int requiredKPPLength = 9;
        public const int maximumCorrectNumberLength = 3;
        public const int maximumOKTMOLength = 11;
        public const int maximumPhoneLength = 20;
        public const int maximumNameLength = 20;
        public const int maximumOrganizationNameLength = 120;
        public const int requiredIncomeTypeCodeLength = 3;
        public const int maximumESHNPartFourIncomeFieldLength = 12;
        public const int mamimumESHNPartTwoLongestFieldLength = 12;
        public const int maximumПредставляетсяВНалоговыйОрганLength = 4;
        public const int maximumНаименованиеПодтверждающегоLength = 20;

        public static Color badFieldColor = Color.FromArgb(247, 195, 195);
        public static Color goodFieldColor = Color.FromArgb(48, 213, 170);
        public static Color commonFieldColor = SystemColors.Window;

        public static bool isDemoVersion = true;

        public static string programDirectory = Environment.CurrentDirectory;
        public static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string dataBaseDirectoryPath = Path.Combine(localAppData, "RosGid");
        public static string dataBaseFullPath = Path.Combine(dataBaseDirectoryPath, "base.mdb");
        public static string oldDataBaseFullPath = Path.Combine(dataBaseDirectoryPath, "old_base.mdb");
        public static string SQLiteDataBaseFullPath = Path.Combine(dataBaseDirectoryPath, "AgriculturalDataBase.db3");
        public static string licenseFullPath = Path.Combine(dataBaseDirectoryPath, "ESHN.dll");
        public static string importFullPath = Path.Combine(dataBaseDirectoryPath, "import.dll");

        public static string declarationOneFullPath = Path.Combine(dataBaseDirectoryPath, "declarationPartOne.xml");

        public static string dataDirectory = programDirectory + "\\DataBase\\";
        public static string backUpDirectory = dataDirectory + "BackUp\\";
        public static string pureBasePath = dataDirectory + "pure_base.mdb";
        public static string pureSQLitePath = dataDirectory + "AgriculturalDataBase.db3";
        public static string pureLicensePath = dataDirectory + "pure_ESHN.dll";
        public static string ESHNDeclarationFullPath = dataDirectory + "pure_declaration.pdf";
        public static string CompletedESHNDeclarationFullPath = dataDirectory + "completed_declaration.pdf";
        public static string CompletedESHNDeclarationPartOneFullPath = dataDirectory + "completed_declaration_part_one.pdf";
        public static string CompletedESHNDeclarationPartFourFullPath = dataDirectory + "completed_declaration_part_four.pdf";
        public static string CompletedESHNDeclarationPartTwoFullPath = dataDirectory + "completed_declaration_part_two.pdf";
        public static string ESHNDeclarationFontPath = dataDirectory + "cour.ttf";

        public const float distanceBetweenESHNDeclarationCells = 14.2F;
        public const int ESHNDeclarationHeight = 845;
        public const int ESHNDeclarationPartFourRowCount = 9;
        public const string SQLiteDateFormat = "dd.MM.yyyy";
    }
}
