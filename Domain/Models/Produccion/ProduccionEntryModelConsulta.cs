using Intermedia_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionEntryModelConsulta:ProduccionEntryModelMaster
    {
        public int id { get; set; }
        public bool cancelado { get; set; }


        public ProduccionEntryModelConsulta(string CodigoProducto) {

            this.codigoProducto = CodigoProducto;
            setNombreProducto();
        }



        //public ProduccionEntryModelConsulta anular()
        //{


        //    cbr_ProduccionEntry escaneoAnuladoEntity = _SolicitudDevolucionEntryRepo.anularEntrieEscaneo(this.id);

        //    SolicitudDevolucionEntryModelConsulta escaneoAnulado = new SolicitudDevolucionEntryModelConsulta();

        //    escaneoAnulado.id = escaneoAnuladoEntity.id;
        //    escaneoAnulado.deletedId = escaneoAnuladoEntity.deletedId;
        //    escaneoAnulado.fecha = escaneoAnuladoEntity.fecha;
        //    escaneoAnulado.CodigoProducto = escaneoAnuladoEntity.itemCode;
        //    escaneoAnulado.numero = escaneoAnuladoEntity.number;
        //    escaneoAnulado.cantidad = escaneoAnuladoEntity.quantity;
        //    escaneoAnulado.usuario = escaneoAnuladoEntity.usuario;
        //    escaneoAnulado.deleted = escaneoAnuladoEntity.deleted;


        //    return escaneoAnulado;



        //}



    }
}
