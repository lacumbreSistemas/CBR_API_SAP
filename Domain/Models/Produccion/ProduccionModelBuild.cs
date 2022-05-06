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
        }


        public ProduccionModelBuild guardar() {

            cbr_ProduccionHeader cbr_ProduccionHeader = new cbr_ProduccionHeader();
            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();
            cbr_ProduccionHeader.numero = numero;
            cbr_ProduccionHeader.comentario = comentario;
            cbr_ProduccionHeader.entradaDocEntry = 0;
            cbr_ProduccionHeader.salidaDocEntry = 0;
            cbr_ProduccionHeader.anulado = false;
            cbr_ProduccionHeader.usuario = usuario;
            cbr_ProduccionHeader.whsCode = codigoTienda;
            cbr_ProduccionHeader.codigoProducto = codigoProducto;

            numero = produccionHeaderRepo.crearDocumentoIntermedioProduccion(cbr_ProduccionHeader);

            return this;

        }
    }
}
