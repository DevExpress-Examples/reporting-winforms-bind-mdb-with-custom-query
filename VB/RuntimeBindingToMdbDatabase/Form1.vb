'#Region "#reference"
Imports System.Windows.Forms
Imports System
Imports DevExpress.DataAccess.Sql
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.XtraReports.UI

' ...
'#End Region  ' #reference
Namespace RuntimeBindingToMdbDatabase

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

'#Region "#code"
        Private Function BindToData() As SqlDataSource
            ' Create a data source with the required connection parameters.  
            Dim connectionParameters As Access97ConnectionParameters = New Access97ConnectionParameters("../../nwind.mdb", "", "")
            Dim ds As SqlDataSource = New SqlDataSource(connectionParameters)
            ' Create an SQL query to access the Products table.
            Dim query As CustomSqlQuery = New CustomSqlQuery()
            query.Name = "customQuery"
            query.Sql = "SELECT * FROM Products"
            ' Add the query to the collection and return the data source. 
            ds.Queries.Add(query)
            ' Make the data source structure displayed 
            ' in the Field List of an End-User Report Designer.
            ds.RebuildResultSchema()
            Return ds
        End Function

        Private Function CreateReport() As XtraReport
            ' Create a new report instance.
            Dim report As XtraReport = New XtraReport()
            ' Assign the data source to the report.
            report.DataSource = BindToData()
            report.DataMember = "customQuery"
            ' Add a detail band to the report.
            Dim detailBand As DetailBand = New DetailBand()
            detailBand.Height = 50
            report.Bands.Add(detailBand)
            ' Add a label to the detail band.
            Dim label As XRLabel = New XRLabel With {.WidthF = 300}
            label.DataBindings.Add("Text", Nothing, "customQuery.ProductName")
            detailBand.Controls.Add(label)
            Return report
        End Function

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Show the report's print preview.
            Dim printTool As ReportPrintTool = New ReportPrintTool(CreateReport())
            printTool.ShowPreview()
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Open the report in an End-User Designer.
            Dim designTool As ReportDesignTool = New ReportDesignTool(CreateReport())
            designTool.ShowRibbonDesignerDialog()
        End Sub
'#End Region  ' #code
    End Class
End Namespace
