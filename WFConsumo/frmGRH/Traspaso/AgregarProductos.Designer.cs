namespace WFConsumo.frmGRH.Traspaso
{
    partial class AgregarProductos
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemFerro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Piezas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkDesc = new DevExpress.XtraEditors.CheckEdit();
            this.checkCodigo = new DevExpress.XtraEditors.CheckEdit();
            this.sb_search = new DevExpress.XtraEditors.SearchControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCant = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sb_search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 115);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(677, 251);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.ItemFerro,
            this.Descripcion,
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
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "ItemId";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 100;
            // 
            // ItemFerro
            // 
            this.ItemFerro.Caption = "Codigo Ferrotodo";
            this.ItemFerro.FieldName = "ItemFerro";
            this.ItemFerro.Name = "ItemFerro";
            this.ItemFerro.Visible = true;
            this.ItemFerro.VisibleIndex = 1;
            this.ItemFerro.Width = 100;
            // 
            // Descripcion
            // 
            this.Descripcion.Caption = "Descripcion";
            this.Descripcion.FieldName = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Visible = true;
            this.Descripcion.VisibleIndex = 2;
            this.Descripcion.Width = 357;
            // 
            // Piezas
            // 
            this.Piezas.Caption = "Piezas";
            this.Piezas.FieldName = "StockPzs";
            this.Piezas.Name = "Piezas";
            this.Piezas.Visible = true;
            this.Piezas.VisibleIndex = 3;
            this.Piezas.Width = 100;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkDesc);
            this.groupControl1.Controls.Add(this.checkCodigo);
            this.groupControl1.Controls.Add(this.sb_search);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(677, 96);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Buscar por";
            // 
            // checkDesc
            // 
            this.checkDesc.Location = new System.Drawing.Point(153, 44);
            this.checkDesc.Name = "checkDesc";
            this.checkDesc.Properties.Caption = "Descripcion";
            this.checkDesc.Size = new System.Drawing.Size(75, 19);
            this.checkDesc.TabIndex = 3;
            this.checkDesc.CheckedChanged += new System.EventHandler(this.checkDesc_CheckedChanged);
            // 
            // checkCodigo
            // 
            this.checkCodigo.EditValue = true;
            this.checkCodigo.Location = new System.Drawing.Point(33, 44);
            this.checkCodigo.Name = "checkCodigo";
            this.checkCodigo.Properties.Caption = "Codigo";
            this.checkCodigo.Size = new System.Drawing.Size(75, 19);
            this.checkCodigo.TabIndex = 2;
            this.checkCodigo.CheckedChanged += new System.EventHandler(this.checkCodigo_CheckedChanged);
            // 
            // sb_search
            // 
            this.sb_search.Location = new System.Drawing.Point(316, 39);
            this.sb_search.Name = "sb_search";
            this.sb_search.Properties.AutoHeight = false;
            this.sb_search.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.sb_search.Size = new System.Drawing.Size(334, 30);
            this.sb_search.TabIndex = 1;
            this.sb_search.TextChanged += new System.EventHandler(this.sb_search_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(589, 389);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(483, 389);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 25);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 389);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Cantidad:";
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(80, 386);
            this.txtCant.Name = "txtCant";
            this.txtCant.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCant.Properties.Appearance.Options.UseFont = true;
            this.txtCant.Size = new System.Drawing.Size(100, 22);
            this.txtCant.TabIndex = 7;
            // 
            // AgregarProductos
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(704, 426);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtCant);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "AgregarProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarProductos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarProductos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sb_search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn ItemFerro;
        private DevExpress.XtraGrid.Columns.GridColumn Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn Piezas;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkDesc;
        private DevExpress.XtraEditors.CheckEdit checkCodigo;
        private DevExpress.XtraEditors.SearchControl sb_search;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCant;
    }
}