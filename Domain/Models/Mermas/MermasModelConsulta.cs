using Intermedia_.Repositories;
using SAP;
using SAP.Repositories;
using SAP.Repositories.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
    public class MermasModelConsulta : MermasModelMaster
    {


        public string nombreProveedor { get; set; }

      
        public List<MermasEntryResumenConsulta> entries { get; set; }
        public bool ifSAP {get; set;}


        public MermasModelConsulta() {

            entries = new List<MermasEntryResumenConsulta>();
        }

        public MermasModelConsulta(int numero) {
            entries = new List<MermasEntryResumenConsulta>();
            this.numero = numero;
            obtenerHeader();
        }

        public void obtenerHeader() {
            MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();
            var mermaHEader = mermasHeaderRepo.obtenerDocumentoIntermedioMerma(numero);

            this.anulado = mermaHEader.anulado;
            this.comentario = mermaHEader.comentario;

            this.fechaCreacion = mermaHEader.fecha;
            this.ifSAP =  (bool)mermaHEader.ifSAP;
            //this.codigoProveedor = mermaHEader.cardCode;
            this.codigoTienda = mermaHEader.whsCode;
            this.usuario = mermaHEader.usuario;
            this.remarkCode = mermaHEader.remarkId;
        }

     


        public void setRemark() {
            RemarksRepo mermaModelSAP = new RemarksRepo();

            remark = mermaModelSAP.obterRemark(this.remarkCode);
            
        }


        public void resumenEntries() {
            MermasEntryRepo mermaEntryRepo = new MermasEntryRepo();

            mermaEntryRepo.obtenerEntriesPorNumber(numero).Where(i => (bool)!i.cancelado).GroupBy(i => new { i.number, i.itemCode }).ToList().ForEach(i => {

                MermasEntryResumenConsulta mermasEntryResumenConsulta = new MermasEntryResumenConsulta(i.FirstOrDefault().itemCode);
                mermasEntryResumenConsulta.numero = this.numero;
                mermasEntryResumenConsulta.cantidadEscaneada = i.Sum(i=> i.quantity);
                entries.Add(mermasEntryResumenConsulta);
            
            });

        }
        

    }
}
