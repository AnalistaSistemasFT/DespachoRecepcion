namespace WFConsumo.frmGRH.Localizacion.Celdas
{
    partial class EditarCelda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarCelda));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCelda = new DevExpress.XtraEditors.LabelControl();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNave = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSegmento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtArea = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtColumna = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comBoxEstado = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelUnidades = new DevExpress.XtraEditors.LabelControl();
            this.txtUnidades = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegmento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumna.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(35, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Celda: ";
            // 
            // txtCelda
            // 
            this.txtCelda.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelda.Appearance.Options.UseFont = true;
            this.txtCelda.Location = new System.Drawing.Point(132, 28);
            this.txtCelda.Name = "txtCelda";
            this.txtCelda.Size = new System.Drawing.Size(17, 19);
            this.txtCelda.TabIndex = 1;
            this.txtCelda.Text = " - ";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Appearance.Options.UseBackColor = true;
            this.btnAceptar.Appearance.Options.UseForeColor = true;
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(115, 297);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 25);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(201, 297);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 25);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNave
            // 
            this.txtNave.Location = new System.Drawing.Point(132, 60);
            this.txtNave.Name = "txtNave";
            this.txtNave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNave.Size = new System.Drawing.Size(149, 20);
            this.txtNave.TabIndex = 45;
            this.txtNave.SelectedIndexChanged += new System.EventHandler(this.txtNave_SelectedIndexChanged);
            // 
            // txtSegmento
            // 
            this.txtSegmento.Location = new System.Drawing.Point(132, 166);
            this.txtSegmento.Name = "txtSegmento";
            this.txtSegmento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSegmento.Size = new System.Drawing.Size(149, 20);
            this.txtSegmento.TabIndex = 44;
            this.txtSegmento.SelectedIndexChanged += new System.EventHandler(this.txtSegmento_SelectedIndexChanged);
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(132, 131);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtArea.Size = new System.Drawing.Size(149, 20);
            this.txtArea.TabIndex = 43;
            this.txtArea.SelectedIndexChanged += new System.EventHandler(this.txtArea_SelectedIndexChanged);
            // 
            // txtColumna
            // 
            this.txtColumna.Location = new System.Drawing.Point(132, 96);
            this.txtColumna.Name = "txtColumna";
            this.txtColumna.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtColumna.Size = new System.Drawing.Size(149, 20);
            this.txtColumna.TabIndex = 42;
            this.txtColumna.SelectedIndexChanged += new System.EventHandler(this.txtColumna_SelectedIndexChanged);
            // 
            // comBoxEstado
            // 
            this.comBoxEstado.Location = new System.Drawing.Point(132, 203);
            this.comBoxEstado.Name = "comBoxEstado";
            this.comBoxEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxEstado.Size = new System.Drawing.Size(149, 20);
            this.comBoxEstado.TabIndex = 39;
            this.comBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comBoxEstado_SelectedIndexChanged_1);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(37, 206);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 38;
            this.labelControl6.Text = "Estado: ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(37, 99);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 13);
            this.labelControl5.TabIndex = 37;
            this.labelControl5.Text = "Columna: ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(37, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Nave: ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(37, 169);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Segmento: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(37, 134);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Area: ";
            // 
            // labelUnidades
            // 
            this.labelUnidades.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnidades.Appearance.Options.UseFont = true;
            this.labelUnidades.Location = new System.Drawing.Point(37, 242);
            this.labelUnidades.Name = "labelUnidades";
            this.labelUnidades.Size = new System.Drawing.Size(58, 13);
            this.labelUnidades.TabIndex = 46;
            this.labelUnidades.Text = "Unidades: ";
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(132, 239);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(149, 20);
            this.txtUnidades.TabIndex = 47;
            // 
            // EditarCelda
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 351);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.labelUnidades);
            this.Controls.Add(this.txtNave);
            this.Controls.Add(this.txtSegmento);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtColumna);
            this.Controls.Add(this.comBoxEstado);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCelda);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarCelda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar celda";
            ((System.ComponentModel.ISupportInitialize)(this.txtNave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegmento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumna.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidades.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl txtCelda;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.ComboBoxEdit txtNave;
        private DevExpress.XtraEditors.ComboBoxEdit txtSegmento;
        private DevExpress.XtraEditors.ComboBoxEdit txtArea;
        private DevExpress.XtraEditors.ComboBoxEdit txtColumna;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxEstado;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelUnidades;
        private DevExpress.XtraEditors.TextEdit txtUnidades;
    }
}