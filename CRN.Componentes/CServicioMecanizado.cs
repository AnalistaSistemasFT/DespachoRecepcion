using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CServicioMecanizado
    {
        CADServicioMecanizado cadServicioMecanizado = new CADServicioMecanizado();
        public int GuardarServicio(ServicioMecanizado _servicioMecanizado)
        {
            return cadServicioMecanizado.GuardarServicio(_servicioMecanizado);
        }

        public DataSet TraerTodoServicio()
        {
            return cadServicioMecanizado.TraerTodoServicio();
        }
        //Lista Administradores
        public DataSet ListaServiciosPendientes()
        {
            return cadServicioMecanizado.ListaServiciosPendientes();
        }
        public DataSet ListaServiciosEnProceso()
        {
            return cadServicioMecanizado.ListaServiciosEnProceso();
        }
        public DataSet ListaServiciosParciales()
        {
            return cadServicioMecanizado.ListaServiciosParciales();
        }
        public DataSet ListaServiciosFinalizados()
        {
            return cadServicioMecanizado.ListaServiciosFinalizados();
        }
        //Lista Operarios
        public DataSet ListaServiciosEnProcesoOp(int _IdEmpleado)
        {
            return cadServicioMecanizado.ListaServiciosEnProcesoOp(_IdEmpleado);
        }
        public DataSet ListaServiciosParcialesOp(int _IdEmpleado)
        {
            return cadServicioMecanizado.ListaServiciosParcialesOp(_IdEmpleado);
        }
        public DataSet ListaServiciosFinalizadosOp(int _IdEmpleado)
        {
            return cadServicioMecanizado.ListaServiciosFinalizadosOp(_IdEmpleado);
        }
        public DataSet BuscarServicio(int IdServicio)
        {
            return cadServicioMecanizado.BuscarServicio(IdServicio);
        }
        public DataSet ReporteFechas(DateTime _fechaInicial, DateTime _fechaFinal)
        {
            return cadServicioMecanizado.ReporteFechas(_fechaInicial, _fechaFinal);
        }
        public DataSet ReporteFechasOper(DateTime _fechaInicial, DateTime _fechaFinal, int _IdEmpleado)
        {
            return cadServicioMecanizado.ReporteFechasOper(_fechaInicial, _fechaFinal, _IdEmpleado);
        }
        public int ModificarServicio(ServicioMecanizado _servicioMecanizado)
        {
            return cadServicioMecanizado.ModificarServicio(_servicioMecanizado);
        }
        public int ModificarEstado(int _Estado, int _IdMecanizado, int _IdOperarioAsignado)
        {
            return cadServicioMecanizado.ModificarEstado(_Estado, _IdMecanizado, _IdOperarioAsignado);
        }
        public DataSet TraerServicioPopUp(int _IdMecanizado)
        {
            return cadServicioMecanizado.TraerServicioPopUp(_IdMecanizado);
        }
        public int ModificarFechaFinalizacion(int _IdMecanizado, DateTime _fechaFinal)
        {
            return cadServicioMecanizado.ModificarFechaFinalizacion(_IdMecanizado, _fechaFinal);
        }
        public int ModificarCantidadPendiente(int _IdMecanizado, int _cantidadPendiente)
        {
            return cadServicioMecanizado.ModificarCantidadPendiente(_IdMecanizado, _cantidadPendiente);
        }
        public int ModificarEstadoFinal(int _IdMecanizado, int _Estado)
        {
            return cadServicioMecanizado.ModificarEstadoFinal(_IdMecanizado, _Estado);
        }
        public int EliminarServicio(int _IdServicio)
        {
            return cadServicioMecanizado.EliminarServicio(_IdServicio);
        }
        public int IngresarServ()
        {
            return cadServicioMecanizado.IngresarServ();
        }
    }
}
