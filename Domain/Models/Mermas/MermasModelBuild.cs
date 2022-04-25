using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Mermas
{
    public class MermasModelBuild : MermasModelMaster
    {

        public MermasModelBuild() { }

        public MermasModelBuild(MermasModelBuild mermaModelBuild) {

            codigoTienda = mermaModelBuild.codigoTienda;
            //codigoProveedor = mermaModelBuild.codigoProveedor;
            fechaCreacion = DateTime.Now;
            comentario = mermaModelBuild.comentario;
            usuario = mermaModelBuild.usuario;
            remark = mermaModelBuild.remark;

        }


        public MermasModelBuild guardar() {

            cbr_MermasHeader mermasHeader = new cbr_MermasHeader();
            MermasHeaderRepo mermasHeaderRepo = new MermasHeaderRepo();
            //mermasHeader.cardCode = codigoProveedor;
            mermasHeader.whsCode = codigoTienda;
            mermasHeader.fecha = fechaCreacion;
            mermasHeader.number = numero;
            mermasHeader.comentario = comentario;
            mermasHeader.anulado = false;
            mermasHeader.usuario = usuario;
            mermasHeader.ifSAP = false;
            mermasHeader.remarkId = remark;
            numero = mermasHeaderRepo.crearDocumentoIntermedioMerma(mermasHeader);

            return this;

        }

    }
}
