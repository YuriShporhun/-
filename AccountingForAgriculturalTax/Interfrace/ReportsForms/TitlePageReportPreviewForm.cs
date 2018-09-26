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
    public partial class TitlePageReportPreviewForm : Form
    {
        TitlePageReportUserData titlePageUserData;
        public TitlePageReportPreviewForm(TitlePageReportUserData titlePageUserData)
        {
            InitializeComponent();
            this.titlePageUserData = titlePageUserData;
        }

        private void TitlePageReportPreviewForm_Load(object sender, EventArgs e)
        {
            ReportParameter year = new ReportParameter("year", titlePageUserData.Year);
            ReportParameter inn = new ReportParameter("inn", titlePageUserData.INN);
            ReportParameter fio = new ReportParameter("fio", titlePageUserData.FIO);
            ReportParameter isDemo = new ReportParameter("isDemo", Constants.isDemoVersion.ToString());
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { year, inn, fio, isDemo });
            this.reportViewer1.RefreshReport();
        }
    }
}
