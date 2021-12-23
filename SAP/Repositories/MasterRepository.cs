using System;
using System.Collections.Generic;
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
            connection = new Company();
            connection.Server = "10.10.1.12";
            connection.LicenseServer = "10.10.1.12";
            connection.DbServerType = BoDataServerTypes.dst_MSSQL2019;
            connection.DbUserName = "sa";
            connection.DbPassword = "SAP#Sql_";
            connection.UserName = "manager";
            connection.Password = "@dmiN123*";
            connection.CompanyDB = "SBO_COLONIAL_PRODUCTIVA";
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
