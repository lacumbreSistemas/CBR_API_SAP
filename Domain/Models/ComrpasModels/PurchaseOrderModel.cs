﻿using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PurchaseOrderModel
    {
        public int docEntry { get; set; }
        public DateTime fechaCreacion { get; set; }

        public int docNum { get; set; }
        public string codigoProveedor { get; set; }

        public DateTime fechaEntrega { get; set; }
        public string nombreProveedor { get; set; }

        private PurchaseOrderHeaderRepository headerRepository { get; set; }

        private PurchaseOrderEntryRespository entriesRepository { get; set; }

        public List<PurchaseOrderEntryModel> entries { get; set; }

        public PurchaseOrderModel(int docEntry,bool includeEntries = false)
        {
          // this.headerRepository = new PurchaseOrderHeaderRepository();
            this.entriesRepository = new PurchaseOrderEntryRespository();
            this.entries = new List<PurchaseOrderEntryModel>();
            getPurchaseOrderHeader(docEntry, includeEntries);
        }

        public PurchaseOrderModel()
        {
            
        }

        public void getPurchaseOrderHeader(int docEntry, bool includeEntries)
        {
            var header = this.headerRepository.getOne(docEntry);
            this.docEntry = header.docEntry;
            this.fechaCreacion = header.docDueDate ;
            this.docNum = header.docNum;
            this.codigoProveedor = header.cardCode;
            this.fechaEntrega = header.taxDate;
            this.nombreProveedor = header.cardName;

          
            
            if (includeEntries)
            {
                var entriesSAP = entriesRepository.ObtenerListaDeEntriesOrdenDeCompra(docEntry);
                entriesSAP.ForEach(entry =>
                {
                    PurchaseOrderEntryModel Entry = new PurchaseOrderEntryModel();
                    Entry.docEntry = entry.docEntry;
                    Entry.codigoProducto = entry.codigoProducto;
                    Entry.nombreProducto = entry.nombreProducto;
                    Entry.cantidadOrdenada = entry.cantidadOrdenada;

                    this.entries.Add(Entry);
                });
            }
          

    }
}
}