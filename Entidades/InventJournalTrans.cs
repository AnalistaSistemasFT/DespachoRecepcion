using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class InventJournalTrans
    {
        public InventJournalTrans()
        {
            Clase = "entity";
            //InventDimList = new List<InventDim>();
        }
        [XmlAttribute("class")]
        public string Clase { get; set; }
        public string BOMLine { get; set; }
        public decimal CostAmount { get; set; }
        public decimal CostPrice { get; set; }
        public string ItemId { get; set; }
        public decimal LineNum { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal Qty { get; set; }
        public string TransDate { get; set; }

//        public List<InventDim> InventDimList { get; set; }
        public InventDim InventDim { get; set; }
    }
}
