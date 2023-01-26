
namespace WFConsumo.Recepcion
{
    partial class frmEntregasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregasPendientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sctftdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sctfndoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sctffreg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sctfccli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NomCLiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NomFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sctfcven = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scvdnomb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.peso1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.scmvtdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scmvndoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scmvnart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scmadesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scmvcant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 54);
            this.panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(21, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(314, 26);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Orden De Entregas Pendientes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 55);
            this.panel2.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCerrar.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCerrar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnCerrar.Appearance.Options.UseBackColor = true;
            this.btnCerrar.Appearance.Options.UseBorderColor = true;
            this.btnCerrar.Appearance.Options.UseForeColor = true;
            this.btnCerrar.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCerrar.AppearancePressed.Options.UseBackColor = true;
            this.btnCerrar.AppearancePressed.Options.UseBorderColor = true;
            this.btnCerrar.AppearancePressed.Options.UseForeColor = true;
            this.btnCerrar.AppearancePressed.Options.UseTextOptions = true;
            this.btnCerrar.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCerrar.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCerrar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCerrar.ImageOptions.Image = global::WFConsumo.Properties.Resources.icon__cerrar;
            this.btnCerrar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCerrar.Location = new System.Drawing.Point(53, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.ToolTip = "Nuevo";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnNew.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnNew.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseBorderColor = true;
            this.btnNew.Appearance.Options.UseForeColor = true;
            this.btnNew.AppearancePressed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.AppearancePressed.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.AppearancePressed.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.AppearancePressed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.AppearancePressed.Options.UseBackColor = true;
            this.btnNew.AppearancePressed.Options.UseBorderColor = true;
            this.btnNew.AppearancePressed.Options.UseForeColor = true;
            this.btnNew.AppearancePressed.Options.UseTextOptions = true;
            this.btnNew.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnNew.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNew.Location = new System.Drawing.Point(12, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(35, 35);
            this.btnNew.TabIndex = 25;
            this.btnNew.ToolTip = "Nuevo";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 109);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 443);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1072, 180);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sctftdoc,
            this.sctfndoc,
            this.sctffreg,
            this.sctfccli,
            this.NomCLiente,
            this.NomFactura,
            this.sctfcven,
            this.scvdnomb,
            this.peso1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // sctftdoc
            // 
            this.sctftdoc.Caption = "Tipo Doc";
            this.sctftdoc.FieldName = "sctftdoc";
            this.sctftdoc.Name = "sctftdoc";
            this.sctftdoc.Visible = true;
            this.sctftdoc.VisibleIndex = 0;
            // 
            // sctfndoc
            // 
            this.sctfndoc.Caption = "Nro Doc";
            this.sctfndoc.FieldName = "sctfndoc";
            this.sctfndoc.Name = "sctfndoc";
            this.sctfndoc.Visible = true;
            this.sctfndoc.VisibleIndex = 1;
            // 
            // sctffreg
            // 
            this.sctffreg.Caption = "Fecha";
            this.sctffreg.FieldName = "sctffreg";
            this.sctffreg.Name = "sctffreg";
            this.sctffreg.Visible = true;
            this.sctffreg.VisibleIndex = 2;
            // 
            // sctfccli
            // 
            this.sctfccli.Caption = "Cliente";
            this.sctfccli.FieldName = "sctfccli";
            this.sctfccli.Name = "sctfccli";
            this.sctfccli.Visible = true;
            this.sctfccli.VisibleIndex = 3;
            // 
            // NomCLiente
            // 
            this.NomCLiente.Caption = "Nombre Cliente";
            this.NomCLiente.FieldName = "NomCLiente";
            this.NomCLiente.Name = "NomCLiente";
            this.NomCLiente.Visible = true;
            this.NomCLiente.VisibleIndex = 4;
            // 
            // NomFactura
            // 
            this.NomFactura.Caption = "Nombre Factura";
            this.NomFactura.FieldName = "NomFactura";
            this.NomFactura.Name = "NomFactura";
            this.NomFactura.Visible = true;
            this.NomFactura.VisibleIndex = 5;
            // 
            // sctfcven
            // 
            this.sctfcven.Caption = "Vendedor";
            this.sctfcven.FieldName = "sctfcven";
            this.sctfcven.Name = "sctfcven";
            this.sctfcven.Visible = true;
            this.sctfcven.VisibleIndex = 6;
            // 
            // scvdnomb
            // 
            this.scvdnomb.Caption = "Nombre Vendedor";
            this.scvdnomb.FieldName = "scvdnomb";
            this.scvdnomb.Name = "scvdnomb";
            this.scvdnomb.Visible = true;
            this.scvdnomb.VisibleIndex = 7;
            // 
            // peso1
            // 
            this.peso1.Caption = "Peso";
            this.peso1.FieldName = "peso1";
            this.peso1.Name = "peso1";
            this.peso1.Visible = true;
            this.peso1.VisibleIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl2);
            this.splitContainer2.Size = new System.Drawing.Size(1072, 259);
            this.splitContainer2.SplitterDistance = 832;
            this.splitContainer2.TabIndex = 4;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(832, 259);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.Options.UseTextOptions = true;
            this.gridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.scmvtdoc,
            this.scmvndoc,
            this.scmvnart,
            this.scmadesc,
            this.scmvcant,
            this.cantidad});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            // 
            // scmvtdoc
            // 
            this.scmvtdoc.Caption = "Tipo Doc";
            this.scmvtdoc.FieldName = "scmvtdoc";
            this.scmvtdoc.Name = "scmvtdoc";
            this.scmvtdoc.Visible = true;
            this.scmvtdoc.VisibleIndex = 0;
            // 
            // scmvndoc
            // 
            this.scmvndoc.Caption = "Nro Doc";
            this.scmvndoc.FieldName = "scmvndoc";
            this.scmvndoc.Name = "scmvndoc";
            this.scmvndoc.Visible = true;
            this.scmvndoc.VisibleIndex = 2;
            // 
            // scmvnart
            // 
            this.scmvnart.Caption = "Articulo";
            this.scmvnart.FieldName = "scmvnart";
            this.scmvnart.Name = "scmvnart";
            this.scmvnart.Visible = true;
            this.scmvnart.VisibleIndex = 1;
            // 
            // scmadesc
            // 
            this.scmadesc.Caption = "Descripcion";
            this.scmadesc.FieldName = "scmadesc";
            this.scmadesc.Name = "scmadesc";
            this.scmadesc.Visible = true;
            this.scmadesc.VisibleIndex = 3;
            // 
            // scmvcant
            // 
            this.scmvcant.Caption = "Cantidad";
            this.scmvcant.FieldName = "scmvcant";
            this.scmvcant.Name = "scmvcant";
            this.scmvcant.Visible = true;
            this.scmvcant.VisibleIndex = 4;
            // 
            // cantidad
            // 
            this.cantidad.Caption = "Cantidad Entregada";
            this.cantidad.FieldName = "cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Visible = true;
            this.cantidad.VisibleIndex = 5;
            // 
            // frmEntregasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 552);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEntregasPendientes";
            this.Text = "frmAdmAnotacion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private DevExpress.XtraGrid.Columns.GridColumn sctftdoc;
        private DevExpress.XtraGrid.Columns.GridColumn sctfndoc;
        private DevExpress.XtraGrid.Columns.GridColumn sctffreg;
        private DevExpress.XtraGrid.Columns.GridColumn NomCLiente;
        private DevExpress.XtraGrid.Columns.GridColumn NomFactura;
        private DevExpress.XtraGrid.Columns.GridColumn sctfcven;
        private DevExpress.XtraGrid.Columns.GridColumn scvdnomb;
        private DevExpress.XtraGrid.Columns.GridColumn sctfccli;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraGrid.Columns.GridColumn peso1;
        private DevExpress.XtraGrid.Columns.GridColumn scmvtdoc;
        private DevExpress.XtraGrid.Columns.GridColumn scmvndoc;
        private DevExpress.XtraGrid.Columns.GridColumn scmvnart;
        private DevExpress.XtraGrid.Columns.GridColumn scmadesc;
        private DevExpress.XtraGrid.Columns.GridColumn scmvcant;
        private DevExpress.XtraGrid.Columns.GridColumn cantidad;
    }
}