namespace _LINQ_QuanLy_QuanTraSua
{
    partial class Form_HoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.INHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLQTS_HD = new _LINQ_QuanLy_QuanTraSua.QLQTS_HD();
            this.INHDTableAdapter = new _LINQ_QuanLy_QuanTraSua.QLQTS_HDTableAdapters.INHDTableAdapter();
            this.rpvHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.INHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLQTS_HD)).BeginInit();
            this.SuspendLayout();
            // 
            // INHDBindingSource
            // 
            this.INHDBindingSource.DataMember = "INHD";
            this.INHDBindingSource.DataSource = this.QLQTS_HD;
            // 
            // QLQTS_HD
            // 
            this.QLQTS_HD.DataSetName = "QLQTS_HD";
            this.QLQTS_HD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // INHDTableAdapter
            // 
            this.INHDTableAdapter.ClearBeforeFill = true;
            // 
            // rpvHoaDon
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.INHDBindingSource;
            this.rpvHoaDon.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvHoaDon.LocalReport.ReportEmbeddedResource = "_LINQ_QuanLy_QuanTraSua.InHoaDon.rdlc";
            this.rpvHoaDon.Location = new System.Drawing.Point(12, 69);
            this.rpvHoaDon.Name = "rpvHoaDon";
            this.rpvHoaDon.ServerReport.BearerToken = null;
            this.rpvHoaDon.Size = new System.Drawing.Size(1018, 572);
            this.rpvHoaDon.TabIndex = 3;
            // 
            // Form_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 653);
            this.Controls.Add(this.rpvHoaDon);
            this.Name = "Form_HoaDon";
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.Form_HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.INHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLQTS_HD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource INHDBindingSource;
        private QLQTS_HD QLQTS_HD;
        private QLQTS_HDTableAdapters.INHDTableAdapter INHDTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rpvHoaDon;
    }
}