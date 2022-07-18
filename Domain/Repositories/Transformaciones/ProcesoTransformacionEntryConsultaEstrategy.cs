using Domain.Interfaces;
using Domain.Models.Produccion;
using Intermedia_;
using Intermedia_.Repositories.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Transformaciones
{
    public class ProcesoTransformacionEntryConsultaEstrategy : IModelEntryConsulta
    {

        public ProcesosEntryModelConsulta anular(int id)
        {

           TransformacionEntryRepo transformacionEntryRepo = new TransformacionEntryRepo();

            cbr_TransformacionesEntry escaneoAnuladoEntity = transformacionEntryRepo.anularEntrieEscaneo(id);

            ProcesosEntryModelConsulta escaneoAnulado = new ProcesosEntryModelConsulta();

            escaneoAnulado.id = escaneoAnuladoEntity.id;
            escaneoAnulado.deletedId = escaneoAnuladoEntity.deletedId;
            escaneoAnulado.fecha = (DateTime) escaneoAnuladoEntity.fecha;
            escaneoAnulado.codigoProducto = escaneoAnuladoEntity.itemcode;
            escaneoAnulado.numero =(int) escaneoAnuladoEntity.numero;
            escaneoAnulado.cantidad = (double) escaneoAnuladoEntity.quantity;
            escaneoAnulado.usuario = escaneoAnuladoEntity.usuario;
            escaneoAnulado.deleted = true;
            escaneoAnulado.cancelado = false;


            return escaneoAnulado;
        }
    }
}
