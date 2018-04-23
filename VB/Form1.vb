Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
' ...

Namespace XtraReport_RuntimeDataBinding
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create an empty report.
			Dim report As New XtraReport()

			' Create data objects.
			Dim adapter As New OleDbDataAdapter("SELECT * FROM Categories", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\nwind.mdb")
			Dim ds As New DataSet()
			adapter.FillSchema(ds, SchemaType.Source)

			' Bind the report to data.
			report.DataSource = ds
			report.DataAdapter = adapter
			report.DataMember = "Table"

			' Add a detail band to the report.
			Dim detailBand As New DetailBand()
			detailBand.Height = 50
			report.Bands.Add(detailBand)

			' Add a label to the detail band.
			Dim label As New XRLabel()
			label.DataBindings.Add("Text", Nothing, "CategoryName")
			detailBand.Controls.Add(label)

			' Show the report's print preview.
			report.ShowPreview()
		End Sub
	End Class
End Namespace