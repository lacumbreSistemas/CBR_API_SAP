using Domain.Models.SolicitudDevolucionModels;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.SolicitudDevolucionRepositories
{
    public class EscaneoEntrysRepo
    {

        private cbr_SolicitudDevolucionEntryRepo _SolicitudDevolucionEntryRepo { get; set; }

        public EscaneoEntrysRepo() {
            _SolicitudDevolucionEntryRepo = new cbr_SolicitudDevolucionEntryRepo();
        }

        public SolicitudDevolucionEntryModelBuild crearSolicitudDevolusionEntry(SolicitudDevolucionEntryModelBuild _solicitudDevolucionEntryModelBuild)
        {

            SolicitudDevolucionEntryModelBuild _newSolicitudDevolucionEntryModelBuild = new SolicitudDevolucionEntryModelBuild(_solicitudDevolucionEntryModelBuild);
            return _newSolicitudDevolucionEntryModelBuild.guardar();
        }


        public List<SolicitudDevolucionEntryModelConsulta> historialEscaneosEntries(int number, string itemCode)
        { 
            List<SolicitudDevolucionEntryModelConsulta> _historialEscaneosEntries = new List<SolicitudDevolucionEntryModelConsulta>();

            _SolicitudDevolucionEntryRepo.obtenerEntriesPorNumberItemCode(number, itemCode).ForEach(i=> {

                SolicitudDevolucionEntryModelConsulta _entrie = new SolicitudDevolucionEntryModelConsulta(itemCode);
                _entrie.cantidad = i.quantity;
                _entrie.deleted = i.deleted;
                _entrie.deletedId = i.deletedId;
                _entrie.fecha = i.fecha;
                _entrie.id = i.id;
                _entrie.CodigoProducto = i.itemCode;
                _entrie.numero = i.number;
                _entrie.usuario = i.usuario;
                
                _historialEscaneosEntries.Add(_entrie);

            });

            return _historialEscaneosEntries;
        }

        public SolicitudDevolucionEntryModelConsulta anularEscaneo(SolicitudDevolucionEntryModelConsulta _SolicitudDevolucionEntryModelConsulta) {

           return  _SolicitudDevolucionEntryModelConsulta.anular();

        }



    }
}
