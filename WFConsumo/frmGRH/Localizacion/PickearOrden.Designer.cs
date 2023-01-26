namespace WFConsumo.frmGRH.Localizacion
{
    partial class PickearOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickearOrden));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrden = new DevExpress.XtraEditors.LabelControl();
            this.txtCentroTrabajo = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Paquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Almacen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Celda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Consolidado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnConsolidar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCerrarOrden = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAsignar = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(29, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Orden: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(237, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(125, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Centro de trabajo: ";
            // 
            // txtOrden
            // 
            this.txtOrden.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrden.Appearance.Options.UseFont = true;
            this.txtOrden.Location = new System.Drawing.Point(83, 33);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(5, 16);
            this.txtOrden.TabIndex = 2;
            this.txtOrden.Text = "-";
            // 
            // txtCentroTrabajo
            // 
            this.txtCentroTrabajo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentroTrabajo.Appearance.Options.UseFont = true;
            this.txtCentroTrabajo.Location = new System.Drawing.Point(368, 33);
            this.txtCentroTrabajo.Name = "txtCentroTrabajo";
            this.txtCentroTrabajo.Size = new System.Drawing.Size(5, 16);
            this.txtCentroTrabajo.TabIndex = 3;
            this.txtCentroTrabajo.Text = "-";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 124);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(501, 289);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Paquete,
            this.Almacen,
            this.Celda,
            this.Fecha,
            this.Consolidado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Paquete
            // 
            this.Paquete.Caption = "Paquete";
            this.Paquete.FieldName = "p_PaqueteId";
            this.Paquete.Name = "Paquete";
            this.Paquete.Visible = true;
            this.Paquete.VisibleIndex = 0;
            this.Paquete.Width = 245;
            // 
            // Almacen
            // 
            this.Almacen.Caption = "Almacen";
            this.Almacen.FieldName = "p_AlmacenId";
            this.Almacen.Name = "Almacen";
            this.Almacen.Visible = true;
            this.Almacen.VisibleIndex = 1;
            this.Almacen.Width = 133;
            // 
            // Celda
            // 
            this.Celda.Caption = "Celda";
            this.Celda.FieldName = "p_CeldaId";
            this.Celda.Name = "Celda";
            this.Celda.Visible = true;
            this.Celda.VisibleIndex = 2;
            this.Celda.Width = 199;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "p_Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 3;
            this.Fecha.Width = 191;
            // 
            // Consolidado
            // 
            this.Consolidado.Caption = "Consolidado";
            this.Consolidado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Consolidado.FieldName = "p_Status";
            this.Consolidado.Name = "Consolidado";
            this.Consolidado.Visible = true;
            this.Consolidado.VisibleIndex = 4;
            this.Consolidado.Width = 229;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // btnConsolidar
            // 
            this.btnConsolidar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnConsolidar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConsolidar.Appearance.Options.UseBackColor = true;
            this.btnConsolidar.Appearance.Options.UseForeColor = true;
            this.btnConsolidar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnConsolidar.Location = new System.Drawing.Point(323, 433);
            this.btnConsolidar.Name = "btnConsolidar";
            this.btnConsolidar.Size = new System.Drawing.Size(80, 25);
            this.btnConsolidar.TabIndex = 5;
            this.btnConsolidar.Text = "Consolidar";
            this.btnConsolidar.Click += new System.EventHandler(this.btnConsolidar_Click);
            // 
            // btnCerrarOrden
            // 
            this.btnCerrarOrden.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCerrarOrden.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCerrarOrden.Appearance.Options.UseBackColor = true;
            this.btnCerrarOrden.Appearance.Options.UseForeColor = true;
            this.btnCerrarOrden.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCerrarOrden.Location = new System.Drawing.Point(237, 433);
            this.btnCerrarOrden.Name = "btnCerrarOrden";
            this.btnCerrarOrden.Size = new System.Drawing.Size(80, 25);
            this.btnCerrarOrden.TabIndex = 6;
            this.btnCerrarOrden.Text = "Cerrar Orden";
            this.btnCerrarOrden.Click += new System.EventHandler(this.btnCerrarOrden_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(409, 433);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 25);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAsignar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Appearance.Options.UseBackColor = true;
            this.btnAsignar.Appearance.Options.UseForeColor = true;
            this.btnAsignar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAsignar.Location = new System.Drawing.Point(297, 95);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(93, 23);
            this.btnAsignar.TabIndex = 8;
            this.btnAsignar.Text = "Asignar celda";
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnLimpiar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Appearance.Options.UseBackColor = true;
            this.btnLimpiar.Appearance.Options.UseForeColor = true;
            this.btnLimpiar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLimpiar.Location = new System.Drawing.Point(396, 95);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar celda";
            // 
            // PickearOrden
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 470);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCerrarOrden);
            this.Controls.Add(this.btnConsolidar);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtCentroTrabajo);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PickearOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pickear Orden";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl txtOrden;
        private DevExpress.XtraEditors.LabelControl txtCentroTrabajo;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Paquete;
        private DevExpress.XtraGrid.Columns.GridColumn Almacen;
        private DevExpress.XtraGrid.Columns.GridColumn Celda;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraEditors.SimpleButton btnConsolidar;
        private DevExpress.XtraEditors.SimpleButton btnCerrarOrden;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraGrid.Columns.GridColumn Consolidado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAsignar;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
    }
}