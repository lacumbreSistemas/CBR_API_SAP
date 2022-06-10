using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
  public  class MermasEntryModelBuild: MermasEntryModelMaster
    {

     
        public MermasEntryModelBuild(){  }

        public MermasEntryModelBuild(MermasEntryModelBuild mermasEntryModelBuild) {

            codigoProducto = mermasEntryModelBuild.codigoProducto;
            cantidad = mermasEntryModelBuild.cantidad;
            fecha = mermasEntryModelBuild.fecha;
            deleted = mermasEntryModelBuild.deleted;
            deletedId = mermasEntryModelBuild.deletedId;
            numero = mermasEntryModelBuild.numero;
            usuario = mermasEntryModelBuild.usuario;
            setNombreProducto();

        }

        public MermasEntryModelBuild guardar() {

            MermasEntryRepo mermasEntryRepo = new MermasEntryRepo();
            cbr_MermasEntry MermasEntry = new cbr_MermasEntry();

            MermasEntry.itemCode = codigoProducto;
            MermasEntry.number = numero;
            MermasEntry.quantity = cantidad;
            MermasEntry.usuario = usuario;
            MermasEntry.deleted = false;
            MermasEntry.fecha = DateTime.Now;
            MermasEntry.cancelado = false;

            mermasEntryRepo.crearEntryDocumentoIntermedioMerma(MermasEntry);



            return this; 
        }

    }
}
