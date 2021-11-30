using Intermedia_.Repositories;
using Intermedia_;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Models
{
    public class PurchaseOrderEntryModel
    {

        //Publics
        public int docEntry { get; set; }
        public string nombreProducto { get; set; }
        public string codigoProducto { get; set; }
        public  double cantidadOrdenada { get; set; }
        public double cantidadRecibida { get; set; }


        //Privates
                private cbrComprasSAPEntryRepository intermediaEntryRepository { get; set; }
                private cbrComprasSAPHeaderRepository intermediaHeaderRepository { get; set; }
                private PurchaseOrderHeaderRepository headerSAP { get; set; }
                private PurchaseOrderEntryRespository entrySAP { get; set; }
            private string usuario { get; set; }
        //Metodos

        public PurchaseOrderEntryModel(int docEntry, string nombreProducto, string codigoProducto, double cantidadOrdenada)
        {
            intermediaEntryRepository = new cbrComprasSAPEntryRepository();
            this.docEntry = docEntry;
            this.nombreProducto = nombreProducto;
            this.codigoProducto = codigoProducto;
            this.cantidadOrdenada = cantidadOrdenada;
            this.cantidadRecibida = this.intermediaEntryRepository.GetItemReceived(docEntry, codigoProducto);
        }

        public PurchaseOrderEntryModel()
        {

        }
        public PurchaseOrderEntryModel(PurchaseOrderEntryModel newEntry,string usuario = "")
        {
           
            this.docEntry = newEntry.docEntry;
            this.nombreProducto = newEntry.nombreProducto;
            this.codigoProducto = newEntry.codigoProducto;
            this.cantidadOrdenada = newEntry.cantidadOrdenada;
            this.cantidadRecibida = 0;
            this.usuario = usuario;

            headerSAP = new PurchaseOrderHeaderRepository();
            entrySAP = new PurchaseOrderEntryRespository();
            intermediaHeaderRepository = new cbrComprasSAPHeaderRepository();
            intermediaEntryRepository = new cbrComprasSAPEntryRepository();
        }

        public void agregar()
        {

           

           bool ifHeaderExist =  intermediaHeaderRepository.ifExist(this.docEntry);
          

            if (ifHeaderExist) {

                var HeaderSAP = headerSAP.getOne(docEntry);

                cbr_ComprasSAP_Header header = new cbr_ComprasSAP_Header();

                header.BaseEntry = HeaderSAP.docEntry;
                header.CardCode = HeaderSAP.cardCode;
                header.fecha = DateTime.Now;
                header.ifSAP = false;


                intermediaHeaderRepository.Post(header);
                
            }


             var EntrySAP  = entrySAP.getPurchaseOneEntrie(docEntry, codigoProducto); 
            cbr_ComprasSAP_Entry Entry = new cbr_ComprasSAP_Entry();


                Entry.BaseLine = EntrySAP.baseLine;
                Entry.BaseEntry = this.docEntry;
                Entry.deleted = false;
                Entry.fecha = DateTime.Now;
                Entry.ItemCode = this.codigoProducto;
                Entry.normaReparto = EntrySAP.normaReparto;
                Entry.Quantity = this.cantidadRecibida;
                Entry.Usuario = this.usuario;
                Entry.ifSap = false;


            intermediaEntryRepository.Post(Entry);


        }
     

    }
}
