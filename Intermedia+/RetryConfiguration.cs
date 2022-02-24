using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermedia_
{
   public  class RetryConfiguration: DbConfiguration
    {


        //public RetryConfiguration()
        //{
        //    SetExecutionStrategy("System.Data.SqlClient", () => new ResilenciaEstrategia());
        //}





        //public RetryConfiguration()
        //{
        //    var executionStrategy = SuspendExecutionStrategy
        //        ? (IDbExecutionStrategy)new DefaultExecutionStrategy()
        //        : new RetryExecutionStrategy(3, new TimeSpan(0, 0, 0, 3));
        //    this.SetExecutionStrategy("Devart.Data.PostgreSql", () => executionStrategy);
        //}

        //public static bool SuspendExecutionStrategy
        //{
        //    get
        //    {
        //        return (bool?)CallContext.LogicalGetData("SuspendExecutionStrategy") ?? false;
        //    }
        //    set
        //    {
        //        CallContext.LogicalSetData("SuspendExecutionStrategy", value);
        //    }
        //}
    }
}
