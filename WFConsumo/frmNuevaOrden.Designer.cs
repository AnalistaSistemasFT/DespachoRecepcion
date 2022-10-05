namespace WFConsumo
{
    partial class frmNuevaOrden
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
            this.comboOpe = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtorden = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtgrupo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtitem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtcentro = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // comboOpe
            // 
            this.comboOpe.DisplayMember = "Text";
            this.comboOpe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOpe.Enabled = false;
            this.comboOpe.FormattingEnabled = true;
            this.comboOpe.ItemHeight = 14;
            this.comboOpe.Location = new System.Drawing.Point(96, 36);
            this.comboOpe.Name = "comboOpe";
            this.comboOpe.Size = new System.Drawing.Size(284, 20);
            this.comboOpe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboOpe.TabIndex = 0;
            // 
            // txtorden
            // 
            // 
            // 
            // 
            this.txtorden.Border.Class = "TextBoxBorder";
            this.txtorden.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtorden.Location = new System.Drawing.Point(96, 120);
            this.txtorden.Name = "txtorden";
            this.txtorden.PreventEnterBeep = true;
            this.txtorden.Size = new System.Drawing.Size(215, 20);
            this.txtorden.TabIndex = 2;
            // 
            // txtgrupo
            // 
            // 
            // 
            // 
            this.txtgrupo.Border.Class = "TextBoxBorder";
            this.txtgrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtgrupo.Enabled = false;
            this.txtgrupo.Location = new System.Drawing.Point(96, 211);
            this.txtgrupo.Name = "txtgrupo";
            this.txtgrupo.PreventEnterBeep = true;
            this.txtgrupo.Size = new System.Drawing.Size(284, 20);
            this.txtgrupo.TabIndex = 3;
            // 
            // txtitem
            // 
            // 
            // 
            // 
            this.txtitem.Border.Class = "TextBoxBorder";
            this.txtitem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtitem.Enabled = false;
            this.txtitem.Location = new System.Drawing.Point(96, 164);
            this.txtitem.Name = "txtitem";
            this.txtitem.PreventEnterBeep = true;
            this.txtitem.Size = new System.Drawing.Size(284, 20);
            this.txtitem.TabIndex = 4;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(10, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "Operacion";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(10, 71);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "Centro";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(9, 116);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "Orden";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(10, 159);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "Item";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(10, 211);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 12;
            this.labelX5.Text = "Grupo";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtcentro
            // 
            // 
            // 
            // 
            this.txtcentro.Border.Class = "TextBoxBorder";
            this.txtcentro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtcentro.Enabled = false;
            this.txtcentro.Location = new System.Drawing.Point(96, 71);
            this.txtcentro.Name = "txtcentro";
            this.txtcentro.PreventEnterBeep = true;
            this.txtcentro.Size = new System.Drawing.Size(284, 20);
            this.txtcentro.TabIndex = 15;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX4.Image = global::WFConsumo.Properties.Resources.search;
            this.buttonX4.Location = new System.Drawing.Point(317, 116);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(36, 27);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 13;
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX3.Image = global::WFConsumo.Properties.Resources.error;
            this.buttonX3.Location = new System.Drawing.Point(286, 282);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(44, 34);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 7;
            this.buttonX3.Tooltip = "Cancelar";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Image = global::WFConsumo.Properties.Resources.save;
            this.buttonX1.Location = new System.Drawing.Point(336, 282);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(44, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Tooltip = "Aceptar ";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmNuevaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 328);
            this.Controls.Add(this.txtcentro);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtitem);
            this.Controls.Add(this.txtgrupo);
            this.Controls.Add(this.txtorden);
            this.Controls.Add(this.comboOpe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNuevaOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevaOrden";
            this.Load += new System.EventHandler(this.frmNuevaOrden_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx comboOpe;
        private DevComponents.DotNetBar.Controls.TextBoxX txtorden;
        private DevComponents.DotNetBar.Controls.TextBoxX txtgrupo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtitem;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtcentro;
    }
}