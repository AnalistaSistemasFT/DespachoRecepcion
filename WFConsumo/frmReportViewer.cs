using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
            Visor.Zoom(70);
        }

        public frmReportViewer(object objProxy)
        {
            InitializeComponent();
            Visor.ReportSource = objProxy;
            Visor.Zoom(70);
        }
        

    }
}
