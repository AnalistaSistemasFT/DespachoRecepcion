namespace WFConsumo.frmGRH
{
    partial class BuscarControlPaquete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarControlPaquete));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.checkCodFerro = new DevExpress.XtraEditors.CheckEdit();
            this.checkCodigo = new DevExpress.XtraEditors.CheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Celda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodFerro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 19);
            this.labelControl1.TabIndex = 81;
            this.labelControl1.Text = "Codigos en sucursal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 50);
            this.panel1.TabIndex = 83;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.searchControl1);
            this.panel2.Controls.Add(this.checkCodFerro);
            this.panel2.Controls.Add(this.checkCodigo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 50);
            this.panel2.TabIndex = 84;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscar.Location = new System.Drawing.Point(708, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 25);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Imprimir";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(296, 14);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(249, 25);
            this.searchControl1.TabIndex = 7;
            this.searchControl1.TextChanged += new System.EventHandler(this.searchControl1_TextChanged);
            // 
            // checkCodFerro
            // 
            this.checkCodFerro.EditValue = true;
            this.checkCodFerro.Location = new System.Drawing.Point(146, 16);
            this.checkCodFerro.Name = "checkCodFerro";
            this.checkCodFerro.Properties.Caption = "Codigo Ferrotodo";
            this.checkCodFerro.Size = new System.Drawing.Size(103, 19);
            this.checkCodFerro.TabIndex = 6;
            this.checkCodFerro.CheckedChanged += new System.EventHandler(this.checkCodFerro_CheckedChanged);
            // 
            // checkCodigo
            // 
            this.checkCodigo.Location = new System.Drawing.Point(12, 16);
            this.checkCodigo.Name = "checkCodigo";
            this.checkCodigo.Properties.Caption = "Codigo Producción";
            this.checkCodigo.Size = new System.Drawing.Size(116, 19);
            this.checkCodigo.TabIndex = 5;
            this.checkCodigo.CheckedChanged += new System.EventHandler(this.checkCodigo_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 100);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(809, 561);
            this.gridControl1.TabIndex = 85;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo_,
            this.CodigoFerro,
            this.Descripcion,
            this.Celda,
            this.Cantidad,
            this.Paquete});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Codigo_, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // Codigo_
            // 
            this.Codigo_.AppearanceHeader.BackColor = System.Drawing.Color.LightBlue;
            this.Codigo_.AppearanceHeader.Options.UseBackColor = true;
            this.Codigo_.Caption = "Codigo";
            this.Codigo_.FieldName = "p_Codigo";
            this.Codigo_.FieldNameSortGroup = "ItemId";
            this.Codigo_.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.Codigo_.Name = "Codigo_";
            this.Codigo_.OptionsColumn.AllowEdit = false;
            this.Codigo_.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.Codigo_.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.Codigo_.Visible = true;
            this.Codigo_.VisibleIndex = 0;
            this.Codigo_.Width = 139;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferro";
            this.CodigoFerro.FieldName = "p_CodigoFerro";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 143;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "p_Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 375;
            // 
            // Celda
            // 
            this.Celda.Caption = "Celda";
            this.Celda.FieldName = "p_Celda";
            this.Celda.Name = "Celda";
            this.Celda.Visible = true;
            this.Celda.VisibleIndex = 3;
            this.Celda.Width = 147;
            // 
            // Cantidad
            // 
            this.Cantidad.Caption = "Cantidad";
            this.Cantidad.FieldName = "p_Cantidad";
            this.Cantidad.FieldNameSortGroup = "Cantidad;";
            this.Cantidad.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = true;
            this.Cantidad.VisibleIndex = 4;
            this.Cantidad.Width = 89;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_Paquete";
            this.Paquete.Name = "Paquete";
            this.Paquete.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "p_Paquete", "Total: {0:n0}")});
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 5;
            this.Paquete.Width = 150;
            // 
            // BuscarControlPaquete
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 661);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarControlPaquete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarControlPaquete";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodFerro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.CheckEdit checkCodFerro;
        private DevExpress.XtraEditors.CheckEdit checkCodigo;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo_;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Celda;
        private DevExpress.XtraGrid.Columns.GridColumn Cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
    }
}