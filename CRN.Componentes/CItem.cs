using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Transactions;

using CRN.Entidades;
using CAD;

namespace CRN.Componentes
{
    public class CItem
    {

        CADItem cadItem = new CADItem();
       
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}

        public DataSet TraerTodoItem()
        {
            return cadItem.TraerTodoItem();
        }
        protected internal DataSet TraerTodoItem(string where)
        {
            return cadItem.TraerTodoItem(where);
        }
        public  DataSet TraerItemSucursal(string item)
        {
            return cadItem.DetalleItemSucursal(item);
        }
        public void GuardarItem(Item oItem)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadItem.GuardarItem(oItem);
        }

        public void ModificarItem(Item oItem)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadItem.ModificarItem(oItem);
        }


        public Item TraerItem(string cod)
        {
            Item oItem = cadItem.TraerItem(cod);
            return oItem;
        }

        public DataSet TraerCatUnidad()
        {
            return cadItem.TraerCatUnidad();
        }
        public DataSet TraerCat_Calidad()
        {
            return cadItem.TraerCat_Calidad();
        }

        public DataSet TraerGrupoItem()
        {
            return cadItem.TraerGrupoItem();
        }
        public DataSet TraerGrupoProducto()
        {
            return cadItem.TraerGrupoProducto();
        }
        public DataSet TraerNaturaleza()
        {
            return cadItem.TraerNaturaleza();
        }

        public DataSet TraerTipoGalvanizado()
        {
            return cadItem.TraerTipoGalvanizado();
        }
        public DataSet TraerSeguimiento()
        {
            return cadItem.TraerSeguimiento();
        }
        public DataSet TraerSucursal()
        {
            return cadItem.TraerSucursal();
        }

        public DataSet BuscarItems(string _codigoPr, int _idSucursal)
        {
            return cadItem.BuscarItems(_codigoPr, _idSucursal);
        }
        public DataSet ListaItemResumen(string _idSucursal)
        {
            return cadItem.ListaItemResumen(_idSucursal);
        }
        public DataSet BuscarItemNombre(string _nombrePr, string _idSucursal)
        {
            return cadItem.BuscarItemNombre(_nombrePr, _idSucursal);
        }
        public DataSet BuscarItemCodigo(string _codigoPr, string _idSucursal)
        {
            return cadItem.BuscarItemCodigo(_codigoPr, _idSucursal);
        }
        public DataSet TraerProductosConItemFid(int _idSucursal)
        {
            return cadItem.TraerProductosConItemFid(_idSucursal);
        }
        public int VerificarItem(string Item)
        {
            return cadItem.VerificarItem(Item);
        }
        public DataSet TraerTodoInfo()
        {
            return cadItem.TraerTodoInfo();
        }
        public DataSet ConsultarItenF(string sItem)
        {
            return cadItem.TraerItemF(sItem);
        }
        
    }
}
