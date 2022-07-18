using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Transformaciones
{
    public class TransformacionesHeaderRepo : MasterRespository
    {
        public cbr_transformacionesHeader obtenerDocumentoIntermedioTransformacion(int numero)
        {

            cbr_transformacionesHeader transformacion = db.cbr_transformacionesHeader.FirstOrDefault(i => i.numero == numero);

            return transformacion;
        }
        public int crearDocumentoIntermedioTransformacion(cbr_transformacionesHeader transformacion)
        {

            db.cbr_transformacionesHeader.Add(transformacion);
            db.SaveChanges();


            return transformacion.numero;

        }


        public List<cbr_transformacionesHeader> obtenerDocumentoIntermedioTransformacion(string WhsCode)
        {

            List<cbr_transformacionesHeader> documentosIntermediosTransformacio = new List<cbr_transformacionesHeader>();

            documentosIntermediosTransformacio = db.cbr_transformacionesHeader.Where(i => i.entradaDocEntry == 0 && i.salidaDocEntry == 0 && i.whsCode == WhsCode && !(bool)i.anulado).OrderByDescending(i => i.numero).ToList();

            return documentosIntermediosTransformacio;
        }


        public void cancelarDocumento(int numero)
        {
            var header = db.cbr_transformacionesHeader.FirstOrDefault(i => i.numero == numero);
            if (header != null)
            {
                if ((bool)header.anulado)
                    throw new Exception("Este documento ya había sido anulado");

                if (header.entradaDocEntry > 0 || header.salidaDocEntry > 0)
                    throw new Exception("Este documento ya fue subido a SAP, no se puede cancelar");
                header.anulado = true;

                db.SaveChanges();


            }
            else
            {

                throw new Exception("Documento intermedio de transformación no encontrada");
            }


        }

        public void setSalidaDocEntry(int number, int docentry)
        {

            var header = db.cbr_transformacionesHeader.FirstOrDefault(i => i.numero == number);
            header.salidaDocEntry = docentry;

            db.SaveChanges();

        }

        public void setEntradaDocEntry(int number, int docentry)
        {

            var header = db.cbr_transformacionesHeader.FirstOrDefault(i => i.numero == number);
            header.entradaDocEntry = docentry;

            db.SaveChanges();

        }

        //public string getAlmacenProduccion(string WhsCode)
        //{

        //    var almacen = db.cbr_MapAlmacenesProduccion.FirstOrDefault(i => i.almacenProduccion == WhsCode);

        //    return almacen.almacenTienda;

        //}


    }
}
