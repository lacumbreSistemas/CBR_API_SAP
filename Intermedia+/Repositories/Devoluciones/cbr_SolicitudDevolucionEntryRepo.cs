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

            return db.cbr_SolicitudDevolucionEntry.Where(i => i.number == number && i.itemCode == itemCode && !(bool)i.cancelado).ToList();

        }

        public cbr_SolicitudDevolucionEntry obtenerEntriesPorID(int id)
        {
            return db.cbr_SolicitudDevolucionEntry.FirstOrDefault(i => i.id == id);
        }

        public cbr_SolicitudDevolucionEntry anularEntrieEscaneo(int id) {

            cbr_SolicitudDevolucionEntry escaneoPorAnular = db.cbr_SolicitudDevolucionEntry.FirstOrDefault(i=> i.id == id);
            cbr_SolicitudDevolucionEntry escaneoAnulacion = new cbr_SolicitudDevolucionEntry();

            if (escaneoPorAnular == null)
            {
                throw new Exception("Escaneo no encontrado");
            }
            else if ((bool) escaneoPorAnular.deleted) {

                escaneoAnulacion = db.cbr_SolicitudDevolucionEntry.FirstOrDefault(i => i.deletedId == escaneoPorAnular.id);
               

                throw new Exception("Escaneo ya fue anulado por "+ escaneoAnulacion.usuario);
            }else if ((bool) escaneoPorAnular.cancelado)
            {
                throw new Exception("Item cancelado");

            }

            
            escaneoPorAnular.deleted = true;

            escaneoAnulacion.deletedId = escaneoPorAnular.id; 
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.deleted = escaneoAnulacion.deleted;
            escaneoAnulacion.number = escaneoPorAnular.number;
            escaneoAnulacion.fecha = DateTime.Now;
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.usuario = escaneoPorAnular.usuario;
            escaneoAnulacion.quantity = escaneoPorAnular.quantity * (-1);
            escaneoAnulacion.deleted = false;

            db.cbr_SolicitudDevolucionEntry.Add(escaneoAnulacion);

            db.SaveChanges();

            return escaneoAnulacion; 
        }


        public bool cancelarItem(int numero, string itemCode) {

            bool todosCancelados = true;

            var escaneosItems = db.cbr_SolicitudDevolucionEntry.Where(i => i.number == numero && i.itemCode == itemCode).ToList();
            escaneosItems.ForEach(i=> {
                if ((bool)!i.cancelado)
                {
                    todosCancelados = false;
                    i.cancelado = true;
                }
              
            });

            

            db.SaveChanges();

            return todosCancelados;

        }

     
    }
}
