using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
namespace SAP.Repositories
{
    public  class MasterRepository
    {
        public Company connection { get; set; }

        private static MasterRepository _instance;

        public static MasterRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MasterRepository();
            }
            return _instance;
        }
        public MasterRepository()
        {
            Conectar();
        }

        public void Conectar()
        {
            var aa = ConfigurationManager.ConnectionStrings["SAP"];
            connection = new Company();
            //connection.Server = ConfigurationManager.AppSettings["Server"];
            //connection.LicenseServer = "10.10.1.12";
            //connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            //connection.DbUserName = ConfigurationManager.AppSettings["DbUserName"]; 
            //connection.DbPassword = ConfigurationManager.A ppSettings["DbPassword"];
            //connection.UserName = ConfigurationManager.AppSettings["UserName"];
            //connection.Password = ConfigurationManager.AppSettings["Password"];
            //connection.CompanyDB = ConfigurationManager.AppSettings["CompanyDB"];


#if (Debug)
            connection.Server ="10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword ="SAP#Sql_";
            connection.UserName ="manager";
            connection.Password = "@dmiN123*";
            connection.CompanyDB = "SBO_CBR_COLONIAL_PRUEBAS";
#endif
#if (Pruebas)
            connection.Server ="10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword ="SAP#Sql_";
            connection.UserName ="manager";
            connection.Password = "@dmiN123*";
            connection.CompanyDB = "SBO_CBR_COLONIAL_PRUEBAS";
#endif
#if (Produccion)
            connection.Server ="10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword ="SAP#Sql_";
            connection.UserName ="manager";
            connection.Password = "@dmiN123*";
            connection.CompanyDB = "SBO_COLONIAL_PRODUCTIVA";
#endif

#if (Release)
            connection.Server ="10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword ="SAP#Sql_";
            connection.UserName ="manager";
            connection.Password = "@dmiN123*";
            connection.CompanyDB = "SBO_CBR_COLONIAL_PRUEBAS";
#endif

            connection.Connect();




        }

        public Recordset doQuery(string query)
        {
            var res = connection.GetBusinessObject(BoObjectTypes.BoRecordset);
            res.DoQuery(query);
            return res;

        }


    }
}
