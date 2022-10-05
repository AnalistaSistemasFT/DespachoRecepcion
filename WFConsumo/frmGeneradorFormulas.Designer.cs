namespace WFConsumo
{
    partial class frmGeneradorFormulas
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
            this.listBoxAdv1 = new DevComponents.DotNetBar.ListBoxAdv();
            this.listBoxAdv2 = new DevComponents.DotNetBar.ListBoxAdv();
            this.listBoxAdv3 = new DevComponents.DotNetBar.ListBoxAdv();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // listBoxAdv1
            // 
            this.listBoxAdv1.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv1.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv1.CheckStateMember = null;
            this.listBoxAdv1.ContainerControlProcessDialogKey = true;
            this.listBoxAdv1.DragDropSupport = true;
            this.listBoxAdv1.Items.Add("DOBLADO");
            this.listBoxAdv1.Items.Add("MASA");
            this.listBoxAdv1.Items.Add("ALTURA DE NERVIOS");
            this.listBoxAdv1.Items.Add("ANCHO DE NERVIOS EN LA BASE");
            this.listBoxAdv1.Items.Add("ANCHO DE LOS NERVIOS");
            this.listBoxAdv1.Items.Add("SEPARACIÓN PROMEDIO ENTRE NERVIOS");
            this.listBoxAdv1.Items.Add("SUM DISTANCIA PROMEDIO ENTRE EXTREMO DE NERVIOS");
            this.listBoxAdv1.Items.Add("ÁNGULO DE INCLINACIÓN");
            this.listBoxAdv1.Location = new System.Drawing.Point(28, 50);
            this.listBoxAdv1.Name = "listBoxAdv1";
            this.listBoxAdv1.Size = new System.Drawing.Size(163, 131);
            this.listBoxAdv1.TabIndex = 1;
            this.listBoxAdv1.Text = "listBoxAdv1";
            this.listBoxAdv1.ItemClick += new System.EventHandler(this.listBoxAdv1_ItemClick);
            // 
            // listBoxAdv2
            // 
            this.listBoxAdv2.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv2.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv2.ContainerControlProcessDialogKey = true;
            this.listBoxAdv2.DragDropSupport = true;
            this.listBoxAdv2.Items.Add("Sen()");
            this.listBoxAdv2.Items.Add("Raiz()");
            this.listBoxAdv2.Items.Add("Cos()");
            this.listBoxAdv2.Items.Add("Tan()");
            this.listBoxAdv2.Items.Add("ATan()");
            this.listBoxAdv2.Items.Add("Pi");
            this.listBoxAdv2.Items.Add("Log()");
            this.listBoxAdv2.Location = new System.Drawing.Point(214, 50);
            this.listBoxAdv2.Name = "listBoxAdv2";
            this.listBoxAdv2.Size = new System.Drawing.Size(155, 131);
            this.listBoxAdv2.TabIndex = 2;
            this.listBoxAdv2.Text = "listBoxAdv2";
            this.listBoxAdv2.ItemClick += new System.EventHandler(this.listBoxAdv2_ItemClick);
            // 
            // listBoxAdv3
            // 
            this.listBoxAdv3.AutoScroll = true;
            // 
            // 
            // 
            this.listBoxAdv3.BackgroundStyle.Class = "ListBoxAdv";
            this.listBoxAdv3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBoxAdv3.ContainerControlProcessDialogKey = true;
            this.listBoxAdv3.DragDropSupport = true;
            this.listBoxAdv3.Items.Add("(");
            this.listBoxAdv3.Items.Add(")");
            this.listBoxAdv3.Items.Add("+");
            this.listBoxAdv3.Items.Add("-");
            this.listBoxAdv3.Items.Add("*");
            this.listBoxAdv3.Items.Add("/");
            this.listBoxAdv3.Items.Add("^");
            this.listBoxAdv3.Location = new System.Drawing.Point(397, 50);
            this.listBoxAdv3.Name = "listBoxAdv3";
            this.listBoxAdv3.Size = new System.Drawing.Size(155, 131);
            this.listBoxAdv3.TabIndex = 2;
            this.listBoxAdv3.Text = "listBoxAdv3";
            this.listBoxAdv3.ItemClick += new System.EventHandler(this.listBoxAdv3_ItemClick);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(28, 187);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(524, 91);
            this.textBoxX1.TabIndex = 3;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(28, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(98, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "Variables";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(214, 21);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(98, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Funciones";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(397, 21);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(98, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Operadores";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Image = global::WFConsumo.Properties.Resources.save;
            this.buttonX1.Location = new System.Drawing.Point(508, 284);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(44, 33);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            this.buttonX1.Tooltip = "Guardar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX2.Image = global::WFConsumo.Properties.Resources.error;
            this.buttonX2.Location = new System.Drawing.Point(463, 284);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(39, 33);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 8;
            this.buttonX2.Tooltip = "Cancelar";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // frmGeneradorFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 338);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.listBoxAdv3);
            this.Controls.Add(this.listBoxAdv2);
            this.Controls.Add(this.listBoxAdv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGeneradorFormulas";
            this.Text = "frmGeneradorFormulas";
            this.Load += new System.EventHandler(this.frmGeneradorFormulas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv1;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv2;
        private DevComponents.DotNetBar.ListBoxAdv listBoxAdv3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;


    }
}