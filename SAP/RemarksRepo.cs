using SAP.Models;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP
{
   public class RemarksRepo
    {
        MasterRepository _MasterRepository = MasterRepository.GetInstance();
        public List<Remarks> obtenerRemarks(string CentroCostoTienda)
        {

            List<Remarks> remarks = new List<Remarks>();
            var remarksSAP = _MasterRepository.doQuery("select U_Codigo_Remark,U_Remak,SUBSTRING(U_CecosDimen,1,3) from [@REMARK1] Where U_activo = 'Y' and U_Tipo_Documento = 60 and SUBSTRING(U_CecosDimen,1,3) ='"+ CentroCostoTienda+"'");

            while (!remarksSAP.EoF)
            {
                Remarks remark = new Remarks();

                remark.code = remarksSAP.Fields.Item("U_Codigo_Remark").Value;
                remark.remark = remarksSAP.Fields.Item("U_Remak").Value;
          


                remarks.Add(remark);
                remarksSAP.MoveNext();
            }
            return remarks;
        }


        public string obterRemark(string code)
        {
            var consultaremark = _MasterRepository.doQuery("select U_Remak from [@REMARK1] where U_Codigo_Remark = '" + code + "'");
            consultaremark.MoveFirst();
            string remark = consultaremark.Fields.Item("U_Remak").Value;
            return remark;
        }

        public string obtenerCentroCosto(string code) {
            var consultaCentroCosto = _MasterRepository.doQuery("select U_CecosDimen from [@REMARK1] where U_Codigo_Remark = '" + code + "'");
            consultaCentroCosto.MoveFirst();
            

            return consultaCentroCosto.Fields.Item("U_CecosDimen").Value;


        }





        public string obgenerCuentaContable(string code)
        {
            var consultaremark = _MasterRepository.doQuery(@"	select U_Cuenta_Contable from [@oREMARK] c
	                                                            inner join [@REMARK1] d on c.Code = d.Code
	                                                            where U_Codigo_Remark = '" + code + "'");
            consultaremark.MoveFirst();
            string remark = consultaremark.Fields.Item("U_Cuenta_Contable").Value;
            return remark;
        }
    }
}
