using Domain.Interfaces;
using Intermedia_;
using Intermedia_.Repositories.Produccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProcesosEntryModelConsulta : ProduccionEntryModelMaster
    {
        public int id { get; set; }
        public bool cancelado { get; set; }
        public IModelEntryConsulta Estrategia { get; set; }

        public ProcesosEntryModelConsulta(string CodigoProducto) {

            this.codigoProducto = CodigoProducto;
            setNombreProducto();
        }

        public ProcesosEntryModelConsulta() { 
        
        
        }


       

         public ProcesosEntryModelConsulta(IModelEntryConsulta estrategia)
        {

            Estrategia = estrategia;
        }


        

        public ProcesosEntryModelConsulta anular()
        {

            //ProduccionEntryRepo produccionEntryRepo = new ProduccionEntryRepo();

            //cbr_ProduccionEntry escaneoAnuladoEntity = produccionEntryRepo.anularEntrieEscaneo(this.id);

            ProcesosEntryModelConsulta escaneoAnulado = new ProcesosEntryModelConsulta();

            var anulado = Estrategia.anular(this.id);

            escaneoAnulado.id = anulado.id;
            escaneoAnulado.deletedId = anulado.deletedId;
            escaneoAnulado.fecha = anulado.fecha;
            escaneoAnulado.codigoProducto = anulado.codigoProducto;
            escaneoAnulado.numero = anulado.numero;
            escaneoAnulado.cantidad = anulado.cantidad;
            escaneoAnulado.usuario = anulado.usuario;
            escaneoAnulado.deleted = anulado.deleted;
            return escaneoAnulado;



        }



    }
}
