using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Transformaciones
{
    public class TransformacionEntryRepo : MasterRespository
    {
        public cbr_TransformacionesEntry crearDocumentoIntermedioProduccion(cbr_TransformacionesEntry Entry)
        {

            db.cbr_TransformacionesEntry.Add(Entry);
            db.SaveChanges();

            return Entry;
        }


        public List<cbr_TransformacionesEntry> obtenerEntriesPornumber(int numero)
        {

            return db.cbr_TransformacionesEntry.Where(i => i.numero == numero).ToList();

        }


        public List<cbr_TransformacionesEntry> obtenerEntriesPorNumberItemCode(int numero, string itemCode)
        {

            return db.cbr_TransformacionesEntry.Where(i => i.numero == numero && i.itemcode == itemCode && !(bool)i.cancelado).ToList();

        }

        public bool cancelarItem(int numero, string itemCode)
        {
            bool todosCAncelados = true;

            var escaneosItems = db.cbr_TransformacionesEntry.Where(i => i.numero == numero && i.itemcode == itemCode).ToList();

            escaneosItems.ForEach(i =>
            {

                if ((bool)!i.cancelado)
                {

                    todosCAncelados = false;
                    i.cancelado = true;
                }


            });
            db.SaveChanges();

            return todosCAncelados;

        }


        public cbr_TransformacionesEntry anularEntrieEscaneo(int id)
        {

            cbr_TransformacionesEntry escaneoPorAnular = db.cbr_TransformacionesEntry.FirstOrDefault(i => i.id == id);
            cbr_TransformacionesEntry escaneoAnulacion = new cbr_TransformacionesEntry();

            if (escaneoPorAnular == null)
            {
                throw new Exception("Escaneo no encontrado");
            }
            else if ((bool)escaneoPorAnular.deleted)
            {

                escaneoAnulacion = db.cbr_TransformacionesEntry.FirstOrDefault(i => i.deletedId == escaneoPorAnular.id);


                throw new Exception("Escaneo ya fue anulado por " + escaneoAnulacion.usuario);
            }
            else if ((bool)escaneoPorAnular.cancelado)
            {
                throw new Exception("Item cancelado");

            }


            escaneoPorAnular.deleted = true;

            escaneoAnulacion.deletedId = escaneoPorAnular.id;
            escaneoAnulacion.itemcode = escaneoPorAnular.itemcode;
            escaneoAnulacion.deleted = false;
            escaneoAnulacion.numero = escaneoPorAnular.numero;
            escaneoAnulacion.fecha = DateTime.Now;
            escaneoAnulacion.itemcode = escaneoPorAnular.itemcode;
            escaneoAnulacion.usuario = escaneoPorAnular.usuario;
            escaneoAnulacion.quantity = escaneoPorAnular.quantity * (-1);
            escaneoAnulacion.cancelado = false;

            db.cbr_TransformacionesEntry.Add(escaneoAnulacion);

            db.SaveChanges();

            return escaneoAnulacion;
        }


    }
}
