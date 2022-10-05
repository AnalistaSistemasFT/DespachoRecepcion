namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    partial class ListaProductos
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkCodFerro = new DevExpress.XtraEditors.CheckEdit();
            this.checkDesc = new DevExpress.XtraEditors.CheckEdit();
            this.checkCodigo = new DevExpress.XtraEditors.CheckEdit();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtCant = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.txtStock = new DevExpress.XtraEditors.LabelControl();
            this.txtPzasPaq = new DevExpress.XtraEditors.LabelControl();
            this.txtPaqsStnd = new DevExpress.XtraEditors.LabelControl();
            this.txtPzasSob = new DevExpress.XtraEditors.LabelControl();
            this.txtPesoPaq = new DevExpress.XtraEditors.LabelControl();
            this.txtPesoTot = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodFerro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkCodFerro);
            this.groupControl1.Controls.Add(this.checkDesc);
            this.groupControl1.Controls.Add(this.checkCodigo);
            this.groupControl1.Controls.Add(this.searchControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(722, 96);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Buscar por";
            // 
            // checkCodFerro
            // 
            this.checkCodFerro.EditValue = true;
            this.checkCodFerro.Location = new System.Drawing.Point(11, 44);
            this.checkCodFerro.Name = "checkCodFerro";
            this.checkCodFerro.Properties.Caption = "Codigo Ferrotodo";
            this.checkCodFerro.Size = new System.Drawing.Size(103, 19);
            this.checkCodFerro.TabIndex = 4;
            this.checkCodFerro.CheckedChanged += new System.EventHandler(this.checkCodFerro_CheckedChanged);
            // 
            // checkDesc
            // 
            this.checkDesc.Location = new System.Drawing.Point(218, 44);
            this.checkDesc.Name = "checkDesc";
            this.checkDesc.Properties.Caption = "Descripcion";
            this.checkDesc.Size = new System.Drawing.Size(75, 19);
            this.checkDesc.TabIndex = 3;
            this.checkDesc.CheckedChanged += new System.EventHandler(this.checkDesc_CheckedChanged);
            // 
            // checkCodigo
            // 
            this.checkCodigo.Location = new System.Drawing.Point(133, 44);
            this.checkCodigo.Name = "checkCodigo";
            this.checkCodigo.Properties.Caption = "Codigo";
            this.checkCodigo.Size = new System.Drawing.Size(75, 19);
            this.checkCodigo.TabIndex = 2;
            this.checkCodigo.CheckedChanged += new System.EventHandler(this.checkCodigo_CheckedChanged);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(325, 39);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(381, 30);
            this.searchControl1.TabIndex = 1;
            this.searchControl1.TextChanged += new System.EventHandler(this.sb_search);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 115);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(722, 251);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.ItemFerro,
            this.Descripcion,
            this.UnidadMedida,
            this.Piezas});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.RowCellClickEvent);
            this.gridView1.DoubleClick += new System.EventHandler(this.RowCellClickEvent);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 133;
            // 
            // ItemFerro
            // 
            this.ItemFerro.Caption = "Codigo Ferrotodo";
            this.ItemFerro.FieldName = "ItemFerro";
            this.ItemFerro.Name = "ItemFerro";
            this.ItemFerro.Visible = true;
            this.ItemFerro.VisibleIndex = 0;
            this.ItemFerro.Width = 133;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 476;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.Caption = "UnidadMedida";
            this.UnidadMedida.FieldName = "UnidadMedida";
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.Visible = true;
            this.UnidadMedida.VisibleIndex = 3;
            this.UnidadMedida.Width = 126;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "StockPzs";
            this.Piezas.Name = "Piezas";
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 4;
            this.Piezas.Width = 109;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(528, 448);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 27);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Aceptar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(634, 448);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(100, 27);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Cancelar";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(13, 403);
            this.txtCant.Name = "txtCant";
            this.txtCant.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCant.Properties.Appearance.Options.UseFont = true;
            this.txtCant.Size = new System.Drawing.Size(86, 22);
            this.txtCant.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 376);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Cantidad: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(120, 378);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Stock";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(214, 378);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Pzas/Paq";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(322, 378);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Paqs(stnd)";
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Appearance.Options.UseFont = true;
            this.label5.Location = new System.Drawing.Point(432, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pzas(sob)";
            // 
            // label6
            // 
            this.label6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Appearance.Options.UseFont = true;
            this.label6.Location = new System.Drawing.Point(535, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Peso Paq";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(120, 409);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(6, 13);
            this.txtStock.TabIndex = 12;
            this.txtStock.Text = "0";
            // 
            // txtPzasPaq
            // 
            this.txtPzasPaq.Location = new System.Drawing.Point(214, 409);
            this.txtPzasPaq.Name = "txtPzasPaq";
            this.txtPzasPaq.Size = new System.Drawing.Size(6, 13);
            this.txtPzasPaq.TabIndex = 13;
            this.txtPzasPaq.Text = "0";
            // 
            // txtPaqsStnd
            // 
            this.txtPaqsStnd.Location = new System.Drawing.Point(322, 409);
            this.txtPaqsStnd.Name = "txtPaqsStnd";
            this.txtPaqsStnd.Size = new System.Drawing.Size(4, 13);
            this.txtPaqsStnd.TabIndex = 14;
            this.txtPaqsStnd.Text = "-";
            // 
            // txtPzasSob
            // 
            this.txtPzasSob.Location = new System.Drawing.Point(432, 410);
            this.txtPzasSob.Name = "txtPzasSob";
            this.txtPzasSob.Size = new System.Drawing.Size(4, 13);
            this.txtPzasSob.TabIndex = 15;
            this.txtPzasSob.Text = "-";
            // 
            // txtPesoPaq
            // 
            this.txtPesoPaq.Location = new System.Drawing.Point(535, 410);
            this.txtPesoPaq.Name = "txtPesoPaq";
            this.txtPesoPaq.Size = new System.Drawing.Size(4, 13);
            this.txtPesoPaq.TabIndex = 16;
            this.txtPesoPaq.Text = "-";
            // 
            // txtPesoTot
            // 
            this.txtPesoTot.Location = new System.Drawing.Point(627, 411);
            this.txtPesoTot.Name = "txtPesoTot";
            this.txtPesoTot.Size = new System.Drawing.Size(4, 13);
            this.txtPesoTot.TabIndex = 18;
            this.txtPesoTot.Text = "-";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(627, 380);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(59, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Peso Total";
            // 
            // ListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 488);
            this.Controls.Add(this.txtPesoTot);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtPesoPaq);
            this.Controls.Add(this.txtPzasSob);
            this.Controls.Add(this.txtPaqsStnd);
            this.Controls.Add(this.txtPzasPaq);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaProductos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkCodFerro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.TextEdit txtCant;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl txtStock;
        private DevExpress.XtraEditors.LabelControl txtPzasPaq;
        private DevExpress.XtraEditors.LabelControl txtPaqsStnd;
        private DevExpress.XtraEditors.LabelControl txtPzasSob;
        private DevExpress.XtraEditors.LabelControl txtPesoPaq;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn ItemFerro;
        private DevExpress.XtraEditors.CheckEdit checkDesc;
        private DevExpress.XtraEditors.CheckEdit checkCodigo;
        private DevExpress.XtraEditors.LabelControl txtPesoTot;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn UnidadMedida;
        private DevExpress.XtraEditors.CheckEdit checkCodFerro;
    }
}