using Intermedia_;
using Intermedia_.Repositories.Produccion;
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

        public ProduccionEntryModelConsulta() { 
        
        
        }

        public ProduccionEntryModelConsulta anular()
        {

            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

            cbr_ProduccionEntry escaneoAnuladoEntity = produccionEntryRepo.anularEntrieEscaneo(this.id);

            ProduccionEntryModelConsulta escaneoAnulado = new ProduccionEntryModelConsulta();

            escaneoAnulado.id = escaneoAnuladoEntity.id;
            escaneoAnulado.deletedId = escaneoAnuladoEntity.deletedId;
            escaneoAnulado.fecha = escaneoAnuladoEntity.fecha;
            escaneoAnulado.codigoProducto = escaneoAnuladoEntity.itemcode;
            escaneoAnulado.numero = escaneoAnuladoEntity.numero;
            escaneoAnulado.cantidad = escaneoAnuladoEntity.quantity;
            escaneoAnulado.usuario = escaneoAnuladoEntity.usuario;
            escaneoAnulado.deleted = escaneoAnuladoEntity.deleted;


            return escaneoAnulado;



        }



    }
}
