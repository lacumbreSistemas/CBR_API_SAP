using Intermedia_.Repositories;
using SAP.Repositories.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
   public class MermaModelConsulta: MermasModelMaster
    {
      public int docEntry { get; set;  }

     public string nombreProveedor { get; set; } 

      public List<MermasEntryResumenConsulta> entries { get; set; }


        public MermaModelConsulta() {

            entries = new List<MermasEntryResumenConsulta>();
        }

        public MermaModelConsulta(int numero) {
            entries = new List<MermasEntryResumenConsulta>();
            this.numero = numero;
        }

        public void obtenerHeader() {
            MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();
            var mermaHEader = mermasHeaderRepo.obtenerDocumentoIntermedioMerma(numero);

            this.anulado = mermaHEader.anulado;
            this.comentario = mermaHEader.comentario;

            this.fechaCreacion = mermaHEader.fecha;
            this.docEntry = (int) mermaHEader.docEntry;
            this.codigoProveedor = mermaHEader.cardCode;
            this.codigoTienda = mermaHEader.whsCode;
            this.usuario = mermaHEader.usuario;

        }

        public void setNombreProveedor() {

            ProveedorSAPRepository proveedorSAPRepository = new ProveedorSAPRepository();
            var proveedor = proveedorSAPRepository.obtenerProveedorCodigo(codigoProveedor);
            nombreProveedor = proveedor.Nombre;
   
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
