using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SolicitudDevolucionModels
{
    public class SolicitudDevolucionEntryResumenActualizar: SolicitudDevolucionEntryResumenMaster
    {


        private cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo { get; set; }
       
        public SolicitudDevolucionEntryResumenActualizar(string itemCode, int numero){

            this.Numero = numero;
            this.CodigoProducto = itemCode;
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();
        }

        public SolicitudDevolucionEntryResumenActualizar()
        {

            this.Numero = Numero;
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();
        }

        public void anular()
        {

            List<cbr_SolicitudDevolucionEntry> escaneoAnuladoEntity = _SolicitudDevolucionEntryRepo.obtenerEntriesPorNumberItemCode(Numero, CodigoProducto);


            escaneoAnuladoEntity.ForEach(i => {

                _SolicitudDevolucionEntryRepo.anularEntrieEscaneo(i.id);

            });



        }
    }
}
