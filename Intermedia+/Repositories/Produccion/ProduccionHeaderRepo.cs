using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Produccion
{
    public class ProduccionHeaderRepo:MasterRespository
    {
        public cbr_ProduccionHeader obtenerDocumentoIntermedioProduccion(int numero)
        {

            cbr_ProduccionHeader produccion = db.cbr_ProduccionHeader.FirstOrDefault(i => i.numero == numero);

            return produccion;
        }
        public int crearDocumentoIntermedioProduccion(cbr_ProduccionHeader produccion)
        {

            db.cbr_ProduccionHeader.Add(produccion);
            db.SaveChanges();


            return produccion.numero;

        }


        public List<cbr_ProduccionHeader> obtenerDocumentoIntermedioProduccion(string WhsCode)
        {

            List<cbr_ProduccionHeader> documentosIntermediosProduccion = new List<cbr_ProduccionHeader>();

            documentosIntermediosProduccion = db.cbr_ProduccionHeader.Where(i => i.entradaDocEntry == 0 && i.salidaDocEntry == 0 && i.whsCode == WhsCode && !i.anulado).OrderByDescending(i => i.numero).ToList();

            return documentosIntermediosProduccion;
        }


        public void cancelarDocumento(int numero)
        {
            var header = db.cbr_ProduccionHeader.FirstOrDefault(i => i.numero == numero);
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

                throw new Exception("Documento intermedio de producción no encontrada");
            }


        }

        public void setSalidaDocEntry(int number, int docentry)
        {

            var header = db.cbr_ProduccionHeader.FirstOrDefault(i => i.numero == number);
            header.salidaDocEntry = docentry;

            db.SaveChanges();

        }

        public void setEntradaDocEntry(int number, int docentry)
        {

            var header = db.cbr_ProduccionHeader.FirstOrDefault(i => i.numero == number);
            header.entradaDocEntry = docentry;

            db.SaveChanges();

        }

        public string getAlmacenProduccion(string WhsCode) {

            var almacen = db.cbr_MapAlmacenesProduccion.FirstOrDefault(i=> i.almacenProduccion == WhsCode);

            return almacen.almacenTienda;
        
        }

    }
}
