
namespace WFConsumo.Recepcion
{
    partial class frmAnotacion
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnChofer = new System.Windows.Forms.Button();
            this.btnPlaca = new System.Windows.Forms.Button();
            this.cbcelda = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbfabricante = new System.Windows.Forms.ComboBox();
            this.txtCamion = new System.Windows.Forms.TextBox();
            this.cbprocedencia = new System.Windows.Forms.ComboBox();
            this.cbchofer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtobs = new System.Windows.Forms.TextBox();
            this.cbplaca = new System.Windows.Forms.ComboBox();
            this.cbxcliente = new System.Windows.Forms.CheckBox();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.txtci = new System.Windows.Forms.TextBox();
            this.txtmanifiesto = new System.Windows.Forms.TextBox();
            this.txtanotacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.griddetalle = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 494);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Silver;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1072, 36);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WFConsumo.Properties.Resources.save;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 33);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WFConsumo.Properties.Resources.error;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 33);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.btnChofer);
            this.splitContainer2.Panel1.Controls.Add(this.btnPlaca);
            this.splitContainer2.Panel1.Controls.Add(this.cbcelda);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.cbfabricante);
            this.splitContainer2.Panel1.Controls.Add(this.txtCamion);
            this.splitContainer2.Panel1.Controls.Add(this.cbprocedencia);
            this.splitContainer2.Panel1.Controls.Add(this.cbchofer);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.txtobs);
            this.splitContainer2.Panel1.Controls.Add(this.cbplaca);
            this.splitContainer2.Panel1.Controls.Add(this.cbxcliente);
            this.splitContainer2.Panel1.Controls.Add(this.dtpfecha);
            this.splitContainer2.Panel1.Controls.Add(this.txtci);
            this.splitContainer2.Panel1.Controls.Add(this.txtmanifiesto);
            this.splitContainer2.Panel1.Controls.Add(this.txtanotacion);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.griddetalle);
            this.splitContainer2.Size = new System.Drawing.Size(1072, 454);
            this.splitContainer2.SplitterDistance = 212;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnChofer
            // 
            this.btnChofer.BackgroundImage = global::WFConsumo.Properties.Resources.insert;
            this.btnChofer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChofer.Location = new System.Drawing.Point(605, 71);
            this.btnChofer.Name = "btnChofer";
            this.btnChofer.Size = new System.Drawing.Size(31, 23);
            this.btnChofer.TabIndex = 26;
            this.btnChofer.UseVisualStyleBackColor = true;
            this.btnChofer.Click += new System.EventHandler(this.btnChofer_Click);
            // 
            // btnPlaca
            // 
            this.btnPlaca.BackgroundImage = global::WFConsumo.Properties.Resources.insert;
            this.btnPlaca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaca.Location = new System.Drawing.Point(259, 96);
            this.btnPlaca.Name = "btnPlaca";
            this.btnPlaca.Size = new System.Drawing.Size(30, 23);
            this.btnPlaca.TabIndex = 25;
            this.btnPlaca.UseVisualStyleBackColor = true;
            this.btnPlaca.Click += new System.EventHandler(this.btnPlaca_Click);
            // 
            // cbcelda
            // 
            this.cbcelda.FormattingEnabled = true;
            this.cbcelda.Location = new System.Drawing.Point(473, 176);
            this.cbcelda.Name = "cbcelda";
            this.cbcelda.Size = new System.Drawing.Size(121, 21);
            this.cbcelda.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(401, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "*Celda:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "* Fabricante:";
            // 
            // cbfabricante
            // 
            this.cbfabricante.FormattingEnabled = true;
            this.cbfabricante.Location = new System.Drawing.Point(133, 176);
            this.cbfabricante.Name = "cbfabricante";
            this.cbfabricante.Size = new System.Drawing.Size(247, 21);
            this.cbfabricante.TabIndex = 21;
            // 
            // txtCamion
            // 
            this.txtCamion.Enabled = false;
            this.txtCamion.Location = new System.Drawing.Point(421, 101);
            this.txtCamion.Name = "txtCamion";
            this.txtCamion.Size = new System.Drawing.Size(121, 21);
            this.txtCamion.TabIndex = 20;
            // 
            // cbprocedencia
            // 
            this.cbprocedencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbprocedencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbprocedencia.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbprocedencia.FormattingEnabled = true;
            this.cbprocedencia.Location = new System.Drawing.Point(419, 47);
            this.cbprocedencia.Name = "cbprocedencia";
            this.cbprocedencia.Size = new System.Drawing.Size(178, 25);
            this.cbprocedencia.TabIndex = 19;
            // 
            // cbchofer
            // 
            this.cbchofer.FormattingEnabled = true;
            this.cbchofer.Location = new System.Drawing.Point(421, 74);
            this.cbchofer.Name = "cbchofer";
            this.cbchofer.Size = new System.Drawing.Size(178, 21);
            this.cbchofer.TabIndex = 18;
            this.cbchofer.SelectionChangeCommitted += new System.EventHandler(this.cbchofer_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "* CI:";
            // 
            // txtobs
            // 
            this.txtobs.Location = new System.Drawing.Point(132, 150);
            this.txtobs.Name = "txtobs";
            this.txtobs.Size = new System.Drawing.Size(462, 21);
            this.txtobs.TabIndex = 16;
            // 
            // cbplaca
            // 
            this.cbplaca.FormattingEnabled = true;
            this.cbplaca.Location = new System.Drawing.Point(133, 97);
            this.cbplaca.Name = "cbplaca";
            this.cbplaca.Size = new System.Drawing.Size(121, 21);
            this.cbplaca.TabIndex = 15;
            this.cbplaca.SelectionChangeCommitted += new System.EventHandler(this.cbplaca_SelectionChangeCommitted);
            // 
            // cbxcliente
            // 
            this.cbxcliente.AutoSize = true;
            this.cbxcliente.Location = new System.Drawing.Point(133, 56);
            this.cbxcliente.Name = "cbxcliente";
            this.cbxcliente.Size = new System.Drawing.Size(15, 14);
            this.cbxcliente.TabIndex = 14;
            this.cbxcliente.UseVisualStyleBackColor = true;
            // 
            // dtpfecha
            // 
            this.dtpfecha.Enabled = false;
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha.Location = new System.Drawing.Point(419, 20);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(111, 21);
            this.dtpfecha.TabIndex = 13;
            // 
            // txtci
            // 
            this.txtci.Enabled = false;
            this.txtci.Location = new System.Drawing.Point(133, 72);
            this.txtci.Name = "txtci";
            this.txtci.Size = new System.Drawing.Size(121, 21);
            this.txtci.TabIndex = 12;
            // 
            // txtmanifiesto
            // 
            this.txtmanifiesto.Location = new System.Drawing.Point(133, 125);
            this.txtmanifiesto.Name = "txtmanifiesto";
            this.txtmanifiesto.Size = new System.Drawing.Size(121, 21);
            this.txtmanifiesto.TabIndex = 11;
            // 
            // txtanotacion
            // 
            this.txtanotacion.Enabled = false;
            this.txtanotacion.Location = new System.Drawing.Point(133, 22);
            this.txtanotacion.Name = "txtanotacion";
            this.txtanotacion.Size = new System.Drawing.Size(121, 21);
            this.txtanotacion.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "*Observacion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(326, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "* Camion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(329, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "* Chofer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(301, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "* Procedencia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "* Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "* Manifiesto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Placa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "* Es de Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Anotacion:";
            // 
            // griddetalle
            // 
            this.griddetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.griddetalle.Location = new System.Drawing.Point(0, 0);
            this.griddetalle.MainView = this.gridView1;
            this.griddetalle.Name = "griddetalle";
            this.griddetalle.Size = new System.Drawing.Size(1072, 238);
            this.griddetalle.TabIndex = 15;
            this.griddetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.griddetalle.DataSourceChanged += new System.EventHandler(this.griddetalle_DataSourceChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.griddetalle;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WFConsumo.Properties.Resources.insert;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(600, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmAnotacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 494);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnotacion";
            this.Text = "frmAnotacion";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.griddetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cbprocedencia;
        private System.Windows.Forms.ComboBox cbchofer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtobs;
        private System.Windows.Forms.ComboBox cbplaca;
        private System.Windows.Forms.CheckBox cbxcliente;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.TextBox txtci;
        private System.Windows.Forms.TextBox txtmanifiesto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCamion;
        public System.Windows.Forms.TextBox txtanotacion;
        public DevExpress.XtraGrid.GridControl griddetalle;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ComboBox cbcelda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbfabricante;
        private System.Windows.Forms.Button btnChofer;
        private System.Windows.Forms.Button btnPlaca;
        private System.Windows.Forms.Button button1;
    }
}