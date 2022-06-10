using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Produccion
{
    public class ProduccionEntryRepo : MasterRespository
    {
        public cbr_ProduccionEntry crearDocumentoIntermedioProduccion(cbr_ProduccionEntry Entry)
        {

            db.cbr_ProduccionEntry.Add(Entry);
            db.SaveChanges();

            return Entry;
        }


        public List<cbr_ProduccionEntry> obtenerEntriesPornumber(int numero)
        {

            return db.cbr_ProduccionEntry.Where(i => i.numero == numero).ToList();

        }


        public List<cbr_ProduccionEntry> obtenerEntriesPorNumberItemCode(int numero, string itemCode)
        {

            return db.cbr_ProduccionEntry.Where(i => i.numero == numero && i.itemcode == itemCode && !i.cancelado).ToList();

        }

        public bool cancelarItem(int numero, string itemCode)
        {
            bool todosCAncelados = true;

            var escaneosItems = db.cbr_ProduccionEntry.Where(i => i.numero == numero && i.itemcode == itemCode).ToList();

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


        public cbr_ProduccionEntry anularEntrieEscaneo(int id)
        {

            cbr_ProduccionEntry escaneoPorAnular = db.cbr_ProduccionEntry.FirstOrDefault(i => i.id == id);
            cbr_ProduccionEntry escaneoAnulacion = new cbr_ProduccionEntry();

            if (escaneoPorAnular == null)
            {
                throw new Exception("Escaneo no encontrado");
            }
            else if ((bool)escaneoPorAnular.deleted)
            {

                escaneoAnulacion = db.cbr_ProduccionEntry.FirstOrDefault(i => i.deletedId == escaneoPorAnular.id);


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
         

            db.cbr_ProduccionEntry.Add(escaneoAnulacion);

            db.SaveChanges();

            return escaneoAnulacion;
        }


    }
    }
