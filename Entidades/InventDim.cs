using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class InventDim
    {
        [XmlAttribute("class")]
        public string Clase { get; set; }
        public string InventBatchId { get; set; }
        public string InventColorId { get; set; }
        public string InventLocationId { get; set; }
        public string InventSerialId{ get; set; }
        public string InventSiteId { get; set; }
        public string InventSizeId { get; set; }
        public string InventStatusId { get; set; }
        public string  LicensePlateID { get; set; }
        public string WMSLocationId { get; set; }
        public InventDim()
        {
            Clase = "entity";
        }
    }
}
