
namespace WFConsumo.Recepcion
{
    partial class frmPaquetes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbinactivo = new System.Windows.Forms.RadioButton();
            this.rbactivo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbetiqueta2 = new System.Windows.Forms.RadioButton();
            this.rbetiqueta1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridPaquetes = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelReport = new System.Windows.Forms.Panel();
            this.crviwer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.xpView1 = new DevExpress.Xpo.XPView(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPaquetes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 54);
            this.panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(21, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(234, 26);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "PAQUETES ACTIVOS";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(820, 55);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbinactivo);
            this.groupBox2.Controls.Add(this.rbactivo);
            this.groupBox2.Location = new System.Drawing.Point(271, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 43);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PAQUETES";
            // 
            // rbinactivo
            // 
            this.rbinactivo.AutoSize = true;
            this.rbinactivo.Location = new System.Drawing.Point(92, 20);
            this.rbinactivo.Name = "rbinactivo";
            this.rbinactivo.Size = new System.Drawing.Size(82, 17);
            this.rbinactivo.TabIndex = 1;
            this.rbinactivo.TabStop = true;
            this.rbinactivo.Text = "INACTIVOS";
            this.rbinactivo.UseVisualStyleBackColor = true;
            this.rbinactivo.CheckedChanged += new System.EventHandler(this.rbinactivo_CheckedChanged);
            // 
            // rbactivo
            // 
            this.rbactivo.AutoSize = true;
            this.rbactivo.Location = new System.Drawing.Point(16, 20);
            this.rbactivo.Name = "rbactivo";
            this.rbactivo.Size = new System.Drawing.Size(71, 17);
            this.rbactivo.TabIndex = 0;
            this.rbactivo.TabStop = true;
            this.rbactivo.Text = "ACTIVOS";
            this.rbactivo.UseVisualStyleBackColor = true;
            this.rbactivo.CheckedChanged += new System.EventHandler(this.rbactivo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbetiqueta2);
            this.groupBox1.Controls.Add(this.rbetiqueta1);
            this.groupBox1.Location = new System.Drawing.Point(80, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 43);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Etiqueta";
            // 
            // rbetiqueta2
            // 
            this.rbetiqueta2.AutoSize = true;
            this.rbetiqueta2.Location = new System.Drawing.Point(92, 20);
            this.rbetiqueta2.Name = "rbetiqueta2";
            this.rbetiqueta2.Size = new System.Drawing.Size(76, 17);
            this.rbetiqueta2.TabIndex = 1;
            this.rbetiqueta2.TabStop = true;
            this.rbetiqueta2.Text = "10 * 14 cm";
            this.rbetiqueta2.UseVisualStyleBackColor = true;
            this.rbetiqueta2.CheckedChanged += new System.EventHandler(this.rbeqtiqueta2_CheckedChanged);
            // 
            // rbetiqueta1
            // 
            this.rbetiqueta1.AutoSize = true;
            this.rbetiqueta1.Location = new System.Drawing.Point(16, 20);
            this.rbetiqueta1.Name = "rbetiqueta1";
            this.rbetiqueta1.Size = new System.Drawing.Size(70, 17);
            this.rbetiqueta1.TabIndex = 0;
            this.rbetiqueta1.TabStop = true;
            this.rbetiqueta1.Text = "10 * 3 cm";
            this.rbetiqueta1.UseVisualStyleBackColor = true;
            this.rbetiqueta1.CheckedChanged += new System.EventHandler(this.rbetiqueta1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::WFConsumo.Properties.Resources.icon_print;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(26, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 43);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 109);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridPaquetes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelReport);
            this.splitContainer1.Size = new System.Drawing.Size(820, 427);
            this.splitContainer1.SplitterDistance = 482;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridPaquetes
            // 
            this.gridPaquetes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPaquetes.Location = new System.Drawing.Point(0, 0);
            this.gridPaquetes.MainView = this.gridView1;
            this.gridPaquetes.Name = "gridPaquetes";
            this.gridPaquetes.Size = new System.Drawing.Size(482, 427);
            this.gridPaquetes.TabIndex = 2;
            this.gridPaquetes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.GridControl = this.gridPaquetes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // panelReport
            // 
            this.panelReport.Controls.Add(this.crviwer);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 0);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(334, 427);
            this.panelReport.TabIndex = 0;
            // 
            // crviwer
            // 
            this.crviwer.ActiveViewIndex = -1;
            this.crviwer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crviwer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crviwer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crviwer.Location = new System.Drawing.Point(0, 0);
            this.crviwer.Name = "crviwer";
            this.crviwer.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintOutputController;
            this.crviwer.ShowCloseButton = false;
            this.crviwer.ShowCopyButton = false;
            this.crviwer.ShowExportButton = false;
            this.crviwer.ShowGotoPageButton = false;
            this.crviwer.ShowGroupTreeButton = false;
            this.crviwer.ShowLogo = false;
            this.crviwer.ShowPageNavigateButtons = false;
            this.crviwer.ShowParameterPanelButton = false;
            this.crviwer.ShowTextSearchButton = false;
            this.crviwer.Size = new System.Drawing.Size(334, 427);
            this.crviwer.TabIndex = 0;
            this.crviwer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 536);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPaquetes";
            this.Text = "frmAdmAnotacion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPaquetes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panelReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridPaquetes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panelReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crviwer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbetiqueta2;
        private System.Windows.Forms.RadioButton rbetiqueta1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbinactivo;
        private System.Windows.Forms.RadioButton rbactivo;
        private DevExpress.Xpo.XPView xpView1;
    }
}