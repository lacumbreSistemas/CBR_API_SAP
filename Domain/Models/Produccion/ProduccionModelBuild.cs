using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
   public class ProduccionModelBuild:ProduccionModelMaster
    {
        public ProduccionModelBuild() { }

        public ProduccionModelBuild(ProduccionModelBuild produccionModelBuild) {

            codigoTienda = produccionModelBuild.codigoTienda;
            usuario = produccionModelBuild.usuario;
            comentario = produccionModelBuild.comentario;
            fechaCreacion = DateTime.Now;
            codigoProducto = produccionModelBuild.codigoProducto;
            cantidad = produccionModelBuild.cantidad;
            remarkCode = produccionModelBuild.remarkCode;
        }


        public ProduccionModelBuild guardar() {

            cbr_ProduccionHeader _cbr_ProduccionHeader = new cbr_ProduccionHeader();
            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            _cbr_ProduccionHeader.numero = this.numero;
            _cbr_ProduccionHeader.comentario = comentario;
            _cbr_ProduccionHeader.entradaDocEntry = 0;
            _cbr_ProduccionHeader.salidaDocEntry = 0;
            _cbr_ProduccionHeader.anulado = false;
            _cbr_ProduccionHeader.usuario = usuario;
            _cbr_ProduccionHeader.whsCode = codigoTienda;
            _cbr_ProduccionHeader.codigoProducto = codigoProducto;
            _cbr_ProduccionHeader.fecha = fechaCreacion;
            _cbr_ProduccionHeader.cantidad = cantidad;
            _cbr_ProduccionHeader.remarkId = remarkCode;
            numero = produccionHeaderRepo.crearDocumentoIntermedioProduccion(_cbr_ProduccionHeader);

            return this;

        }
    }
}
