using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Produccion
{
    public class ProcesoProduccionEntryConsultaEstrategy: IModelEntryConsulta
    {

        public ProcesosEntryModelConsulta anular(int id)
        {

            ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

            cbr_ProduccionEntry escaneoAnuladoEntity = produccionEntryRepo.anularEntrieEscaneo(id);

            ProcesosEntryModelConsulta escaneoAnulado = new ProcesosEntryModelConsulta();

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
