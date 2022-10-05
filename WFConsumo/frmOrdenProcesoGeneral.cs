using CRN.Componentes;
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
    public partial class frmOrdenProcesoGeneral : Form
    {
        COrdenProduccionV2 corden;
        public frmOrdenProcesoGeneral()
        {
            InitializeComponent();
            corden = new COrdenProduccionV2();
            cargarordenesEnProceso();
        }

        public void cargarordenesEnProceso() 
        {
            string consulta = "select  *  from tblOrdenProduccion where status='PROCESO' or status='INPR'";
            var data=corden.retornarTabla(consulta);
            this.gridControl1.DataSource = data.Tables[0];
        }

    }
}
