using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace ConsumoEtiquetas
{
    public class Program
    {
        static Orden orden;
        static void Main(string[] args)
        {
            CargaProduccion();
            ListarProduccion();
            Consumir();
            ListarConsumido();
            Console.ReadKey();
        }

        public static void Consumir()
        {
            decimal Acum=0 ,Csmd = 0,Disp = 0;
            Paquete p;Paquete c;
            int j = 0,i=0;
            bool ok = true;
            Consumo cons;
            while (ok)
            {
                c = orden.ConsumidoList[i];
                 Disp = Disp + c.Stock;
                p = orden.ProducidoList[j];
                while (Disp >= p.Stock && ok)
                {
                    Disp -= p.Stock;
                    cons = new Consumo() { Orden = orden.OrdenId, Item = c.Item, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = p.Stock };
                    orden.ConsumidoPartList.Add(cons);
                    j++;
                    if (j <= orden.ProducidoList.Count - 1)
                    {
                        p = orden.ProducidoList[j];

                    }
                    else
                        ok = false;
                }
                if (Disp < p.Stock)
                {
                    p.Stock -= Disp;
                    cons = new Consumo() { Orden = orden.OrdenId, Item = c.Item, PaqConsumido = c.PaqueteId, PaqProducido = p.PaqueteId, Peso = Disp };
                    Disp = 0;
                    orden.ConsumidoPartList.Add(cons);
                }
                i++;
                if (i > orden.ConsumidoList.Count-1)
                    ok = false;
            }
        }
        public static void ListarConsumido()
        {
            foreach(Consumo c in orden.ConsumidoPartList)
            {
                Console.WriteLine("Orden:"+c.Orden+" Prod:"+c.PaqProducido+" Cons:"+c.PaqConsumido+" Cant:"+c.Peso.ToString());
            }
        }

        public static void ListarProduccion2()
        {
            for(int i=0;i<=orden.ProducidoList.Count-1;i++)
            {
                Console.WriteLine(orden.ProducidoList[i].PaqueteId);
            }
        }
        public static void ListarProduccion()
        {
            Console.WriteLine("Orden:" + orden.OrdenId + " Fecha:" + orden.Fecha);
            Console.WriteLine("Producido:");
            Console.WriteLine("----------");

            if (orden.ProducidoList != null) 
            {
                foreach (Paquete p in orden.ProducidoList)
                {
                    Console.WriteLine("\tPaquete:" + p.PaqueteId);
                    Console.WriteLine("\tCodigo:" + p.Item);
                    Console.WriteLine("\tPiezas:" + p.Piezas);
                    Console.WriteLine("\tPeso:" + p.Peso);
                    Console.WriteLine("\tStock:" + p.Stock);
                }
            
            }
            
            Console.WriteLine("Consumido:");
            Console.WriteLine("----------");
            foreach (Paquete p in orden.ConsumidoList)
            {
                Console.WriteLine("\tPaquete:" + p.PaqueteId);
                Console.WriteLine("\tCodigo:" + p.Item);
                Console.WriteLine("\tPiezas:" + p.Piezas);
                Console.WriteLine("\tPeso:" + p.Peso);
                Console.WriteLine("\tStock:" + p.Stock);
            }
        }
        public static void CargaProduccion()
        {
            orden = new Orden() { OrdenId = "E17000001669", Fecha = DateTime.Now };
            //Producido
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30148", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30149", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30150", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30151", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30152", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30153", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30154", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30155", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30156", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30157", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30158", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30159", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30160", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30161", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30162", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30163", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30164", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30165", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30166", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30167", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30168", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30169", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30170", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30171", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30172", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30173", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30174", Item = "1798-6", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30175", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30176", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30177", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30178", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30179", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30180", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30181", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30182", Item = "1798-6", Piezas = 1, Peso =635, Stock =635 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30183", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30184", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30185", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30186", Item = "1798-6", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30187", Item = "1798-6", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "1707V30188", Item = "1798-6", Piezas = 1, Peso =252, Stock =252 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06432", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06434", Item = "9074-4", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06436", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06438", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06440", Item = "9074-4", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06442", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06447", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06449", Item = "9074-4", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06451", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06453", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06455", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06457", Item = "9074-4", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06459", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06461", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06463", Item = "9074-4", Piezas = 1, Peso =636, Stock =636 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06465", Item = "9074-4", Piezas = 1, Peso =637, Stock =637 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06467", Item = "9074-4", Piezas = 1, Peso =664, Stock =664 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06469", Item = "9074-4", Piezas = 1, Peso =664, Stock =664 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06471", Item = "9074-4", Piezas = 1, Peso =663, Stock =663 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06473", Item = "9074-4", Piezas = 1, Peso =663, Stock =663 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06475", Item = "9074-4", Piezas = 1, Peso =663, Stock =663 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06477", Item = "9074-4", Piezas = 1, Peso =663, Stock =663 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06479", Item = "9074-4", Piezas = 1, Peso =638, Stock =638 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06481", Item = "9074-4", Piezas = 1, Peso =425, Stock =425 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06483", Item = "9074-4", Piezas = 1, Peso =505, Stock =505 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06485", Item = "9074-4", Piezas = 1, Peso =988, Stock =988 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06491", Item = "9074-4", Piezas = 1, Peso =573, Stock =573 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06493", Item = "9074-4", Piezas = 1, Peso =278, Stock =278 });
            //orden.ProducidoList.Add(new Paquete() { PaqueteId = "17SCR06495", Item = "9074-4", Piezas = 1, Peso =296, Stock =296 });
            ////Consumido
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11188", Item = "5727-3", Piezas = 1, Peso =1443.483, Stock =1443.483 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11910", Item = "5727-3", Piezas = 1, Peso =1451.985, Stock =1451.985 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11178", Item = "5727-3", Piezas = 1, Peso =1474.38, Stock =1474.38 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11908", Item = "5727-3", Piezas = 1, Peso =1451.985, Stock =1451.985 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11157", Item = "5727-3", Piezas = 1, Peso =1616.747, Stock =1616.747 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11962", Item = "5727-3", Piezas = 1, Peso =1433.446, Stock =1433.446 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11965", Item = "5727-3", Piezas = 1, Peso =1433.446, Stock =1433.446 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11909", Item = "5727-3", Piezas = 1, Peso =1451.985, Stock =1451.985 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11187", Item = "5727-3", Piezas = 1, Peso =1443.483, Stock =1443.483 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11249", Item = "5727-3", Piezas = 1, Peso =1433.184, Stock =1433.184 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11179", Item = "5727-3", Piezas = 1, Peso =1474.38, Stock =1474.38 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11252", Item = "5727-3", Piezas = 1, Peso =1433.184, Stock =1433.184 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11231", Item = "5727-3", Piezas = 1, Peso =1573.251, Stock =1573.251 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11198", Item = "5727-3", Piezas = 1, Peso =1427.005, Stock =1427.005 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11902", Item = "5727-3", Piezas = 1, Peso =1447.865, Stock =1447.865 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11945", Item = "5727-3", Piezas = 1, Peso =1458.164, Stock =1458.164 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11251", Item = "5727-3", Piezas = 1, Peso =1433.184, Stock =1433.184 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11222", Item = "5727-3", Piezas = 1, Peso =1449.663, Stock =1449.663 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11901", Item = "5727-3", Piezas = 1, Peso =1447.865, Stock =1447.865 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11192", Item = "5727-3", Piezas = 1, Peso =1443.483, Stock =1443.483 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11207", Item = "5727-3", Piezas = 1, Peso =1641.224, Stock =1641.224 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11900", Item = "5727-3", Piezas = 1, Peso =1447.865, Stock =1447.865 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11954", Item = "5727-3", Piezas = 1, Peso =1468.463, Stock =1468.463 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11181", Item = "5727-3", Piezas = 1, Peso =1474.38, Stock =1474.38 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11202", Item = "5727-3", Piezas = 1, Peso =1427.005, Stock =1427.005 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11248", Item = "5727-3", Piezas = 1, Peso =1433.184, Stock =1433.184 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11221", Item = "5727-3", Piezas = 1, Peso =1449.663, Stock =1449.663 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11946", Item = "5727-3", Piezas = 1, Peso =1458.164, Stock =1458.164 });
            //orden.ConsumidoList.Add(new Paquete() { PaqueteId = "1705S11926", Item = "5727-3", Piezas = 1, Peso =1449.925, Stock =1449.925 });
        }
    }
}
