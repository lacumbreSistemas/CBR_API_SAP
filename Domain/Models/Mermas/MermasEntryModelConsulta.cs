using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
   public class MermasEntryModelConsulta:MermasEntryModelMaster
    {
        public int id { get; set; }
        public bool cancelado { get; set; }

   public MermasEntryModelConsulta(string codigoProducto)
        {
            this.codigoProducto = codigoProducto;
            setNombreProducto();

        }

        public MermasEntryModelConsulta() {   }

        public MermasEntryModelConsulta anular() {

            MermasEntryRepo mermasEntryRepo = new MermasEntryRepo();

            cbr_MermasEntry escaneoAnuladoEntity = mermasEntryRepo.anularEntrieEscaneo(this.id);

            MermasEntryModelConsulta escaneoAnulado = new MermasEntryModelConsulta();

            escaneoAnulado.id = escaneoAnuladoEntity.id;
            escaneoAnulado.deletedId = escaneoAnuladoEntity.deletedid;
            escaneoAnulado.fecha = escaneoAnuladoEntity.fecha;
            escaneoAnulado.codigoProducto = escaneoAnuladoEntity.itemCode;
            escaneoAnulado.numero = (int) escaneoAnuladoEntity.number;
            escaneoAnulado.cantidad = (double) escaneoAnuladoEntity.quantity;
            escaneoAnulado.usuario = escaneoAnuladoEntity.usuario;
            escaneoAnulado.deleted = escaneoAnuladoEntity.deleted;
      

            return escaneoAnulado;

        }
    }
}
