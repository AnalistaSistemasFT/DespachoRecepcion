using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.frmGRH;
using WFConsumo.frmGRH.Devoluciones;
using WFConsumo.frmGRH.Entrega;
using WFConsumo.frmGRH.Localizacion;

namespace WFConsumo
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLogin());
            //Application.Run(new frmTestData());
            //Application.Run(new ControlEntregas());
            //Application.Run(new VistaAlmacen(12081));
            //Application.Run(new NuevaDevolucion());
        }
        public static ObservableCollection<GlobalItem> _listaProductos = new ObservableCollection<GlobalItem>();
    }
}

