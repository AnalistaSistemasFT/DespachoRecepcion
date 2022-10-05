using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CRespuestaMecanizado
    {
        CADRespuestaMecanizado _cadRespuestaMecanizado = new CADRespuestaMecanizado();
        public int GuardarRespuesta(RespuestaMecanizado _respuestaMecanizado)
        {
            return _cadRespuestaMecanizado.GuardarRespuesta(_respuestaMecanizado);
        }
        public int ModificarRespuesta(RespuestaMecanizado _respuestaMecanizado)
        {
            return _cadRespuestaMecanizado.ModificarRespuesta(_respuestaMecanizado);
        }
        public DataSet TraerTodoRespuesta()
        {
            return _cadRespuestaMecanizado.TraerTodoRespuesta();
        }
        public DataSet TraerRespuesta(int id_respuesta)
        {
            return _cadRespuestaMecanizado.TraerRespuesta(id_respuesta);
        }
    }
}
