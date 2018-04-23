#region #reference
using System.Windows.Forms;
using System;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Configuration;

// ...
#endregion #reference

namespace RuntimeBindingToMdbDatabase {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

#region #code
private SqlDataSource BindToData() {
    // Create a data source with the required connection parameters.  
    Access97ConnectionParameters connectionParameters = 
        new Access97ConnectionParameters("../../nwind.mdb", "", "");
    SqlDataSource ds = new SqlDataSource(connectionParameters);

    // Create an SQL query to access the Products table.
    CustomSqlQuery query = new CustomSqlQuery();
    query.Name = "customQuery";
    query.Sql = "SELECT * FROM Products";

    // Add the query to the collection and return the data source. 
    ds.Queries.Add(query);
    
    // Make the data source structure displayed 
    // in the Field List of an End-User Report Designer.
    ds.RebuildResultSchema();

    return ds;
}

private XtraReport CreateReport() {
    // Create a new report instance.
    XtraReport report = new XtraReport();

    // Assign the data source to the report.
    report.DataSource = BindToData();
    report.DataMember = "customQuery";

    // Add a detail band to the report.
    DetailBand detailBand = new DetailBand();
    detailBand.Height = 50;
    report.Bands.Add(detailBand);

    // Create a new label.
    XRLabel label = new XRLabel { WidthF = 300 };
    // Specify the label's binding depending on the data binding mode.
    if (Settings.Default.UserDesignerOptions.DataBindingMode == DataBindingMode.Bindings)
       label.DataBindings.Add("Text", null, "customQuery.ProductName");
    else label.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[ProductName]"));
    // Add the label to the detail band.
    detailBand.Controls.Add(label);

    return report;
}

private void button1_Click(object sender, EventArgs e) {
    // Show the report's print preview.
    ReportPrintTool printTool = new ReportPrintTool(CreateReport());
    printTool.ShowPreview();
}

private void button2_Click(object sender, EventArgs e) {
    // Open the report in an End-User Designer.
    ReportDesignTool designTool = new ReportDesignTool(CreateReport());
    designTool.ShowRibbonDesignerDialog();
}
#endregion #code

    }
}
