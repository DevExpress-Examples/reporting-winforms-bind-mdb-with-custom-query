<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to programmatically bind a report to an MDB file using a CustomSqlQuery


<p>This example demonstrates how to create a new blank report (an instance of the <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXtraReporttopic">XtraReport</a> class), bind it to an MDB file, and fill the report's <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIDetailBandtopic">DetailBand</a> with an <a href="https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXRLabeltopic">XRLabel</a> control displaying data from this file. </p>
<p>Create a <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataAccessSqlSqlDataSourcetopic">SqlDataSource</a> class instance with the required connection parameters and construct a custom SQL query using the <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataAccessSqlCustomSqlQuerytopic">CustomSqlQuery</a> class. To assign the created data source to the report, use the report's <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUIXtraReportBase_DataSourcetopic">DataSource</a> and <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUIXtraReportBase_DataMembertopic">DataMember</a> properties.<br><br>Starting with v.17.2, the report uses <a href="https://documentation.devexpress.com/XtraReports/119236/Creating-Reports-in-Visual-Studio/Detailed-Guide-to-DevExpress-Reporting/Providing-Data-to-Reports/Data-Binding-Overview/Data-Binding-Modes">expression bindings</a> to provide data to controls. You can switch to the legacy binding mode by setting the <a href="https://documentation.devexpress.com/XtraReports/DevExpress.XtraReports.Configuration.UserDesignerOptions.DataBindingMode.property">UserDesignerOptions.DataBindingMode</a> property to <strong>Bindings </strong>at the application startup.<br><strong><br>See Also</strong></p>
<p><a href="https://www.devexpress.com/Support/Center/Example/Details/T437883">How to programmatically bind a report to an MDB file using a SelectQuery</a></p>

<br/>


