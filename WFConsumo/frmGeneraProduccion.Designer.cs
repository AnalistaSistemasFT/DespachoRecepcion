using System;

namespace WFConsumo
{
    partial class frmGeneraProduccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private static frmGeneraProduccion aForm = null;
        //public static frmGeneraProduccion Instance(string status, int sucursal)
        //{
        //    if (aForm == null)
        //    {
        //        aForm = new frmGeneraProduccion(status,sucursal);
        //    }
        //    return aForm;
        //}
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
            //aForm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneraProduccion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOrdenes = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvSalidas = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEntradas = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFilas = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsEjecutar = new System.Windows.Forms.ToolStripButton();
            this.tsSuspender = new System.Windows.Forms.ToolStripButton();
            this.tsVolver = new System.Windows.Forms.ToolStripButton();
            this.tsCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 470);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrdenes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(725, 470);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdenes.Location = new System.Drawing.Point(0, 0);
            this.dgvOrdenes.MainView = this.gridView1;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(357, 470);
            this.dgvOrdenes.TabIndex = 0;
            this.dgvOrdenes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dgvOrdenes.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.dgvOrdenes_ProcessGridKey);
            this.dgvOrdenes.Click += new System.EventHandler(this.dgvOrdenes_Click);
            this.dgvOrdenes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOrdenes_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvOrdenes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.dgvSalidas);
            this.splitContainer2.Panel1.Controls.Add(this.panel6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvEntradas);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(364, 470);
            this.splitContainer2.SplitterDistance = 227;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvSalidas
            // 
            this.dgvSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalidas.Location = new System.Drawing.Point(0, 26);
            this.dgvSalidas.MainView = this.gridView2;
            this.dgvSalidas.Name = "dgvSalidas";
            this.dgvSalidas.Size = new System.Drawing.Size(364, 201);
            this.dgvSalidas.TabIndex = 23;
            this.dgvSalidas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.dgvSalidas.Click += new System.EventHandler(this.dgvSalidas_Click);
            this.dgvSalidas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSalidas_KeyUp);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dgvSalidas;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowFooter = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(364, 26);
            this.panel6.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CONSUMIDO";
            // 
            // dgvEntradas
            // 
            this.dgvEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEntradas.Location = new System.Drawing.Point(0, 26);
            this.dgvEntradas.MainView = this.gridView3;
            this.dgvEntradas.Name = "dgvEntradas";
            this.dgvEntradas.Size = new System.Drawing.Size(364, 213);
            this.dgvEntradas.TabIndex = 23;
            this.dgvEntradas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.dgvEntradas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvEntradas_KeyUp);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dgvEntradas;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsView.ShowFooter = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 26);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRODUCIDO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(725, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFilas
            // 
            this.lblFilas.Name = "lblFilas";
            this.lblFilas.Size = new System.Drawing.Size(118, 17);
            this.lblFilas.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEjecutar,
            this.tsSuspender,
            this.tsVolver,
            this.tsCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsEjecutar
            // 
            this.tsEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("tsEjecutar.Image")));
            this.tsEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEjecutar.Name = "tsEjecutar";
            this.tsEjecutar.Size = new System.Drawing.Size(69, 22);
            this.tsEjecutar.Text = "Ejecutar";
            this.tsEjecutar.Click += new System.EventHandler(this.tsEjecutar_Click);
            // 
            // tsSuspender
            // 
            this.tsSuspender.Image = ((System.Drawing.Image)(resources.GetObject("tsSuspender.Image")));
            this.tsSuspender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSuspender.Name = "tsSuspender";
            this.tsSuspender.Size = new System.Drawing.Size(82, 22);
            this.tsSuspender.Text = "Suspender";
            this.tsSuspender.Click += new System.EventHandler(this.tsSuspender_Click);
            // 
            // tsVolver
            // 
            this.tsVolver.Image = ((System.Drawing.Image)(resources.GetObject("tsVolver.Image")));
            this.tsVolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVolver.Name = "tsVolver";
            this.tsVolver.Size = new System.Drawing.Size(75, 22);
            this.tsVolver.Text = "Deshacer";
            this.tsVolver.Click += new System.EventHandler(this.tsVolver_Click);
            // 
            // tsCerrar
            // 
            this.tsCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tsCerrar.Image")));
            this.tsCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCerrar.Name = "tsCerrar";
            this.tsCerrar.Size = new System.Drawing.Size(70, 22);
            this.tsCerrar.Text = "Finalizar";
            this.tsCerrar.Click += new System.EventHandler(this.tsCerrar_Click);
            // 
            // frmGeneraProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmGeneraProduccion";
            this.Text = "frmGeneraProduccion";
            this.Load += new System.EventHandler(this.frmGeneraProduccion_Load);
            this.Shown += new System.EventHandler(this.frmGeneraProduccion_Shown);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsEjecutar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblFilas;
        private System.Windows.Forms.ToolStripButton tsSuspender;
        private System.Windows.Forms.ToolStripButton tsVolver;
        private System.Windows.Forms.ToolStripButton tsCerrar;
        private DevExpress.XtraGrid.GridControl dgvOrdenes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl dgvSalidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl dgvEntradas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
    }
}