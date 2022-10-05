namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{
    partial class CrearEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearEntrega));
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCamion = new System.Windows.Forms.Label();
            this.lblCapKg = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblKgSegNota = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCapKg = new DevExpress.XtraEditors.TextEdit();
            this.txtSuc = new DevExpress.XtraEditors.TextEdit();
            this.txtKgSegNota = new DevExpress.XtraEditors.TextEdit();
            this.txtDif = new DevExpress.XtraEditors.TextEdit();
            this.cmboxCamion = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboxChofer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboxEstado = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pickerFecha = new DevExpress.XtraEditors.DateEdit();
            this.lblEntrTodo = new System.Windows.Forms.Label();
            this.checkEntrTodo = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.lblDespacho = new System.Windows.Forms.Label();
            this.txtDespacho = new System.Windows.Forms.Label();
            this.btnAddCamion = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddChofer = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodigoFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.A_cargar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pendientes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtObs = new DevExpress.XtraEditors.MemoEdit();
            this.btnEditarCamion = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapKg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKgSegNota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxCamion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxChofer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEntrTodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 43);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha: ";
            // 
            // lblCamion
            // 
            this.lblCamion.AutoSize = true;
            this.lblCamion.Location = new System.Drawing.Point(12, 70);
            this.lblCamion.Name = "lblCamion";
            this.lblCamion.Size = new System.Drawing.Size(46, 13);
            this.lblCamion.TabIndex = 1;
            this.lblCamion.Text = "Camion:";
            // 
            // lblCapKg
            // 
            this.lblCapKg.AutoSize = true;
            this.lblCapKg.Location = new System.Drawing.Point(12, 97);
            this.lblCapKg.Name = "lblCapKg";
            this.lblCapKg.Size = new System.Drawing.Size(83, 13);
            this.lblCapKg.TabIndex = 2;
            this.lblCapKg.Text = "Capacidad Kg.: ";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(545, 42);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(54, 13);
            this.lblSucursal.TabIndex = 3;
            this.lblSucursal.Text = "Sucursal: ";
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(552, 69);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(47, 13);
            this.lblChofer.TabIndex = 4;
            this.lblChofer.Text = "Chofer: ";
            // 
            // lblKgSegNota
            // 
            this.lblKgSegNota.AutoSize = true;
            this.lblKgSegNota.Location = new System.Drawing.Point(513, 96);
            this.lblKgSegNota.Name = "lblKgSegNota";
            this.lblKgSegNota.Size = new System.Drawing.Size(86, 13);
            this.lblKgSegNota.TabIndex = 5;
            this.lblKgSegNota.Text = "Kg. Según Nota:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(742, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dif.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Estado:";
            this.label2.Visible = false;
            // 
            // txtCapKg
            // 
            this.txtCapKg.Location = new System.Drawing.Point(113, 94);
            this.txtCapKg.Name = "txtCapKg";
            this.txtCapKg.Size = new System.Drawing.Size(220, 20);
            this.txtCapKg.TabIndex = 8;
            this.txtCapKg.EditValueChanged += new System.EventHandler(this.txtCapKg_EditValueChanged);
            // 
            // txtSuc
            // 
            this.txtSuc.Location = new System.Drawing.Point(605, 39);
            this.txtSuc.Name = "txtSuc";
            this.txtSuc.Properties.ReadOnly = true;
            this.txtSuc.Size = new System.Drawing.Size(295, 20);
            this.txtSuc.TabIndex = 9;
            // 
            // txtKgSegNota
            // 
            this.txtKgSegNota.EditValue = "0";
            this.txtKgSegNota.Location = new System.Drawing.Point(605, 93);
            this.txtKgSegNota.Name = "txtKgSegNota";
            this.txtKgSegNota.Size = new System.Drawing.Size(124, 20);
            this.txtKgSegNota.TabIndex = 10;
            this.txtKgSegNota.EditValueChanged += new System.EventHandler(this.txtKgSegNota_EditValueChanged);
            // 
            // txtDif
            // 
            this.txtDif.Location = new System.Drawing.Point(776, 93);
            this.txtDif.Name = "txtDif";
            this.txtDif.Size = new System.Drawing.Size(124, 20);
            this.txtDif.TabIndex = 11;
            // 
            // cmboxCamion
            // 
            this.cmboxCamion.EditValue = "0";
            this.cmboxCamion.Location = new System.Drawing.Point(113, 67);
            this.cmboxCamion.Name = "cmboxCamion";
            this.cmboxCamion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxCamion.Size = new System.Drawing.Size(220, 20);
            this.cmboxCamion.TabIndex = 12;
            this.cmboxCamion.SelectedIndexChanged += new System.EventHandler(this.cmboxCamion_SelectedIndexChanged);
            // 
            // comboxChofer
            // 
            this.comboxChofer.Location = new System.Drawing.Point(605, 66);
            this.comboxChofer.Name = "comboxChofer";
            this.comboxChofer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboxChofer.Size = new System.Drawing.Size(295, 20);
            this.comboxChofer.TabIndex = 13;
            // 
            // comboxEstado
            // 
            this.comboxEstado.Location = new System.Drawing.Point(755, 6);
            this.comboxEstado.Name = "comboxEstado";
            this.comboxEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboxEstado.Size = new System.Drawing.Size(124, 20);
            this.comboxEstado.TabIndex = 14;
            this.comboxEstado.Visible = false;
            // 
            // pickerFecha
            // 
            this.pickerFecha.EditValue = null;
            this.pickerFecha.Location = new System.Drawing.Point(113, 40);
            this.pickerFecha.Name = "pickerFecha";
            this.pickerFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.pickerFecha.Size = new System.Drawing.Size(220, 20);
            this.pickerFecha.TabIndex = 15;
            // 
            // lblEntrTodo
            // 
            this.lblEntrTodo.AutoSize = true;
            this.lblEntrTodo.Location = new System.Drawing.Point(12, 127);
            this.lblEntrTodo.Name = "lblEntrTodo";
            this.lblEntrTodo.Size = new System.Drawing.Size(83, 13);
            this.lblEntrTodo.TabIndex = 16;
            this.lblEntrTodo.Text = "Entregar Todo: ";
            // 
            // checkEntrTodo
            // 
            this.checkEntrTodo.Location = new System.Drawing.Point(113, 124);
            this.checkEntrTodo.Name = "checkEntrTodo";
            this.checkEntrTodo.Properties.Caption = " ";
            this.checkEntrTodo.Size = new System.Drawing.Size(75, 19);
            this.checkEntrTodo.TabIndex = 17;
            this.checkEntrTodo.CheckedChanged += new System.EventHandler(this.checkEntrTodo_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.Options.UseBorderColor = true;
            this.btnCancelar.AppearanceHovered.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(872, 486);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.Options.UseBorderColor = true;
            this.btnAceptar.AppearanceHovered.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.AppearanceHovered.Options.UseBackColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(776, 486);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblDespacho
            // 
            this.lblDespacho.AutoSize = true;
            this.lblDespacho.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespacho.Location = new System.Drawing.Point(12, 10);
            this.lblDespacho.Name = "lblDespacho";
            this.lblDespacho.Size = new System.Drawing.Size(76, 16);
            this.lblDespacho.TabIndex = 21;
            this.lblDespacho.Text = "Despacho:";
            // 
            // txtDespacho
            // 
            this.txtDespacho.AutoSize = true;
            this.txtDespacho.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDespacho.Location = new System.Drawing.Point(94, 10);
            this.txtDespacho.Name = "txtDespacho";
            this.txtDespacho.Size = new System.Drawing.Size(14, 16);
            this.txtDespacho.TabIndex = 22;
            this.txtDespacho.Text = "-";
            // 
            // btnAddCamion
            // 
            this.btnAddCamion.Location = new System.Drawing.Point(340, 67);
            this.btnAddCamion.Name = "btnAddCamion";
            this.btnAddCamion.Size = new System.Drawing.Size(30, 20);
            this.btnAddCamion.TabIndex = 24;
            this.btnAddCamion.Text = " + ";
            this.btnAddCamion.Click += new System.EventHandler(this.btnAddCamion_Click);
            // 
            // btnAddChofer
            // 
            this.btnAddChofer.Location = new System.Drawing.Point(906, 67);
            this.btnAddChofer.Name = "btnAddChofer";
            this.btnAddChofer.Size = new System.Drawing.Size(31, 20);
            this.btnAddChofer.TabIndex = 23;
            this.btnAddChofer.Text = "+";
            this.btnAddChofer.Click += new System.EventHandler(this.btnAddChofer_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(15, 156);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(947, 206);
            this.gridControl1.TabIndex = 25;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Paquete,
            this.Codigo,
            this.CodigoFerro,
            this.Producto,
            this.UnidadMedida,
            this.Piezas,
            this.Peso,
            this.A_cargar,
            this.Pendientes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_PaqueteId";
            this.Paquete.Name = "Paquete";
            this.Paquete.OptionsColumn.AllowEdit = false;
            this.Paquete.OptionsColumn.ReadOnly = true;
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 3;
            this.Paquete.Width = 81;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "p_ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.ReadOnly = true;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 1;
            this.Codigo.Width = 58;
            // 
            // CodigoFerro
            // 
            this.CodigoFerro.Caption = "Codigo Ferro";
            this.CodigoFerro.FieldName = "p_ItemFId";
            this.CodigoFerro.Name = "CodigoFerro";
            this.CodigoFerro.OptionsColumn.ReadOnly = true;
            this.CodigoFerro.Visible = true;
            this.CodigoFerro.VisibleIndex = 2;
            // 
            // Producto
            // 
            this.Producto.Caption = "Descripcion";
            this.Producto.FieldName = "p_Descripcion";
            this.Producto.Name = "Producto";
            this.Producto.OptionsColumn.AllowEdit = false;
            this.Producto.OptionsColumn.ReadOnly = true;
            this.Producto.Visible = true;
            this.Producto.VisibleIndex = 4;
            this.Producto.Width = 239;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.AppearanceCell.Options.UseTextOptions = true;
            this.UnidadMedida.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnidadMedida.Caption = "UnidadMedida";
            this.UnidadMedida.FieldName = "p_UnidadMedida";
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.OptionsColumn.AllowEdit = false;
            this.UnidadMedida.OptionsColumn.ReadOnly = true;
            this.UnidadMedida.Visible = true;
            this.UnidadMedida.VisibleIndex = 5;
            this.UnidadMedida.Width = 108;
            // 
            // Piezas
            // 
            this.Piezas.AppearanceCell.Options.UseTextOptions = true;
            this.Piezas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Piezas.Caption = "Cantidad";
            this.Piezas.FieldName = "p_Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.OptionsColumn.AllowEdit = false;
            this.Piezas.OptionsColumn.ReadOnly = true;
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 6;
            this.Piezas.Width = 58;
            // 
            // Peso
            // 
            this.Peso.AppearanceCell.Options.UseTextOptions = true;
            this.Peso.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Peso.Caption = "Peso (Kgs.)";
            this.Peso.FieldName = "p_Peso";
            this.Peso.Name = "Peso";
            this.Peso.OptionsColumn.AllowEdit = false;
            this.Peso.OptionsColumn.ReadOnly = true;
            this.Peso.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p_Peso", "Total: {0:n0} kgs.")});
            this.Peso.Visible = true;
            this.Peso.VisibleIndex = 7;
            this.Peso.Width = 111;
            // 
            // A_cargar
            // 
            this.A_cargar.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.A_cargar.AppearanceCell.Options.UseBackColor = true;
            this.A_cargar.AppearanceCell.Options.UseTextOptions = true;
            this.A_cargar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.A_cargar.AppearanceHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.A_cargar.AppearanceHeader.Options.UseBackColor = true;
            this.A_cargar.Caption = "A cargar";
            this.A_cargar.FieldName = "p_Retirar";
            this.A_cargar.Name = "A_cargar";
            this.A_cargar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p_Retirar", "Total: {0:n0} ")});
            this.A_cargar.Visible = true;
            this.A_cargar.VisibleIndex = 8;
            this.A_cargar.Width = 104;
            // 
            // Pendientes
            // 
            this.Pendientes.AppearanceCell.Options.UseTextOptions = true;
            this.Pendientes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Pendientes.Caption = "Pendientes";
            this.Pendientes.FieldName = "p_Pendiente";
            this.Pendientes.Name = "Pendientes";
            this.Pendientes.OptionsColumn.AllowEdit = false;
            this.Pendientes.OptionsColumn.ReadOnly = true;
            this.Pendientes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p_Pendiente", "Total: {0:n0}")});
            this.Pendientes.Visible = true;
            this.Pendientes.VisibleIndex = 9;
            this.Pendientes.Width = 89;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.groupControl1.Controls.Add(this.txtObs);
            this.groupControl1.Location = new System.Drawing.Point(15, 377);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(947, 103);
            this.groupControl1.TabIndex = 53;
            this.groupControl1.Text = "Observaciones";
            // 
            // txtObs
            // 
            this.txtObs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObs.Location = new System.Drawing.Point(21, 1);
            this.txtObs.Name = "txtObs";
            this.txtObs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtObs.Size = new System.Drawing.Size(924, 100);
            this.txtObs.TabIndex = 51;
            this.txtObs.ToolTip = "Observaciones";
            // 
            // btnEditarCamion
            // 
            this.btnEditarCamion.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarCamion.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEditarCamion.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCamion.Appearance.Image")));
            this.btnEditarCamion.Appearance.Options.UseBackColor = true;
            this.btnEditarCamion.Appearance.Options.UseForeColor = true;
            this.btnEditarCamion.Appearance.Options.UseImage = true;
            this.btnEditarCamion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCamion.ImageOptions.Image")));
            this.btnEditarCamion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEditarCamion.Location = new System.Drawing.Point(340, 94);
            this.btnEditarCamion.Name = "btnEditarCamion";
            this.btnEditarCamion.Size = new System.Drawing.Size(30, 20);
            this.btnEditarCamion.TabIndex = 54;
            this.btnEditarCamion.Click += new System.EventHandler(this.btnEditarCamion_Click);
            // 
            // CrearEntregaC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 528);
            this.Controls.Add(this.btnEditarCamion);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnAddCamion);
            this.Controls.Add(this.btnAddChofer);
            this.Controls.Add(this.txtDespacho);
            this.Controls.Add(this.lblDespacho);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.checkEntrTodo);
            this.Controls.Add(this.lblEntrTodo);
            this.Controls.Add(this.pickerFecha);
            this.Controls.Add(this.comboxEstado);
            this.Controls.Add(this.comboxChofer);
            this.Controls.Add(this.cmboxCamion);
            this.Controls.Add(this.txtDif);
            this.Controls.Add(this.txtKgSegNota);
            this.Controls.Add(this.txtSuc);
            this.Controls.Add(this.txtCapKg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblKgSegNota);
            this.Controls.Add(this.lblChofer);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.lblCapKg);
            this.Controls.Add(this.lblCamion);
            this.Controls.Add(this.lblFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearEntregaC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de carga";
            ((System.ComponentModel.ISupportInitialize)(this.txtCapKg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKgSegNota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxCamion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxChofer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboxEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickerFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEntrTodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtObs.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCamion;
        private System.Windows.Forms.Label lblCapKg;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.Label lblKgSegNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtCapKg;
        private DevExpress.XtraEditors.TextEdit txtSuc;
        private DevExpress.XtraEditors.TextEdit txtKgSegNota;
        private DevExpress.XtraEditors.TextEdit txtDif;
        private DevExpress.XtraEditors.ComboBoxEdit cmboxCamion;
        private DevExpress.XtraEditors.ComboBoxEdit comboxChofer;
        private DevExpress.XtraEditors.ComboBoxEdit comboxEstado;
        private DevExpress.XtraEditors.DateEdit pickerFecha;
        private System.Windows.Forms.Label lblEntrTodo;
        private DevExpress.XtraEditors.CheckEdit checkEntrTodo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private System.Windows.Forms.Label lblDespacho;
        private System.Windows.Forms.Label txtDespacho;
        private DevExpress.XtraEditors.SimpleButton btnAddCamion;
        private DevExpress.XtraEditors.SimpleButton btnAddChofer;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Producto;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraGrid.Columns.GridColumn UnidadMedida;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Peso;
        private DevExpress.XtraGrid.Columns.GridColumn A_cargar;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Pendientes;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit txtObs;
        private DevExpress.XtraEditors.SimpleButton btnEditarCamion;
    }
}