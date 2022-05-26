using SAP.Models.Mermas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Models.Produccion
{
    public class ProduccionSAPEntity
    {
        public int DocEntry { get; set; }
        public string WhsCode { get; set; }
        public string Comentario { get; set; }
        public string UsuarioEncargado { get; set; }

        public DateTime Fecha { get; set; }

        public string RemarkID { get; set; }
        public string Remark { get; set; }
        public string CentroCosto { get; set; }
        public string CentroCosto3 { get; set; }
        public string CuentaContable { get; set; }

        public string itemCode { get; set; }

        public double quantity { get; set; }

        public List<ProduccionSAPEntryEntity> produccionEntryEntrada { get; set; }



        public ProduccionSAPEntity()
        {
            produccionEntryEntrada = new List<ProduccionSAPEntryEntity>();
        }

    }
}
