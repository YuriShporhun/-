using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class IncomeAndExpenseTimePeriod
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Year { get; private set; }

        public IncomeAndExpenseTimePeriod(int Year)
        {
            this.Year = Year;
            this.StartDate = new DateTime(Year, 1, 1);
            this.EndDate = new DateTime(Year, 12, 31);
        }

        public IncomeAndExpenseTimePeriod(int Year, DateTime StartDate, DateTime EndDate)
        {
            this.Year = Year;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public void SetPeriod(DateTime StartDate, DateTime EndDate)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public void SetFirstSemesterPeriod()
        {
            StartDate = new DateTime(Year, 1, 1);
            EndDate = new DateTime(Year, 5, 31);
        }

        public void SetSecondSemesterPeriod()
        {
            StartDate = new DateTime(Year, 6, 1);
            EndDate = new DateTime(Year, 12, 31);
        }

        public void SetBothSemesterPeriod()
        {
            this.StartDate = new DateTime(Year, 1, 1);
            this.EndDate = new DateTime(Year, 12, 31);
        }
    }
}
