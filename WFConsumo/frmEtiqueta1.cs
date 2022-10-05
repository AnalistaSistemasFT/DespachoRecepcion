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
    public partial class frmEtiqueta1 : Form
    {
        public frmEtiqueta1(string uno, string dos, string tres,string cuatro,string cinco, string seis, string siete,string path)
        {
            InitializeComponent();
            cargardata(uno, dos, tres, cuatro, cinco, seis, siete,path);
        }

        void cargardata(string orden, string medida,string longitud,string peso,string baras,string calidad,string codigomaterial,string path) 
        {
            Factura1.SetParameterValue("orden",orden);
            Factura1.SetParameterValue("medida",medida);
            Factura1.SetParameterValue("longitud",longitud);
            Factura1.SetParameterValue("peso",peso);
            Factura1.SetParameterValue("barras",baras);
            Factura1.SetParameterValue("calidad",calidad);
            Factura1.SetParameterValue("codigo",codigomaterial);
            Factura1.SetParameterValue("imagen",path);
        }

    }
}
