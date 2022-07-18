using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
  public  class MermasHeaderRepo:MasterRespository
    {

        public cbr_MermasHeader obtenerDocumentoIntermedioMerma(int number)
        {

            cbr_MermasHeader merma = db.cbr_MermasHeader.FirstOrDefault(i => i.number == number);

            return merma; 
        }
        public int crearDocumentoIntermedioMerma(cbr_MermasHeader merma) {

            db.cbr_MermasHeader.Add(merma);
            db.SaveChanges();


            return merma.number;
        
        }

        public List<cbr_MermasHeader> obtenerDocumentoIntermedioMerma(string WhsCode) {

            List<cbr_MermasHeader> mermas = new List<cbr_MermasHeader>();

            mermas = db.cbr_MermasHeader.Where(i => !(bool)i.ifSAP && !(bool)i.anulado && i.whsCode == WhsCode).OrderByDescending(i=> i.number).ToList();

            return mermas; 
        }


        public void setIfSAP(int number) {

            var header = db.cbr_MermasHeader.FirstOrDefault(i=> i.number == number);

            header.ifSAP = true;

            db.SaveChanges();
       
        }

        public void cancelarDocumentoIntermedioMerma(int number) {


            var header = db.cbr_MermasHeader.FirstOrDefault(i => i.number == number);

            if (header != null)
            {

                if ((bool)header.anulado)
                    throw new Exception("Este documento ya había sido anulado");

                if ((bool)header.ifSAP)
                    throw new Exception("Este documento ya fue subido a SAP, no se puede cancelar");

                header.anulado = true;

                db.SaveChanges();
            }
            else {
                throw new Exception("Documento intermedio de merma no encontrado");
            }
        }

    }
}
