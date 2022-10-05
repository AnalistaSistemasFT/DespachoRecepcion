using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CCatalogoProducto
    {
        CADCatalogoProducto cadCatalogoProducto = new CADCatalogoProducto();
        public int GuardarProducto(CatalogoProducto _catalogoProducto)
        {
            return cadCatalogoProducto.GuardarProducto(_catalogoProducto);
        }
        public int ModificarProducto(CatalogoProducto _catalogoProducto)
        {
            return cadCatalogoProducto.ModificarProducto(_catalogoProducto);
        }
        public DataSet TraerTodoProducto()
        {
            return cadCatalogoProducto.TraerTodoProducto();
        }
    }
}
