using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_
{
    public class ResilenciaEstrategia
    {

        //public ResilenciaEstrategia() { }

        //public ResilenciaEstrategia(int maxRetryCount, TimeSpan maxDelay)
        //: base(maxRetryCount, maxDelay)
        //{
                
        //}

        //protected override bool ShouldRetryOn(Exception ex)
        //{
        //    bool retry = false;

        //    SqlException sqlException = ex as SqlException;
        //    if (sqlException != null)
        //    {
        //        int[] errorsToRetry =
        //        {
        //            1205,  //Deadlock
        //            -2,    //Timeout
        //            2601  //primary key violation. Normally you wouldn't want to retry these, 
        //                  //but some procs in my database can cause it, because it's a crappy 
        //                  //legacy junkpile.
        //        };
        //        if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
        //        {
        //            retry = true;
        //        }
        //        else
        //        {
        //            //Add some error logging on this line for errors we aren't retrying.
        //            //Make sure you record the Number property of sqlError. 
        //            //If you see an error pop up that you want to retry, you can look in 
        //            //your log and add that number to the list above.
        //        }
        //    }
        //    if (ex is TimeoutException)
        //    {
        //        retry = true;
        //    }
        //    return retry;
        //}

    }
}
