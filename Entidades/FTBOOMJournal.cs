using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlRoot(Namespace = "http://schemas.microsoft.com/dynamics/2008/01/documents/FTBOOMJournal")]
    public class FTBOOMJournal
    {
        public FTBOOMJournal()
        {
        }
        public string DocPurpose { get; set; }
        public string SenderId { get; set; }
        public InventJournalTable InventJournalTable { get; set; }
    }
}
