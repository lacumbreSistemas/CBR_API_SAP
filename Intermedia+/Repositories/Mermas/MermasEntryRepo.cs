using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
  public  class MermasEntryRepo:MasterRespository
    {
        public cbr_MermasEntry crearEntryDocumentoIntermedioMerma(cbr_MermasEntry entryMerma)
        {

            db.cbr_MermasEntry.Add(entryMerma);
            db.SaveChanges();

            return entryMerma; 

        }

        public List<cbr_MermasEntry> obtenerEntriesPorNumber(int number) {

            return db.cbr_MermasEntry.Where(i => i.number == number).ToList();
        
        }


        public List<cbr_MermasEntry> obtenerItemsPorNumberItemCode(int number, string itemCode)
        {

            return db.cbr_MermasEntry.Where(i=> i.itemCode == itemCode && i.number == number && !(bool)i.cancelado).ToList(); 
        }

        public cbr_MermasEntry obtenerEntriePorID(int id) {

            return db.cbr_MermasEntry.FirstOrDefault(i=> i.id == id);
        
        }

        public cbr_MermasEntry anularEntrieEscaneo(int id) {

            cbr_MermasEntry escaneoPorAnular = db.cbr_MermasEntry.FirstOrDefault(i=> i.id == id);
            cbr_MermasEntry escaneoAnulacion = new cbr_MermasEntry();


            if (escaneoPorAnular == null)
            {

                throw new Exception("Escaneo no encontrado");

            }
            else if ((bool)escaneoPorAnular.deleted)
            {

                escaneoAnulacion = db.cbr_MermasEntry.FirstOrDefault(i => i.deletedid == escaneoPorAnular.id);
                throw new Exception("Escaneo ya fue anulado por " + escaneoAnulacion.usuario);

            }
            else if ((bool) escaneoPorAnular.cancelado) {
                throw new Exception("Item cancelado");
            }

            escaneoPorAnular.deleted = true;
            escaneoAnulacion.deletedid = escaneoPorAnular.id;
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.deleted = escaneoAnulacion.deleted;
            escaneoAnulacion.number = escaneoPorAnular.number;
            escaneoAnulacion.fecha = DateTime.Now;
            escaneoAnulacion.itemCode = escaneoPorAnular.itemCode;
            escaneoAnulacion.usuario = escaneoPorAnular.usuario;
            escaneoAnulacion.quantity = escaneoPorAnular.quantity * (-1);
            escaneoAnulacion.deleted = false;
            escaneoAnulacion.cancelado = false; 

            db.cbr_MermasEntry.Add(escaneoAnulacion);
            db.SaveChanges();

            return escaneoAnulacion;
        }

        public bool cancelarItem(int numero, string itemCode) {
            bool todosCAncelados = true;

            var escaneosItems = db.cbr_MermasEntry.Where(i=> i.number == numero && i.itemCode == itemCode).ToList();

            escaneosItems.ForEach(i=> {

                if ((bool)!i.cancelado)
                {

                    todosCAncelados = false;
                    i.cancelado = true; 
                }
           
                    
             });


            db.SaveChanges();

            return todosCAncelados;
        }
    

       
    }
}
