namespace WFConsumo.Recepcion
{
    partial class ListProdLectPalet
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
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkLote = new DevExpress.XtraEditors.CheckEdit();
            this.checkPaquete = new DevExpress.XtraEditors.CheckEdit();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.txtContador = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkLote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPaquete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContador.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(679, 400);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(100, 32);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "Cerrar";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(573, 400);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 32);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Agregar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 90);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(767, 292);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.CodigoFerro,
            this.Descripcion,
            this.Paquete,
            this.FechaV,
            this.Piezas,
            this.Peso});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "p_ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.ReadOnly = true;
            this.Codigo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 2;
            this.Codigo.Width = 99;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "CodigoFerro";
            this.CodigoFerro.FieldName = "p_ItemFerro";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.OptionsColumn.AllowEdit = false;
            this.CodigoFerro.OptionsColumn.ReadOnly = true;
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 99;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "p_Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.OptionsColumn.AllowEdit = false;
            this.Descripcion.OptionsColumn.ReadOnly = true;
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 3;
            this.Descripcion.Width = 355;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_PaqueteId";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 5;
            this.Paquete.Width = 138;
            // 
            // FechaV
            // 
            this.FechaV.Caption = "Vencimiento";
            this.FechaV.FieldName = "p_FechaV";
            this.FechaV.Name = "FechaV";
            this.FechaV.Visible = true;
            this.FechaV.VisibleIndex = 4;
            this.FechaV.Width = 126;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "p_Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.OptionsColumn.AllowEdit = false;
            this.Piezas.OptionsColumn.ReadOnly = true;
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 6;
            this.Piezas.Width = 82;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "p_Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.AllowEdit = false;
            this.Peso.OptionsColumn.ReadOnly = true;
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 7;
            this.Peso.Width = 86;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkLote);
            this.groupControl1.Controls.Add(this.checkPaquete);
            this.groupControl1.Controls.Add(this.searchControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(767, 74);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Buscar por:";
            // 
            // checkLote
            // 
            this.checkLote.Location = new System.Drawing.Point(203, 39);
            this.checkLote.Name = "checkLote";
            this.checkLote.Properties.Caption = "Lote";
            this.checkLote.Size = new System.Drawing.Size(75, 19);
            this.checkLote.TabIndex = 5;
            this.checkLote.CheckedChanged += new System.EventHandler(this.checkLote_CheckedChanged);
            // 
            // checkPaquete
            // 
            this.checkPaquete.EditValue = true;
            this.checkPaquete.Location = new System.Drawing.Point(68, 39);
            this.checkPaquete.Name = "checkPaquete";
            this.checkPaquete.Properties.Caption = "Paquete";
            this.checkPaquete.Size = new System.Drawing.Size(75, 19);
            this.checkPaquete.TabIndex = 4;
            this.checkPaquete.CheckedChanged += new System.EventHandler(this.checkPaquete_CheckedChanged);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(329, 34);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(392, 30);
            this.searchControl1.TabIndex = 1;
            this.searchControl1.TextChanged += new System.EventHandler(this.searchControl1_TextChanged);
            // 
            // txtContador
            // 
            this.txtContador.EditValue = "Total: 0";
            this.txtContador.Location = new System.Drawing.Point(27, 389);
            this.txtContador.Name = "txtContador";
            this.txtContador.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContador.Properties.Appearance.Options.UseFont = true;
            this.txtContador.Properties.Appearance.Options.UseTextOptions = true;
            this.txtContador.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtContador.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtContador.Properties.ReadOnly = true;
            this.txtContador.Size = new System.Drawing.Size(100, 24);
            this.txtContador.TabIndex = 9;
            // 
            // ListProdLectPalet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 444);
            this.Controls.Add(this.txtContador);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListProdLectPalet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de productos para lecturar a un palet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaProductosLecturado_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkLote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPaquete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContador.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraEditors.CheckEdit checkPaquete;
        private DevExpress.XtraGrid.Columns.GridColumn FechaV;
        private DevExpress.XtraEditors.CheckEdit checkLote;
        private DevExpress.XtraEditors.TextEdit txtContador;
    }
}