using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WFConsumo.frmGRH.DespachoOrdenCerrada
{
    public partial class RealizarEntrega : DevExpress.XtraEditors.XtraForm
    {
        public RealizarEntrega(string IdDespacho)
        {
            InitializeComponent();
            labelDespacho.Text = IdDespacho;
        }
    }
}