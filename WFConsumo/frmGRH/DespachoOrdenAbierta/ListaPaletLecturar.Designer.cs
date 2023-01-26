namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    partial class ListaPaletLecturar
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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Retiro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Palet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Paquetes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PesoPal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 278);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(970, 214);
            this.gridControl1.TabIndex = 8;
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
            this.Unidad,
            this.Piezas,
            this.Peso,
            this.Retiro,
            this.Fecha});
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
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "p_Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.ReadOnly = true;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 2;
            this.Codigo.Width = 74;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "CodigoFerro";
            this.CodigoFerro.FieldName = "p_CodigoFerro";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.OptionsColumn.AllowEdit = false;
            this.CodigoFerro.OptionsColumn.ReadOnly = true;
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 1;
            this.CodigoFerro.Width = 74;
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
            this.Descripcion.Width = 263;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_Paquete";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 4;
            this.Paquete.Width = 100;
            // 
            // Unidad
            // 
            this.Unidad.Caption = "Unidad";
            this.Unidad.FieldName = "p_Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.OptionsColumn.AllowEdit = false;
            this.Unidad.OptionsColumn.ReadOnly = true;
            this.Unidad.Visible = true;
            this.Unidad.VisibleIndex = 6;
            this.Unidad.Width = 77;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "p_Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.OptionsColumn.AllowEdit = false;
            this.Piezas.OptionsColumn.ReadOnly = true;
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 7;
            this.Piezas.Width = 74;
            // 
            // Peso
            // 
            this.Peso.Caption = "Peso";
            this.Peso.FieldName = "p_Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.AllowEdit = false;
            this.Peso.OptionsColumn.ReadOnly = true;
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 8;
            this.Peso.Width = 69;
            // 
            // Retiro
            // 
            this.Retiro.Caption = "Cantidad";
            this.Retiro.FieldName = "p_Cantidad";
            this.Retiro.Name = "Retiro";
            this.Retiro.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.True;
            this.Retiro.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.True;
            this.Retiro.Visible = true;
            this.Retiro.VisibleIndex = 9;
            this.Retiro.Width = 93;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "p_Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.AllowEdit = false;
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 5;
            this.Fecha.Width = 78;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.searchControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(970, 73);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Buscar:";
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(51, 29);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(392, 30);
            this.searchControl1.TabIndex = 1;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Top;
            toolTipTitleItem2.Text = "Nuevo";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.gridControl2.EmbeddedNavigator.SuperTip = superToolTip2;
            this.gridControl2.Location = new System.Drawing.Point(0, 73);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(970, 184);
            this.gridControl2.TabIndex = 74;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Palet,
            this.gridColumn1,
            this.gridColumn2,
            this.Paquetes,
            this.PesoPal});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsFind.FindNullPrompt = "Introduzca el despacho a buscar...";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView2_RowClick);
            // 
            // Palet
            // 
            this.Palet.Caption = "Palet";
            this.Palet.FieldName = "PaletId";
            this.Palet.Name = "Palet";
            this.Palet.Visible = true;
            this.Palet.VisibleIndex = 0;
            this.Palet.Width = 204;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "ItemId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 206;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Codigo Ferro";
            this.gridColumn2.FieldName = "ItemFId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 206;
            // 
            // Paquetes
            // 
            this.Paquetes.Caption = "Paquetes";
            this.Paquetes.FieldName = "Cantidad_Paqs";
            this.Paquetes.Name = "Paquetes";
            this.Paquetes.Visible = true;
            this.Paquetes.VisibleIndex = 3;
            this.Paquetes.Width = 200;
            // 
            // PesoPal
            // 
            this.PesoPal.Caption = "Peso";
            this.PesoPal.FieldName = "Peso_Paqs";
            this.PesoPal.Name = "PesoPal";
            this.PesoPal.Visible = true;
            this.PesoPal.VisibleIndex = 4;
            this.PesoPal.Width = 244;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 45);
            this.panel1.TabIndex = 75;
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Appearance.Options.UseBackColor = true;
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.Appearance.Options.UseForeColor = true;
            this.btnSalir.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnSalir.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.AppearanceHovered.Options.UseBackColor = true;
            this.btnSalir.AppearanceHovered.Options.UseForeColor = true;
            this.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSalir.Location = new System.Drawing.Point(858, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 29);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.Appearance.Options.UseForeColor = true;
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btnAceptar.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.AppearanceHovered.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(752, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 29);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 235);
            this.panel2.TabIndex = 76;
            // 
            // ListaPaletLecturar
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 537);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaPaletLecturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lecturacion por palet";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Unidad;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraGrid.Columns.GridColumn Retiro;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn Palet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Paquetes;
        private DevExpress.XtraGrid.Columns.GridColumn PesoPal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
    }
}