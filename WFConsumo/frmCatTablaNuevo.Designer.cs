namespace WFConsumo
{
    partial class frmCatTablaNuevo
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
            this.txtid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtdescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.combotipoproducto = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combounidad = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtid
            // 
            // 
            // 
            // 
            this.txtid.Border.Class = "TextBoxBorder";
            this.txtid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(158, 37);
            this.txtid.Name = "txtid";
            this.txtid.PreventEnterBeep = true;
            this.txtid.Size = new System.Drawing.Size(87, 20);
            this.txtid.TabIndex = 0;
            // 
            // txtdescripcion
            // 
            // 
            // 
            // 
            this.txtdescripcion.Border.Class = "TextBoxBorder";
            this.txtdescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdescripcion.Location = new System.Drawing.Point(158, 84);
            this.txtdescripcion.MaxLength = 65;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.PreventEnterBeep = true;
            this.txtdescripcion.Size = new System.Drawing.Size(429, 20);
            this.txtdescripcion.TabIndex = 1;
            // 
            // combotipoproducto
            // 
            this.combotipoproducto.DisplayMember = "Text";
            this.combotipoproducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combotipoproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotipoproducto.FormattingEnabled = true;
            this.combotipoproducto.ItemHeight = 14;
            this.combotipoproducto.Location = new System.Drawing.Point(158, 125);
            this.combotipoproducto.MaxLength = 30;
            this.combotipoproducto.Name = "combotipoproducto";
            this.combotipoproducto.Size = new System.Drawing.Size(265, 20);
            this.combotipoproducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combotipoproducto.TabIndex = 2;
            // 
            // combounidad
            // 
            this.combounidad.DisplayMember = "Text";
            this.combounidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combounidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combounidad.FormattingEnabled = true;
            this.combounidad.ItemHeight = 14;
            this.combounidad.Location = new System.Drawing.Point(158, 168);
            this.combounidad.MaxLength = 30;
            this.combounidad.Name = "combounidad";
            this.combounidad.Size = new System.Drawing.Size(265, 20);
            this.combounidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combounidad.TabIndex = 3;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX4.Image = global::WFConsumo.Properties.Resources.error;
            this.buttonX4.Location = new System.Drawing.Point(492, 431);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(43, 42);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 8;
            this.buttonX4.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.buttonX4.Tooltip = "Cancelar";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(82, 37);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(49, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "Tabla";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(77, 165);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(54, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "Unidad";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(30, 122);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(101, 23);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "Tipo Producto";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(43, 81);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(88, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "Descripcion";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX3.Image = global::WFConsumo.Properties.Resources.save;
            this.buttonX3.Location = new System.Drawing.Point(541, 431);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(46, 42);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 7;
            this.buttonX3.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.buttonX3.Tooltip = "Guardar";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX2.Image = global::WFConsumo.Properties.Resources.remove;
            this.buttonX2.Location = new System.Drawing.Point(77, 410);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(37, 39);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 6;
            this.buttonX2.Tooltip = "Eliminar";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Image = global::WFConsumo.Properties.Resources.insert;
            this.buttonX1.Location = new System.Drawing.Point(30, 410);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(37, 39);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Tooltip = "Agregar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(30, 203);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(557, 200);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // frmCatTablaNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 485);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.combounidad);
            this.Controls.Add(this.combotipoproducto);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.txtid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCatTablaNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCatTablaNuevo";
            this.Load += new System.EventHandler(this.frmCatTablaNuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtid;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdescripcion;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx combotipoproducto;
        internal DevComponents.DotNetBar.Controls.ComboBoxEx combounidad;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}