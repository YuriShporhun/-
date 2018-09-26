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
    public partial class CommonAssetsReportPreviewForm : Form
    {
        List<CommonAssets> commonAssets;

        public CommonAssetsReportPreviewForm(List<CommonAssets> commonAssets)
        {
            InitializeComponent();
            this.commonAssets = commonAssets;
        }

        private void CommonAssetsReportForm_Load(object sender, EventArgs e)
        {
            ReportParameter isDemo = new ReportParameter("isDemo", Constants.isDemoVersion.ToString());

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { isDemo });

            this.CommonAssetsBindingSource.DataSource = commonAssets;
            this.reportViewer1.RefreshReport();
        }
    }
}
