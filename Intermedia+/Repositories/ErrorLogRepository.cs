using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_.Repositories
{
    public class ErrorLogRepository:MasterRespository 
    {
        public int guardarError(ErrorLog error) {

            db.ErrorLog.Add(error);

            db.SaveChanges();

            return error.id;
        }
    }
}
