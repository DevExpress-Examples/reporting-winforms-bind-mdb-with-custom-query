using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
// ...

namespace XtraReport_RuntimeDataBinding {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create an empty report.
            XtraReport report = new XtraReport();

            // Create data objects.
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Categories",
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\nwind.mdb");
            DataSet ds = new DataSet();
            adapter.FillSchema(ds, SchemaType.Source);

            // Bind the report to data.
            report.DataSource = ds;
            report.DataAdapter = adapter;
            report.DataMember = "Table";

            // Add a detail band to the report.
            DetailBand detailBand = new DetailBand();
            detailBand.Height = 50;
            report.Bands.Add(detailBand);

            // Add a label to the detail band.
            XRLabel label = new XRLabel();
            label.DataBindings.Add("Text", null, "CategoryName");
            detailBand.Controls.Add(label);

            // Show the report's print preview.
            report.ShowPreview();
        }
    }
}