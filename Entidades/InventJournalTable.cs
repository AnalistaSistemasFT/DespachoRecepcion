using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class InventJournalTable
    {
        public InventJournalTable()
        {
            Clase = "entity";
            InventJournalTransList = new List<InventJournalTrans>();
        }
        [XmlAttribute("class")]
        public string Clase { get; set; }
        public string Description { get; set; }
        public string JournalNameId { get; set; }
        public int NumOfLines { get; set; }
        public List<InventJournalTrans> InventJournalTransList { get; set; }
    }
}
