using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
namespace SAP.Repositories
{
    public  sealed class MasterRepository
    {
         MasterRepository() {

            connection = new Company();
            connection.Server = "10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword = "SAP#Sql_";
            connection.CompanyDB = "SBO_COLONIAL_PRODUCTIVA";
            connection.UserName = "manager";
            connection.Password = "@dmiN123*";
            connection.Connect();

        }

        //Instancia SAP
       Company connection { get; set; }
       public Recordset recordSet { get; set; }
        public  string hola { get; set; }


        //Singleton appllierd
        private static readonly object lockf = new object ();   
       private static MasterRepository instance = null;
  
        public static MasterRepository Instance {

            get {
                if (instance == null)
                {
                    lock (lockf) {
                        if (instance == null)
                        {
                            instance = new MasterRepository();

                        }

                    }

                }


                return instance;
            }
        }





        #region 
     
        

        public void doQuery(string query)
        {
            //connection.Connect();
            recordSet = connection.GetBusinessObject(BoObjectTypes.BoRecordset);
            recordSet.DoQuery(query);
          
        }
        #endregion




    }
}
