using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class IncomeAndExpenseReportPreviewForm : Form
    {
        IncomeAndExpenseTimePeriod timePeriod;
        SemesterToLoad semesterToLoad;
        string INN;

        public IncomeAndExpenseReportPreviewForm(IncomeAndExpenseTimePeriod timePeriod, SemesterToLoad semesterToLoad, string INN)
        {
            InitializeComponent();
            this.timePeriod = timePeriod;
            this.semesterToLoad = semesterToLoad;
            this.INN = INN;
        }

        private void IncomeAndExpenseReportForm_Load(object sender, EventArgs e)
        {
            IncomeAndExpenseSQLiteDataProvider incomeAndExpenseDataProvider = new IncomeAndExpenseSQLiteDataProvider();
            List<IncomeAndExpense> incomeAndExpense = incomeAndExpenseDataProvider.Load(timePeriod, INN);

            incomeAndExpense.Sort(delegate(IncomeAndExpense ps1, IncomeAndExpense ps2) { return DateTime.Compare(DateTime.Parse(ps1.Date), DateTime.Parse(ps2.Date)); });
            foreach(var i in incomeAndExpense)
            {
                i.Income = Convert.ToDouble(i.Income).ToString("F2");
                i.Expense = Convert.ToDouble(i.Expense).ToString("F2");
            }
            IncomeAndExpenseBindingSource.DataSource = incomeAndExpense;

            string semesterName = "";

            switch(semesterToLoad)
            {
                case SemesterToLoad.FirstSemester:
                    {
                        semesterName += "I полугодие";
                    }break;
                case SemesterToLoad.SecondSemester:
                    {
                        semesterName += "II полугодие";
                    }break;
                case SemesterToLoad.BothSemesters:
                case SemesterToLoad.Period:
                    {
                        semesterName += "весь " + timePeriod.Year + " год";
                    }break;
            }
            ReportParameter rp0 = new ReportParameter("rp0", semesterName);
            ReportParameter isDemo = new ReportParameter("isDemo", Constants.isDemoVersion.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp0, isDemo });
            this.reportViewer1.RefreshReport();
        }
    }
}
