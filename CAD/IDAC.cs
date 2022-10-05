using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CAD
{
    public interface IDAC
    {
        int EjecutarComando(string sDML);

        DataSet EjecutarConsulta(string sSelect);
    }
}
