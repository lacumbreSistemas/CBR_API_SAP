using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_SolicitudDevolucionEntryRepo: MasterRespository 
    {

        public cbr_SolicitudDevolucionEntry crearCbr_SolicitudDevolucionEntry(cbr_SolicitudDevolucionEntry Entry)
        {

            db.cbr_SolicitudDevolucionEntry.Add(Entry);
            db.SaveChanges();

            return Entry; 
        }

        public List<cbr_SolicitudDevolucionEntry> obtenerEntriesPornumber(int number) {

            return db.cbr_SolicitudDevolucionEntry.Where(i => i.number == number).ToList(); 
            
        }


        public List<cbr_SolicitudDevolucionEntry> obtenerEntriesPorNumberItemCode(int number, string itemCode)
        {

            return db.cbr_SolicitudDevolucionEntry.Where(i => i.number == number && i.itemCode == itemCode).ToList();

        }

        public cbr_SolicitudDevolucionEntry obtenerEntriesPorID(int id)
        {
            return db.cbr_SolicitudDevolucionEntry.FirstOrDefault(i => i.id == id);
        }

        public cbr_SolicitudDevolucionEntry anularEntrieEscaneo(cbr_SolicitudDevolucionEntry escaneoPorAnular) {


            cbr_SolicitudDevolucionEntry escaneoAnulacion = new cbr_SolicitudDevolucionEntry();
            
            
            escaneoPorAnular.deleted = true;

            escaneoAnulacion.deletedId = escaneoPorAnular.id; 
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.number = escaneoPorAnular.number;
            escaneoAnulacion.fecha = DateTime.Now;
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.usuario = escaneoPorAnular.usuario;

            escaneoAnulacion

        }

    }
}
