using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class Costo
    {
        private decimal costoTotal;
        private decimal costoSegunda;
        private decimal costoPrimera;
        private decimal totalCostoSegunda;
        private decimal pesoPrimeraKgs;
        private decimal pesoPrimeraPza;
        private int piezasPrimeraKgs;
        private int piezasPrimeraPza;
        private decimal kgsPrimera;
        private decimal costoKgsPrimera;
        private decimal costoPzaPrimera;
        private int piezasPrimera;

        public int PiezasPrimera
        {
            get { return piezasPrimera; }
            set { piezasPrimera = value; }
        }

        public decimal CostoPzaPrimera
        {
            get { return costoPzaPrimera; }
            set { costoPzaPrimera = value; }
        }

        public decimal CostoKgsPrimera
        {
            get { return costoKgsPrimera; }
            set { costoKgsPrimera = value; }
        }

        public decimal KgsPrimera
        {
            get { return kgsPrimera; }
            set { kgsPrimera = value; }
        }

        public int PiezasPrimeraPza
        {
            get { return piezasPrimeraPza; }
            set { piezasPrimeraPza = value; }
        }

        public int PiezasPrimeraKgs
        {
            get { return piezasPrimeraKgs; }
            set { piezasPrimeraKgs = value; }
        }

        public decimal PesoPrimeraPza
        {
            get { return pesoPrimeraPza; }
            set { pesoPrimeraPza = value; }
        }

        public decimal PesoPrimeraKgs
        {
            get { return pesoPrimeraKgs; }
            set { pesoPrimeraKgs = value; }
        }

        public decimal TotalCostoSegunda
        {
            get { return totalCostoSegunda; }
            set { totalCostoSegunda = value; }
        }

        public decimal  CostoPrimera
        {
            get { return costoPrimera; }
            set { costoPrimera = value; }
        }

        public decimal CostoSegunda
        {
            get { return costoSegunda; }
            set { costoSegunda = value; }
        }

        public decimal CostoTotal
        {
            get { return costoTotal; }
            set { costoTotal = value; }
        }

        public void CalculoCosto(DataTable dt,decimal PrecioTon)
        {
            decimal PrecioKg = PrecioTon / 1000;
            decimal sumaPeso = dt.AsEnumerable().Sum(x => x.Field<decimal>("Peso"));

            var sumaPiezas = dt.AsEnumerable().Sum(x => x.Field<short>("Piezas"));

            var result = from r in dt.AsEnumerable()
                         group r by new { Estado = r["Estado"], Unidad = r["AXUnitMeasure"] } into g
                         select new
                         {
                             Estado = g.Key.Estado,
                             Unidad = g.Key.Unidad,
                             SumPeso = g.Sum(x => Convert.ToDecimal(x["Peso"])),
                             SumPiezas = g.Sum(x => Convert.ToDecimal(x["Piezas"]))
                         };

            foreach (var r in result)
            {
                if (r.Estado.ToString() == "GOOD")
                {
                    PiezasPrimera += (short)r.SumPiezas;
                    KgsPrimera += (decimal)r.SumPeso;
                    if (r.Unidad.ToString() == "KGS")
                    {
                        PesoPrimeraKgs = (decimal)(r.SumPeso);
                        PiezasPrimeraKgs = (short)(r.SumPiezas);
                    }
                    else
                    {
                        PesoPrimeraPza = (decimal)(r.SumPeso);
                        PiezasPrimeraPza = (short)(r.SumPiezas);
                    }
                }
                else
                {
                    CostoSegunda = (0.01M * r.SumPeso);
                    TotalCostoSegunda += CostoSegunda;
                }
                Console.WriteLine("Estado {0}, Unidad {1}, Peso {2}, Piezas {3}", r.Estado, r.Unidad, r.SumPeso, r.SumPiezas);
            }

            CostoTotal = PrecioKg * sumaPeso;

            CostoPrimera = CostoTotal - TotalCostoSegunda;

            if (KgsPrimera > 0)
                CostoKgsPrimera = CostoPrimera / KgsPrimera;
            else
                CostoKgsPrimera = 0;

            if (PiezasPrimeraPza > 0)
                CostoPzaPrimera = CostoKgsPrimera * PesoPrimeraPza / PiezasPrimeraPza;
            else
                CostoPzaPrimera = 0;
        }
    }
}
