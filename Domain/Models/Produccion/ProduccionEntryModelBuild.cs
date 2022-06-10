using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionEntryModelBuild:ProduccionEntryModelMaster
    {

        public ProduccionEntryModelBuild() { 
        
        
        }

        public ProduccionEntryModelBuild(ProduccionEntryModelBuild produccionEntryModelBuild)
        {
            codigoProducto = produccionEntryModelBuild.codigoProducto;
            this.cantidad = produccionEntryModelBuild.cantidad;
            this.deleted = produccionEntryModelBuild.deleted;
            this.deletedId = produccionEntryModelBuild.deletedId;
            this.descripcionProducto = produccionEntryModelBuild.descripcionProducto;
            this.fecha = produccionEntryModelBuild.fecha;
            this.numero = produccionEntryModelBuild.numero;
            this.usuario = produccionEntryModelBuild.usuario;
            this.cantidad = cantidad;
            setNombreProducto();
        }

        public ProduccionEntryModelBuild guardar() {
            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();
            cbr_ProduccionEntry cbr_ProduccionEntry = new cbr_ProduccionEntry();
            cbr_ProduccionEntry.cancelado = false;
            cbr_ProduccionEntry.deleted = false;
            cbr_ProduccionEntry.deletedId = 0;
            cbr_ProduccionEntry.fecha = fecha;
            cbr_ProduccionEntry.itemcode = codigoProducto;
            cbr_ProduccionEntry.numero = numero;
            cbr_ProduccionEntry.quantity = cantidad;
            cbr_ProduccionEntry.usuario = usuario;

            produccionEntryRepo.crearDocumentoIntermedioProduccion(cbr_ProduccionEntry);
            return this;
        }
    }
}
