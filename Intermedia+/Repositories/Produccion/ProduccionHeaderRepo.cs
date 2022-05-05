using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories.Produccion
{
    public class ProduccionHeaderRepo:MasterRespository
    {
        public cbr_ProduccionHeader obtenerDocumentoIntermedioMerma(int numero)
        {

            cbr_ProduccionHeader produccion = db.cbr_ProduccionHeader.FirstOrDefault(i => i.numero == numero);

            return produccion;
        }
        public int crearDocumentoIntermedioMerma(cbr_ProduccionHeader produccion)
        {

            db.cbr_ProduccionHeader.Add(produccion);
            db.SaveChanges();


            return produccion.numero;

        }


        public List<cbr_ProduccionHeader> obtenerDocumentoIntermedioMerma(string WhsCode)
        {

            List<cbr_ProduccionHeader> documentosIntermediosProduccion = new List<cbr_ProduccionHeader>();

            documentosIntermediosProduccion = db.cbr_ProduccionHeader.Where(i => i.entradaDocEntry == 0 && i.salidaDocEntry == 0 && i.whsCode == WhsCode).OrderByDescending(i => i.numero).ToList();

            return documentosIntermediosProduccion;
        }


        public void cancelarSolicitud(int numero)
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

                throw new Exception("Solicitud de traslado no encontrada");
            }


        }



    }
}
