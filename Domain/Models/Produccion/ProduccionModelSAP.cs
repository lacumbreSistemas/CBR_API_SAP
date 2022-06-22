using HQ.Repositories;
using Intermedia_.Repositories.Produccion;
using SAP;
using SAP.Models.Mermas;
using SAP.Models.Produccion;
using SAP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Produccion
{
    public class ProduccionModelSAP : ProduccionModelMaster

    {

        public int docEntrySalida { get; set; }

        public int docEntryEntrada { get; set; }

        public int docNumSalida { get; set; }

        public int docNumEntrada { get; set; }


        public string cuentaContable { get; set; }

        public string centroCostoTienda { get; set; }
        public string centroCosto3 { get; set; }

        public double cantidadMerma { get; set; } = 0;
   

        public List<ProduccionEntryResumenSAP> entrys { get; set; }


        public ProduccionModelSAP() {
            entrys = new List<ProduccionEntryResumenSAP>();
        }
        private void establecerCuentaContable() {
            RemarksRepo remarksRepo = new RemarksRepo();
            cuentaContable = remarksRepo.obgenerCuentaContable(remarkCode);

        }

        private void setCentroCosto()
        {
            RemarksRepo remarksRepo = new RemarksRepo();
            var CentroCosto = remarksRepo.obtenerCentroCosto(remarkCode);

            var centrosCostosSeparados = CentroCosto.ToString().Split(';');
            int index = 1;
            foreach (string centrocosto in centrosCostosSeparados)
            {


                if (centroCostoTienda != "" && index == 1)
                    centroCostoTienda = centrocosto;

                if (centroCostoTienda != "" && index == 3)
                    centroCosto3 = centrocosto;

                index++;
            }

            //Intermedia_.Repositories.CentroCostoRepository centroCostoRepository = new Intermedia_.Repositories.CentroCostoRepository();
            //centroCostoTienda = centroCostoRepository.obtenerCentroCostoTienda(codigoTienda);
            //centroCosto3 = remarksRepo.obtenerCentroCosto(remarkCode);
        }


        public ProduccionModelSAP generarSalidaMercancia()
        {
         
            ProduccionSAPEntity salidaMercanciaSAP = new ProduccionSAPEntity();
            ProduccionSAPEntity entradaMercanciaSAP = new ProduccionSAPEntity();

            SalidaMercanciaSAPRepo saliMercanciaRepo = new SalidaMercanciaSAPRepo();
            EntradaMercanciaSAPRepo entradaMercanciaSAPRepo = new EntradaMercanciaSAPRepo();

            ProduccionHeaderRepo produccionHeaderRepo = new ProduccionHeaderRepo();

            string almacenProduccion = produccionHeaderRepo.getAlmacenProduccion(codigoTienda);
            var costoPonderado = Convert.ToDouble(saliMercanciaRepo.obtenerCostoPonderado(codigoTienda, codigoProducto));

            establecerCuentaContable();
            setCentroCosto();
            salidaMercanciaSAP.WhsCode = codigoTienda;
            salidaMercanciaSAP.Comentario = comentario;
            salidaMercanciaSAP.RemarkID = remarkCode;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.UsuarioEncargado = usuario;
            salidaMercanciaSAP.CuentaContable = cuentaContable;
            salidaMercanciaSAP.Remark = remark;
            salidaMercanciaSAP.CentroCosto = centroCostoTienda;
            salidaMercanciaSAP.CentroCosto3 = centroCosto3;
            salidaMercanciaSAP.itemCode = codigoProducto;
            salidaMercanciaSAP.quantity = cantidad;
            salidaMercanciaSAP.costoPonderado = costoPonderado;
            salidaMercanciaSAP.almacenProduccion = almacenProduccion;

            docEntrySalida = saliMercanciaRepo.generarSalidaMercancia(salidaMercanciaSAP);


            salidaMercanciaSAP.costoTotalSalida = saliMercanciaRepo.obtenerCostoSalida(docEntrySalida);

            produccionHeaderRepo.setSalidaDocEntry(numero, docEntrySalida);


            #region entradaMercancia
        

            decimal ventaTotalSuma = entrys.Sum(i=> i.ventaTotal);
            decimal costoTotalPonderado = Math.Round((saliMercanciaRepo.obtenerCostoPonderado(codigoTienda, codigoProducto) * (decimal)cantidad),8);

        

            entrys.ForEach(i=> {
                ProduccionSAPEntryEntity produccionSAPEntryEntity = new ProduccionSAPEntryEntity();

                decimal costoTotal = (Math.Round(i.ventaTotal,8) / Math.Round(ventaTotalSuma,8))* costoTotalPonderado;
                decimal costoLibra =Math.Round(costoTotal,8) / (decimal)i.cantidadEscaneada;

                produccionSAPEntryEntity.ItemCode = i.codigoProducto;
                produccionSAPEntryEntity.Cantidad = i.cantidadEscaneada;
                produccionSAPEntryEntity.costoLibra = Math.Round(costoLibra,8);
                salidaMercanciaSAP.produccionEntryEntrada.Add(produccionSAPEntryEntity);

                cantidadMerma = cantidadMerma + i.cantidadEscaneada;
            });


            cantidadMerma = cantidadMerma - cantidad;

            salidaMercanciaSAP.cantidadMerma = cantidadMerma;
            double cantidadTotalEntrada =  salidaMercanciaSAP.produccionEntryEntrada.Sum(i=> i.Cantidad);
            salidaMercanciaSAP.WhsCode = almacenProduccion;

              docEntryEntrada = entradaMercanciaSAPRepo.generarEntradaMercancia(salidaMercanciaSAP, docEntrySalida);

                produccionHeaderRepo.setEntradaDocEntry(numero, docEntryEntrada);
            #endregion




            return this;

        }






    }
}
