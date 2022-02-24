using Intermedia_;
using Intermedia_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ErrorModel
    {
        //public
  
        public string mensaje { get; set; }
        public string ruta { get; set; }

        public string detalle { get; set; }


        //private

        private ErrorLogRepository errorRepository {get; set;} 
        

       public ErrorModel() {

            errorRepository = new ErrorLogRepository();
        }
        public int guardar() {

            ErrorLog errorLog = new ErrorLog();

            errorLog.mensaje = mensaje;
            errorLog.pathEndPoint = ruta;
            errorLog.detalle = detalle;
          

          return  errorRepository.guardarError(errorLog);
        }
    }
}
