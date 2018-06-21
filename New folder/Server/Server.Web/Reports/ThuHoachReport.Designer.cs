namespace Vino.Server.Web.Reports
{
	partial class ThuHoachReport
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for telerik Reporting designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
			Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
			Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
			this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
			this.detail = new Telerik.Reporting.DetailSection();
			this.textBox1 = new Telerik.Reporting.TextBox();
			this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
			this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
			this.textBox2 = new Telerik.Reporting.TextBox();
			this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// pageHeaderSection1
			// 
			this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
			this.pageHeaderSection1.Name = "pageHeaderSection1";
			// 
			// detail
			// 
			this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.34996065497398376D);
			this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
			this.detail.Name = "detail";
			// 
			// textBox1
			// 
			this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
			this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
			this.textBox1.Value = "= Fields.Definition.Title + \": \" + Fields.Value";
			// 
			// pageFooterSection1
			// 
			this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1D);
			this.pageFooterSection1.Name = "pageFooterSection1";
			// 
			// reportHeaderSection1
			// 
			this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.25003942847251892D);
			this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2});
			this.reportHeaderSection1.Name = "reportHeaderSection1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
			this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
			this.textBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
			this.textBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
			this.textBox2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
			this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
			this.textBox2.Style.Font.Bold = true;
			this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
			this.textBox2.Value = "7. Thu hoạch";
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataMember = "GetBook";
			this.objectDataSource1.DataSource = typeof(Vino.Server.Web.Reports.DataAccessLayer);
			this.objectDataSource1.Name = "objectDataSource1";
			this.objectDataSource1.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("sessionId", typeof(int), "= Parameters.sessionId.Value"),
            new Telerik.Reporting.ObjectDataSourceParameter("bookType", typeof(string), "= Parameters.bookType.Value")});
			// 
			// ThuHoachReport
			// 
			this.DataSource = this.objectDataSource1;
			this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.reportHeaderSection1});
			this.Name = "ThuHoachReport";
			this.PageSettings.ContinuousPaper = false;
			this.PageSettings.Landscape = false;
			this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
			this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
			reportParameter1.Name = "sessionId";
			reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
			reportParameter1.Value = "0";
			reportParameter2.Name = "bookType";
			this.ReportParameters.Add(reportParameter1);
			this.ReportParameters.Add(reportParameter2);
			styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
			styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
			styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
			this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
			this.Width = Telerik.Reporting.Drawing.Unit.Inch(6D);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
		private Telerik.Reporting.DetailSection detail;
		private Telerik.Reporting.PageFooterSection pageFooterSection1;
		private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
		private Telerik.Reporting.TextBox textBox2;
		private Telerik.Reporting.TextBox textBox1;
		private Telerik.Reporting.ObjectDataSource objectDataSource1;
	}
}