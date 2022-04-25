using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class cbr_listaItemsRecepcionImportadosRepository:MasterRespository
    {


        public List<cbr_listaItemsRecepcionImportados> ObtenerHistorialDeEscaneos(string itemCode, string numeroContenedor)
        {
            return db.cbr_listaItemsRecepcionImportados.Where(i => i.numeroContenedor == numeroContenedor && i.itemCode == itemCode).ToList();
        }


        public List<cbr_listaItemsRecepcionImportados> ObtenerEscaneosContenedor(string numeroContenedor)
        {
            return db.cbr_listaItemsRecepcionImportados.Where(i => i.numeroContenedor == numeroContenedor).ToList();
        }


        public void GuardarEscaneo(cbr_listaItemsRecepcionImportados Entry)
        {
                db.cbr_listaItemsRecepcionImportados.Add(Entry);
                db.SaveChanges();
        }


        public int borrarEscaneo(int id)
        {
            var escaneo = db.cbr_listaItemsRecepcionImportados.FirstOrDefault(i => i.id == id);

            if ((bool)escaneo.deleted)
                throw new Exception("Escaneo ya fue eliminado");
            
            escaneo.deleted = true;

            cbr_listaItemsRecepcionImportados escaneoNegativo = new cbr_listaItemsRecepcionImportados();

            escaneoNegativo.usuario = escaneo.usuario;
            escaneoNegativo.deleted = false;
            escaneoNegativo.cantidad = escaneo.cantidad * (-1);
            escaneoNegativo.deletedId = escaneo.id;
            escaneoNegativo.fecha = DateTime.Now;
            escaneoNegativo.itemCode = escaneo.itemCode;
            escaneoNegativo.numeroContenedor = escaneo.numeroContenedor;



            db.cbr_listaItemsRecepcionImportados.Add(escaneoNegativo);
            db.SaveChanges();

            return escaneoNegativo.id;

        }


        public cbr_listaItemsRecepcionImportados obtenerEscaneoPorID(int id)
        {
            return db.cbr_listaItemsRecepcionImportados.FirstOrDefault(i => i.id == id);
        }


        public double obtenerCantidadEscaneada(string numeroContenedor, string itemCode)
        {
            var cantidad = db.cbr_listaItemsRecepcionImportados.Where(i => i.itemCode == itemCode && i.numeroContenedor == numeroContenedor).ToList().Sum(i => i.cantidad);

            if (cantidad != null)
            {
                return (double)cantidad;
            }
            else
            {
                return 0;
            }
        }

    }
}
